//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClassMaster
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public double ClassPrice { get; set; }
        public int ClassSessions { get; set; }
    
        public virtual User User { get; set; }
    }
}