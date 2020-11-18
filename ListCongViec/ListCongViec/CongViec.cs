using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ListCongViec
{
    public class CongViec
    {
        public int? ID { get; set; }
        public string TEN_CONG_VIEC { get; set; }
        public int? ID_HE_THONG { get; set; }
        public string TEN { get; set; }
        public int? ID_HOP_DONG { get; set; }
        public string MA_HOP_DONG { get; set; }
        public int? ID_NGUOI_CHU_TRI { get; set; }
        public string FullName { get; set; }
        public object ID_NGUOI_PHOI_HOP { get; set; }
        public DateTime? NGAY_BAT_DAU { get; set; }
        public DateTime? NGAY_KET_THUC { get; set; }
        public int? ID_KET_QUA_CV { get; set; }
        public string KET_QUA_CV { get; set; }
        public string? GHI_CHU { get; set; }
        public int ID_NGUOI_TAO { get; set; }
        public DateTime NGAY_TAO { get; set; }
        public int ID_NGUOI_SUA { get; set; }
        public DateTime NGAY_SUA { get; set; }
        public bool TT_XOA { get; set; }
    }
    
    public class listCV
    {
        public string STATUS { get; set; }
        public List<CongViec> DATA { get; set; }


    }
    
    public class HeThong
    {
        public int ID { get; set; }
        public string MA_HE_THONG { get; set; }
        public object STT { get; set; }
        public bool TT_XOA { get; set; }
        public int ID_NGUOI_TAO { get; set; }
        public DateTime NGAY_TAO { get; set; }
        public object ID_NGUOI_SUA { get; set; }
        public object NGAY_SUA { get; set; }
        public int? ID_HOP_DONG { get; set; }
        public string TEN { get; set; }
        public string MO_TA { get; set; }
        public object NGAY_KH_GUI_YC { get; set; }
        public object NGAY_KH_YC_HOAN_THANH { get; set; }
        public object ID_KH_KY_HD { get; set; }
        public object ID_KH_NSD { get; set; }
        public object DO_UU_TIEN { get; set; }
        public object NGAY_BAT_DAU_LAM { get; set; }
        public object NGAY_NGHIEM_THU_TT { get; set; }
        public object QUY { get; set; }
        public object MAN_DAY { get; set; }
        public int? ID_TRANG_THAI_DA { get; set; }
        public object ID_PRODUCT_OWNER { get; set; }
        public object ID_PM { get; set; }
        public object ID_NGUOI_THUC_HIEN { get; set; }
        public object ID_NGUOI_PHOI_HOP { get; set; }
        public int? ID_LOAI_TRIEN_KHAI_DA { get; set; }
        public int? ID_PHAM_VI_DA { get; set; }
        public int? ID_TIEN_DO { get; set; }
        public int? TT_DBHD { get; set; }
        public object TBL_HOP_DONG { get; set; }
    }
    public class listDSHT
    {
        public string STATUS { get; set; }
        public List<HeThong> DATA { get; set; }
    }
    public class HopDong
    {
        public int ID { get; set; }
        public string MA_HOP_DONG { get; set; }
        public object SO_HOP_DONG { get; set; }
        public string TEN { get; set; }
        public string MO_TA { get; set; }
        public object STT { get; set; }
        public bool TT_XOA { get; set; }
        public int? ID_NGUOI_TAO { get; set; }
        public DateTime? NGAY_TAO { get; set; }
        public object ID_NGUOI_SUA { get; set; }
        public object NGAY_SUA { get; set; }
        public List<object> TBL_HE_THONG { get; set; }
    }

    public class listPLHD
    {
        public string STATUS { get; set; }
        public List<HopDong> DATA { get; set; }
    }
    public class NguoiCT
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public bool? isAdmin { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class listNgCT
    {
        public string STATUS { get; set; }
        public List<NguoiCT> DATA { get; set; }
    }
    
    public class KQ
    {
        public int ID_KET_QUA_CV { get; set; }
        public string KET_QUA_CV { get; set; }
    }
    public class listKQ
    {
        public string STATUS { get; set; }
        public List<KQ> DATA { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public bool? isAdmin { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class listUser
    {
        public string STATUS { get; set; }
        public List<User> DATA { get; set; }
    }
}







