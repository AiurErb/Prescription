﻿
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;
using Prescription.DAL.Entities.Base;

namespace Prescription.DAL.Entities
{
    [Table("Insurance")]
    public class Insurance
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }

    
}
