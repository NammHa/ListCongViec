using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLCV_Client.Models
{
    public class GetHD
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

    public class GetViewHD
    {
        public GetHD viewHD { get; set; }
    }

    public class GetListViewHD
    {
        public List<GetViewHD> ListHD { get; set; }
    }

}