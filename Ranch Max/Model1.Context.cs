﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ranch_Max
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Abortion> Abortions { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<AnimalBreed> AnimalBreeds { get; set; }
        public virtual DbSet<AnimalSale> AnimalSales { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserInfo> AspNetUserInfoes { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Breeding> Breedings { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Calving> Calvings { get; set; }
        public virtual DbSet<DryPeriod> DryPeriods { get; set; }
        public virtual DbSet<Expense_Type> Expense_Type { get; set; }
        public virtual DbSet<Expens> Expenses { get; set; }
        public virtual DbSet<FeedConsumption> FeedConsumptions { get; set; }
        public virtual DbSet<FeedFormula> FeedFormulas { get; set; }
        public virtual DbSet<FeedPreparing> FeedPreparings { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<MilkBuyer> MilkBuyers { get; set; }
        public virtual DbSet<Milking> Milkings { get; set; }
        public virtual DbSet<StockAdd> StockAdds { get; set; }
        public virtual DbSet<StockItem> StockItems { get; set; }
        public virtual DbSet<StockRemaining> StockRemainings { get; set; }
        public virtual DbSet<StockType> StockTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
