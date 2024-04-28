using Dapper;
using Prescription.DAL.Entities;
using Prescription.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.DAL.Repos
{
    public class DbAddressRepo: RepoBase<DbAddress>
    {
        
        private const string QuerySetCurrentAddress = 
            "UPDATE dbo.Address SET [Current]=0 WHERE OwnerId=@ownerId AND OwnerType=@type;"+
            "UPDATE dbo.Address SET [Current]=1 WHERE Id=@id;";
        
        public DbAddressRepo(IDbConnection conn) : base(conn) { }

        public override long Insert(DbAddress entity)
        {
            int clear = ClearCurrentAddress(entity.OwnerId, entity.OwnerType);
            return base.Insert(entity);
        }
        public int ClearCurrentAddress(long id, int type)
        {
            string QueryClearCurrentAddress = @"
            UPDATE dbo.Address SET [Current]=0 WHERE OwnerId=@id AND OwnerType=@type";
            var param = new
            {
                id = id,
                type = type
            };
            return _connection.Execute(QueryClearCurrentAddress, param);
        }
        public long InsertNewCurrentAddress(long ownerId, IAddress address, AddressOwner ownerType)
        {
            DbAddress newAddress = new DbAddress
            {
                Id = 0,
                City = address.City,
                ZIP = address.ZIP,
                Street = address.Street,
                Haus = address.Haus,
                OwnerId = ownerId,
                OwnerType = (int)ownerType,
                Current = true
            };
            return new DbAddressRepo(_connection).Insert(newAddress);
        }
        public int SetCurrentAddress(long id, long ownerId, AddressOwner type)
        {
            var param = new
            {
                id = id,
                ownerId = ownerId,
                type = (int)type
            };
            return _connection.Execute(QuerySetCurrentAddress, param);
        }
        public Address GetCurrentAddress(long id, AddressOwner type)            
        {
            string sql = @"            
            SELECT * FROM dbo.Address WHERE OwnerId=@id AND OwnerType=@type AND [Current]=1;";
            return  _connection.QueryFirst<Address>(sql,
                new { id = id, type = (int)type });
        }
        public List<T> AllOwnerWithCurrentAddress<T>(AddressOwner type) where T : IAddressOwner
        {
            string sql = $@"
            SELECT * FROM dbo.{typeof(T).Name} owner
            LEFT JOIN dbo.Address address
            ON owner.Id=address.OwnerId AND OwnerType=@type AND [Current]=1";

            var output = _connection.Query<T, IAddress, T>(sql, (owner, address) =>
            {
                owner.CurrentAddress = address;
                return owner;
            }, 
            new { type = (int)type });
            return output.ToList();
        }
    }
}
