﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShilinWpf.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShilinSupportEntities : DbContext
    {
        public ShilinSupportEntities()
            : base("name=ShilinSupportEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Assets> Assets { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Function> Function { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeService> TypeService { get; set; }
        public virtual DbSet<Worker> Worker { get; set; }
    }
}
