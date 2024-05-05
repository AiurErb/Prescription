using Prescription.DAL.Entities;
using System.Data;
using Dapper;


namespace Prescription.DAL.Repos
{
    public class DoctorRepo : RepoBase<Doctor>
    {
        public DoctorRepo(IDbConnection connection) : base(connection) { }
        
        public override async Task<List<Doctor>> GetAll(bool filter=true)
        {
            string notDeletedClause = string.Empty;
            if (filter)
            {
                notDeletedClause = " WHERE owner.Deleted=0";
            }
            string sql = $@"
            SELECT * FROM dbo.Doctor owner
            LEFT JOIN
            (SELECT * FROM dbo.Address address
            WHERE  OwnerType=@type AND [Current]=1 ) address
            ON owner.Id=address.OwnerId              
            {notDeletedClause};";

            var output = await _connection.QueryAsync<Doctor, Address, Doctor>(sql, (owner, address) =>
            {
                owner.CurrentAddress = address;
                return owner;
            },
            new { type = (int)AddressOwner.Doctor });
            return output.ToList();
            
        }
        public override Doctor GetOne(long id)
        {            
            Doctor output = base.GetOne(id);
            if (output != null)
            {
                output.CurrentAddress =
                new DbAddressRepo(_connection)
                .GetCurrentAddress(output.Id, AddressOwner.Doctor);
            }
            return output;
        }
    }
}
