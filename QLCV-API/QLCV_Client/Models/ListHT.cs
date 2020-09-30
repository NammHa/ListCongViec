using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLCV_Client.Models
{
    public class GetHT
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
        public object ID_TRANG_THAI_DA { get; set; }
        public object ID_PRODUCT_OWNER { get; set; }
        public object ID_PM { get; set; }
        public object ID_NGUOI_THUC_HIEN { get; set; }
        public object ID_NGUOI_PHOI_HOP { get; set; }
        public object ID_LOAI_TRIEN_KHAI_DA { get; set; }
        public object ID_PHAM_VI_DA { get; set; }
        public object ID_TIEN_DO { get; set; }
        public object TT_DBHD { get; set; }
        public object TBL_HOP_DONG { get; set; }
    }

    public class GetViewHT
    {
        public GetHT viewHT { get; set; }
    }

    public class getListHTView
    {
        public List<GetViewHT> ListHT { get; set; }
    }

}