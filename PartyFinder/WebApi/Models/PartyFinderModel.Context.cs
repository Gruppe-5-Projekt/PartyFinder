﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PartyFinderContext : DbContext
    {
        public PartyFinderContext()
            : base("name=PartyFinderContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<ReportUser> ReportUser { get; set; }
    }
}