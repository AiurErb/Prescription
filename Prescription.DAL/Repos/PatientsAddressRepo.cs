﻿using Prescription.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prescription.DAL.Repos
{
    public class PatientsAddressRepo: RepoBase<PatientsAddress>
    {
        public PatientsAddressRepo(IDbConnection connection) : base(connection) 
        {
        }        
    }
}
