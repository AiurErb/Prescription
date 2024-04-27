using Dapper;
using Microsoft.IdentityModel.Tokens;
using Prescription.DAL.Entities;
using Prescription.DAL.Interfaces;
using System.Data;

namespace Prescription.DAL.Repos
{
    public static class QueriesToDb
    {
        private const string QueryOnePatient = @"
            SELECT * FROM dbo.Patient WHERE Id=@id;
            SELECT * FROM dbo.Address WHERE OwnerId=@id AND OwnerType=0 AND Current=1;";
        private const string QueryClearCurrentAddress = @"
            UPDATE dbo.Address SET Current=0 WHERE OwnerId=@id AND OwnerType=@type";
        private const string QuerySetCurrentAddress = @"
            UPDATE dbo.Address SET Current=0 WHERE OwnerId=@ownerId AND OwnerType=@type;
            UPDATE dbo.Address SET Current=1 WHERE Id=@id;";
        

        public static T OneAddressOwner<T> (IDbConnection connection, long id, AddressOwner type) 
            where T : IAddressOwner
        {
            string sql = $@"
            SELECT * FROM dbo.{typeof(T)} WHERE Id=@id;
            SELECT * FROM dbo.Address WHERE OwnerId=@id AND OwnerType=@type AND Current=1;
            ";
            using (var multiSet = connection.QueryMultiple(sql, new { id = id, type = (int)type }))
            {
                T? addressOwner= multiSet.Read<T>().First();
                if (addressOwner == null) { throw new ArgumentOutOfRangeException("There isn't this patient"); }
                addressOwner.CurrentAddress = multiSet.Read<Address>().First();
                return addressOwner;
            }
        }
        public static List<T> AllOwnerWithCurrentAddress<T>(IDbConnection connection, AddressOwner type) where T : IAddressOwner
        {
            string sql = $@"
            SELECT * FROM dbo.{typeof(T)} o
            LEFT JOIN dbo.Address a
            ON o.Id=a.OwnerId AND OwnerType=@type AND Current=1";

            var output = connection.Query<T, IAddress, T>(sql, (owner, address) =>
            {
                owner.CurrentAddress = address;
                return owner;
            }, new { type = (int)type });
            return output.ToList();
        }
        public static int ClearCurrentAddress(IDbConnection connection,long id, AddressOwner type)
        {
            var param = new
            {
                id = id,
                type = (int)type
            };
            return connection.Execute(QueryClearCurrentAddress, param);
        }
        public static int SetCurrentAddress(IDbConnection connection, long id, long ownerId, AddressOwner type)
        {
            var param = new
            {
                id = id,
                ownerId = ownerId,
                type = (int)type
            };
            return connection.Execute(QuerySetCurrentAddress, param);
        }
    }
}
