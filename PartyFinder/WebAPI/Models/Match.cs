//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public partial class Match
    {
        [DataMember]
        public int EventID { get; set; }
        [DataMember]
        public int ProfileID { get; set; }
        [DataMember]
        public bool Match1 { get; set; }
    
        [IgnoreDataMember]
        public virtual Event Event { get; set; }
        [IgnoreDataMember]
        public virtual Profile Profile { get; set; }
    }
}
