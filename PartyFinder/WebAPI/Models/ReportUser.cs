//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReportUser
    {
        public int AccuserID { get; set; }
        public int OffenderID { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
    
        public virtual Profile Profile { get; set; }
        public virtual Profile Profile1 { get; set; }
    }
}