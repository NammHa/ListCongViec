//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class TBL_PHONG_BAN
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<bool> isDefault { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public Nullable<bool> isVisible { get; set; }
        public Nullable<int> IdParent { get; set; }
        public string DepartmentCode { get; set; }
    }
}
