
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities.Base;

namespace Prescription.DAL.Entities
{
    [Table("Insurance")]
    public class Insurance: DbEntity
    {        
        public string Name { get; set; }
    }

    
}
