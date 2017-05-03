using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningCenter.WebSite.Models
{
    public class ClassModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ClassModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}