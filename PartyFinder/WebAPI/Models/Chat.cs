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
    
    public partial class Chat
    {
        public System.DateTime TimeSent { get; set; }
        public string Body { get; set; }
        public int ID { get; set; }
    
        public virtual Event Event { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
