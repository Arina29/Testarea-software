//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApisTokenAuth.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int Id { get; set; }
        public string EmloyeeName { get; set; }
        public int DesignationId { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public Nullable<decimal> Salary { get; set; }
    
        public virtual Designation Designation { get; set; }
    }
}
