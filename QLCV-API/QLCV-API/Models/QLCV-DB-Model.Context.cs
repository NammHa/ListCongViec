﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLCV_API.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLCVEntities : DbContext
    {
        public QLCVEntities()
            : base("name=QLCVEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_BAO_CAO_CV> TBL_BAO_CAO_CV { get; set; }
        public virtual DbSet<TBL_DANH_MUC> TBL_DANH_MUC { get; set; }
        public virtual DbSet<TBL_DS_TAI_LIEU> TBL_DS_TAI_LIEU { get; set; }
        public virtual DbSet<TBL_MENU> TBL_MENU { get; set; }
        public virtual DbSet<TBL_MENU_LOAI> TBL_MENU_LOAI { get; set; }
        public virtual DbSet<TBL_MENU_QUYEN> TBL_MENU_QUYEN { get; set; }
        public virtual DbSet<TBL_NGUOI_DUNG> TBL_NGUOI_DUNG { get; set; }
        public virtual DbSet<TBL_NGUOI_DUNG_PHONG_BAN> TBL_NGUOI_DUNG_PHONG_BAN { get; set; }
        public virtual DbSet<TBL_NGUOI_DUNG_QUYEN> TBL_NGUOI_DUNG_QUYEN { get; set; }
        public virtual DbSet<TBL_PHONG_BAN> TBL_PHONG_BAN { get; set; }
        public virtual DbSet<TBL_QUYEN> TBL_QUYEN { get; set; }
        public virtual DbSet<TBL_QUYEN_RULE> TBL_QUYEN_RULE { get; set; }
        public virtual DbSet<TBL_RULE> TBL_RULE { get; set; }
        public virtual DbSet<TBL_THEO_DOI_CV> TBL_THEO_DOI_CV { get; set; }
        public virtual DbSet<TBL_TIMESHEET> TBL_TIMESHEET { get; set; }
        public virtual DbSet<TBL_HE_THONG> TBL_HE_THONG { get; set; }
        public virtual DbSet<TBL_HOP_DONG> TBL_HOP_DONG { get; set; }
    }
}
