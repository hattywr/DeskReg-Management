﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeskRegMgmtASP
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class usrregDevEntities : DbContext
    {
        public usrregDevEntities()
            : base("name=usrregDevEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DESKREG_SYSTEMS> DESKREG_SYSTEMS { get; set; }
        public virtual DbSet<DESKREG_VLAN> DESKREG_VLAN { get; set; }
        public virtual DbSet<DESKREG_MAKE> DESKREG_MAKE { get; set; }
        public virtual DbSet<DESKREG_MODEL> DESKREG_MODEL { get; set; }
        public virtual DbSet<DESKREG_SYSINFO> DESKREG_SYSINFO { get; set; }
        public virtual DbSet<DESKREG_TYPE> DESKREG_TYPE { get; set; }
        public virtual DbSet<DESKREG_USERINFO> DESKREG_USERINFO { get; set; }
        public virtual DbSet<DESKREG_CONNECTIONTYPE> DESKREG_CONNECTIONTYPE { get; set; }
        public virtual DbSet<DESKREG_ACTION> DESKREG_ACTION { get; set; }
        public virtual DbSet<DESKREG_EVENT> DESKREG_EVENT { get; set; }
    }
}
