//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public long empid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public Nullable<bool> isactive { get; set; }
        public Nullable<System.DateTime> createddate { get; set; }
    }
}
