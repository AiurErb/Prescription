﻿using Prescription.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.DAL.Repos
{
    public class ServiceCathegoryRepo : RepoBase<ServiceCathegory>
    {
        public ServiceCathegoryRepo(IDbConnection connection) : base(connection) { }
        
    }
}
