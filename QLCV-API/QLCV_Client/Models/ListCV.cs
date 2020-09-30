using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLCV_Client.Models
{
    public class getCV
    {
        public int ID { get; set; }
        public string TEN_CONG_VIEC { get; set; }
        public int ID_HE_THONG { get; set; }
        public string TEN { get; set; }
        public int? ID_HOP_DONG { get; set; }
        public string MA_HOP_DONG { get; set; }
        public int ID_NGUOI_CHU_TRI { get; set; }
        public string FullName { get; set; }
        public object ID_NGUOI_PHOI_HOP { get; set; }
        public DateTime? NGAY_BAT_DAU { get; set; }
        public DateTime NGAY_KET_THUC { get; set; }
        public int? ID_KET_QUA_CV { get; set; }
        public string GHI_CHU { get; set; }
        public int ID_NGUOI_TAO { get; set; }
        public DateTime NGAY_TAO { get; set; }
        public int ID_NGUOI_SUA { get; set; }
        public DateTime NGAY_SUA { get; set; }
        public bool TT_XOA { get; set; }
    }

    public class getListCV
    {
        public List<getCV> ListCV { get; set; }
    }
}