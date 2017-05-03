﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCenter.Database
{
    public class DatabaseAccessor
    {
        private static readonly SchoolEntities entities;
        static DatabaseAccessor()
        {
            entities = new SchoolEntities();
            entities.Database.Connection.Open();
        }

        public static SchoolEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
