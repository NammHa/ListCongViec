using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListCongViec
{
    class AddCVViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        CongViec _congviec;

        public Command SaveCV
        {
            get
            {
                return new Command(async () =>
                {
                    if (_congviec != null)
                    {
                        _congviec.TEN_CONG_VIEC = TenCV;
                        _congviec.ID_HE_THONG = Convert.ToInt32(TenHT);
                        _congviec.ID_HOP_DONG = Convert.ToInt32(MaHopDong);
                        _congviec.ID_NGUOI_CHU_TRI = Convert.ToInt32(TenChuTri);
                        _congviec.NGAY_BAT_DAU = NgayBatDau;
                        _congviec.NGAY_KET_THUC = NgayKetThuc;
                        _congviec.ID_KET_QUA_CV = Convert.ToInt32(KetQua);
                        _congviec.GHI_CHU = GhiChu;

                        //    _congviec.TEN_CONG_VIEC = TenCV;
                        //    _congviec.TEN = TenHT;
                        //    _congviec.MA_HOP_DONG = MaHopDong;
                        //    _congviec.FullName = TenChuTri;
                        //    _congviec.NGAY_BAT_DAU = NgayBatDau;
                        //    _congviec.NGAY_KET_THUC = NgayKetThuc;
                        //    _congviec.KET_QUA_CV = KetQua;
                        //    _congviec.GHI_CHU = GhiChu;
                    }
                    else
                    {
                        _congviec = new CongViec();
                        _congviec.TEN_CONG_VIEC = TenCV;
                        _congviec.ID_HE_THONG = Convert.ToInt32(TenHT);
                        _congviec.ID_HOP_DONG = Convert.ToInt32(MaHopDong);
                        _congviec.ID_NGUOI_CHU_TRI = Convert.ToInt32(TenChuTri);
                        _congviec.NGAY_BAT_DAU = NgayBatDau;
                        _congviec.NGAY_KET_THUC = NgayKetThuc;
                        _congviec.ID_KET_QUA_CV = Convert.ToInt32(KetQua);
                        _congviec.GHI_CHU = GhiChu;


                        //    _congviec.TEN_CONG_VIEC = TenCV;
                        //_congviec.TEN = TenHT;
                        //_congviec.MA_HOP_DONG = MaHopDong;
                        //_congviec.FullName = TenChuTri;
                        //_congviec.NGAY_BAT_DAU = NgayBatDau;
                        //_congviec.NGAY_KET_THUC = NgayKetThuc;
                        //_congviec.KET_QUA_CV = KetQua;
                        //_congviec.GHI_CHU = GhiChu;
                    }

                    string url = "https://qlcv-api.conveyor.cloud/";
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(url + "api/AddNewCV");

                    //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsJsonAsync<CongViec>("AddNewCV", _congviec);

                    //Response responseData = JsonConvert.DeserializeObject<Response>(result);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        await Navigation.PopAsync();

                    }

                    /*var httpClient = new HttpClient();
                    var json = JsonConvert.SerializeObject(_congviec);
                    HttpContent httpContent = new StringContent(json);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    await httpClient.PutAsync(String.Format("https://qlcv-api.conveyor.cloud/api/AddNewCV"), httpContent);
                    await Navigation.PushAsync(new HienThiDSCV());*/

                    bool answer = await DisplayAlert("Thông báo", "Bạn có chắc chắn muốn thêm dữ liệu mới?", "Yes", "No");
                    Debug.WriteLine("Answer: " + answer);
                    if (answer == true)
                    {
                        await DisplayAlert("Thông báo", "Bạn đã thêm dữ liệu mới thành công!", "OK");

                        await Navigation.PushAsync(new HienThiDSCV());
                    }
                });
            }
        }

        private Task DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }

        private Task<bool> DisplayAlert(string v1, string v2, string v3, string v4)
        {
            throw new NotImplementedException();
        }

        string _tencv;
        public string TenCV
        {
            get
            {
                return _tencv;
            }
            set
            {
                if (value != null)
                {
                    _tencv = value;
                    OnPropertyChanged();
                }
            }
        }

        string _tenht;
        public string TenHT
        {
            get
            {
                return _tenht;
            }
            set
            {
                if (value != null)
                {
                    _tenht = value;
                    OnPropertyChanged();
                }
            }
        }

        string _mahopdong;
        public string MaHopDong
        {
            get
            {
                return _mahopdong;
            }
            set
            {
                if (value != null)
                {
                    _mahopdong = value;
                    OnPropertyChanged();
                }
            }
        }

        string _tenchutri;
        public string TenChuTri
        {
            get
            {
                return _tenchutri;
            }
            set
            {
                if (value != null)
                {
                    _tenchutri = value;
                    OnPropertyChanged();
                }
            }
        }

        DateTime _ngaybatdau;
        public DateTime NgayBatDau
        {
            get
            {
                return _ngaybatdau;
            }
            set
            {
                if (value != null)
                {
                    _ngaybatdau = value;
                    OnPropertyChanged();
                }
            }
        }

        DateTime _ngayketthuc;
        public DateTime NgayKetThuc
        {
            get
            {
                return _ngayketthuc;
            }
            set
            {
                if (value != null)
                {
                    _ngayketthuc = value;
                    OnPropertyChanged();
                }
            }
        }

        string _ketquacv;
        public string KetQua
        {
            get
            {
                return _ketquacv;
            }
            set
            {
                if (value != null)
                {
                    _ketquacv = value;
                    OnPropertyChanged();
                }
            }
        }

        string _ghichu;
        public string GhiChu
        {
            get
            {
                return _ghichu;
            }
            set
            {
                if (value != null)
                {
                    _ghichu = value;
                    OnPropertyChanged();
                }
            }
        }


        private CongViec congviec;
        /*private string jsonData;
        private readonly string json;*/

        public AddCVViewModel(INavigation navigation, CongViec congviec)
        {
            Navigation = navigation;
            this.congviec = congviec;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
