using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListCongViec
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemMoi : ContentPage
    {
        // Which is bind to ItemSource of the picker
        //public string Title { get; set; } = "AAAAAAAAAAAAA";
        public IList<string> CongViec { get; set; }
        CongViec _congviec;
        public ThemMoi()
        {
            CongViec = new List<string>();
            CongViec.Add("Baboon");
            CongViec.Add("Capuchin Monkey");
            //monkeyList.Add("Blue Monkey");
            //monkeyList.Add("Squirrel Monkey");
            //monkeyList.Add("Golden Lion Tamarin");
            //monkeyList.Add("Howler Monkey");
            //monkeyList.Add("Japanese Macaque");

           //txtTenHT = new Picker { Title = "Select a monkey", TitleColor = Color.Red };
           // txtTenHT.ItemsSource = CongViec;
        }
        public ThemMoi(CongViec congviec)
        {
            InitializeComponent();
            //BindingContext = new CongViec();
            BindingContext = new AddCVViewModel(Navigation, congviec);
        }
        
           
    


        /*async void ButtonLuu_Clicked(object sender, EventArgs e)
        {
            CongViec cv = new CongViec
            {
                TEN_CONG_VIEC = txtTenCongViec.Text,
                TEN = txtTenHT.Title,
                MA_HOP_DONG = txtPLHĐ.Title,
                //ID_HOP_DONG = Convert.ToInt16(txtMAHD.Text),
                NGAY_BAT_DAU = (DateTime)DateStart.Date,
                NGAY_KET_THUC = (DateTime)DateFinish.Date,
                FullName = txtChuTri.Title,
                //ID_KET_QUA_CV = Convert.ToInt16(txtKQ.Title),
                KET_QUA_CV = txtKQ.Title,
                GHI_CHU = txtGhiChu.Text
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(cv);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await httpClient.PutAsync(String.Format("https://qlcv-api.conveyor.cloud/api/AddNewCV"), httpContent);
            //await DisplayAlert("Thông báo", "Thêm mới thành công", "OK");

            bool answer = await DisplayAlert("Thông báo", "Bạn có chắc chắn muốn thêm dữ liệu mới?", "Yes", "No");
            Debug.WriteLine("Answer: " + answer);
            if (answer == true)
            {
                await DisplayAlert("Thông báo", "Bạn đã thêm dữ liệu mới thành công!", "OK");

                await Navigation.PushAsync(new HienThiDSCV());
            }
        }*/

        private void ButtonHuy_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HienThiDSCV());
        }

        private async void txtTenHT_Focused(object sender, FocusEventArgs e)
        {
            var picker = (Picker)sender;
            //call api

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            var response = await client.GetAsync("https://qlcv-api.conveyor.cloud/api/GetListHT");
            string listCVJSON = await response.Content.ReadAsStringAsync();
            listDSHT cvobj = new listDSHT();
            cvobj = JsonConvert.DeserializeObject<listDSHT>(listCVJSON);

            IList<HeThong> cv = new List<HeThong>();
            cv = cvobj.DATA;



            //var listHT = 
            foreach (var ht in cv)
            {
                picker.Items.Add(ht.TEN);

            }
        }

        private async void txtPLHĐ_Focused(object sender, FocusEventArgs e)
        {
            var picker = (Picker)sender;
            //call api

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            var response = await client.GetAsync("https://qlcv-api.conveyor.cloud/api/GetListHD");
            string listCVJSON = await response.Content.ReadAsStringAsync();
            listPLHD cvobj = new listPLHD();
            cvobj = JsonConvert.DeserializeObject<listPLHD>(listCVJSON);

            IList<HopDong> cv = new List<HopDong>();
            cv = cvobj.DATA;

            foreach (var plhđ in cv)
            {
                picker.Items.Add(plhđ.MA_HOP_DONG);

            }
        }

        private async void txtNCT_Focused(object sender, FocusEventArgs e)
        {
            var picker = (Picker)sender;
            //call api

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            var response = await client.GetAsync("https://qlcv-api.conveyor.cloud/api/GetListNguoiDung");
            string listCVJSON = await response.Content.ReadAsStringAsync();
            listNgCT cvobj = new listNgCT();
            cvobj = JsonConvert.DeserializeObject<listNgCT>(listCVJSON);

            IList<NguoiCT> cv = new List<NguoiCT>();
            cv = cvobj.DATA;

            foreach (var nct in cv)
            {
                picker.Items.Add(nct.FullName);

            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            //var tencv = this.txtTenCongViec;
            //var tenht = this.txtTenHT;
            //var mahopdong = this.txtPLHĐ;
            //var tenchutri = this.txtChuTri;
            //var ngaybatdau = this.DateStart;
            //var ngayketthuc = this.DateFinish;
            //var ketquacv = this.txtKQ.Text;
            //var ghichu = this.txtGhiChu.Text;


            if (_congviec != null)
            {
                //_congviec.TEN_CONG_VIEC = TenCV;
                //_congviec.ID_HE_THONG = Convert.ToInt32(TenHT);
                //_congviec.ID_HOP_DONG = Convert.ToInt32(MaHopDong);
                //_congviec.ID_NGUOI_CHU_TRI = Convert.ToInt32(TenChuTri);
                //_congviec.NGAY_BAT_DAU = Convert.ToDateTime(NgayBatDau);
                //_congviec.NGAY_KET_THUC = Convert.ToDateTime(NgayKetThuc);
                //_congviec.ID_KET_QUA_CV = Convert.ToInt32(KetQua);
                //_congviec.GHI_CHU = GhiChu;

                //_congviec.TEN_CONG_VIEC = TenCV;
                //_congviec.TEN = Convert.ToString(TenHT);
                //_congviec.MA_HOP_DONG = Convert.ToString(MaHopDong);
                //_congviec.FullName = Convert.ToString(TenChuTri);
                //_congviec.NGAY_BAT_DAU = Convert.ToDateTime(NgayBatDau);
                //_congviec.NGAY_KET_THUC = Convert.ToDateTime(NgayKetThuc);
                //_congviec.KET_QUA_CV = KetQua;
                //_congviec.GHI_CHU = GhiChu;

                _congviec.TEN_CONG_VIEC = txtTenCongViec.Text;
                _congviec.TEN = Convert.ToString(txtTenHT.Title);
                _congviec.MA_HOP_DONG = txtPLHĐ.Title;
                _congviec.FullName = txtChuTri.Title;
                _congviec.ID_KET_QUA_CV = Convert.ToInt32(txtKQ.Text);
                _congviec.NGAY_BAT_DAU = DateStart.Date;
                _congviec.NGAY_KET_THUC = DateFinish.Date;
                _congviec.GHI_CHU = txtGhiChu.Text;
            }
            else
            {
                _congviec = new CongViec();
                //_congviec.TEN_CONG_VIEC = TenCV;
                //_congviec.ID_HE_THONG = Convert.ToInt32(TenHT);
                //_congviec.ID_HOP_DONG = Convert.ToInt32(MaHopDong);
                //_congviec.ID_NGUOI_CHU_TRI = Convert.ToInt32(TenChuTri);
                //_congviec.NGAY_BAT_DAU = Convert.ToDateTime(NgayBatDau);
                //_congviec.NGAY_KET_THUC = Convert.ToDateTime(NgayKetThuc);
                //_congviec.ID_KET_QUA_CV = Convert.ToInt32(KetQua);
                //_congviec.GHI_CHU = GhiChu;


                //_congviec.TEN_CONG_VIEC = TenCV;
                //_congviec.TEN = Convert.ToString(TenHT);
                //_congviec.MA_HOP_DONG = Convert.ToString(MaHopDong);
                //_congviec.FullName = Convert.ToString(TenChuTri);
                //_congviec.NGAY_BAT_DAU = Convert.ToDateTime(NgayBatDau);
                //_congviec.NGAY_KET_THUC = Convert.ToDateTime(NgayKetThuc);
                //_congviec.KET_QUA_CV = KetQua;
                //_congviec.GHI_CHU = GhiChu;

                _congviec.TEN_CONG_VIEC = txtTenCongViec.Text;
                _congviec.TEN = Convert.ToString(txtTenHT);
                _congviec.MA_HOP_DONG = Convert.ToString(txtPLHĐ);
                _congviec.FullName = Convert.ToString(txtChuTri);
                _congviec.ID_KET_QUA_CV = Convert.ToInt32(txtKQ.Text);
                _congviec.NGAY_BAT_DAU = DateStart.Date;
                _congviec.NGAY_KET_THUC = DateFinish.Date;
                _congviec.GHI_CHU = txtGhiChu.Text;

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
                await DisplayAlert("Thông báo", "Bạn đã thêm dữ liệu mới thành công!", "OK");

                //await Navigation.PushAsync(new HienThiDSCV());

                
            }
        }
        string _tencv;
        public string TenCV
        {
            get
            {
                _tencv = txtTenCongViec.Text;
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

        Picker _tenht;
        public Picker TenHT
        {
            get
            {
                _tenht = txtTenHT;
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

        Picker _mahopdong;
        public Picker MaHopDong
        {
            get
            {
                _mahopdong = txtPLHĐ;
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

        Picker _tenchutri;
        public Picker TenChuTri
        {
            get
            {
                _tenchutri = txtChuTri;
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

        DatePicker _ngaybatdau;
        public DatePicker NgayBatDau
        {
            get
            {
                _ngaybatdau = DateStart;
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

        DatePicker _ngayketthuc;
        public DatePicker NgayKetThuc
        {
            get
            {
                _ngayketthuc = DateFinish;
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
                _ketquacv = txtKQ.Text;
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
                _ghichu = txtGhiChu.Text;
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
    }

    public class NumericValidationBehavior : Behavior<Entry>
    {

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {

            if (!string.IsNullOrWhiteSpace(args.NewTextValue))
            {
                bool isValid = args.NewTextValue.ToCharArray().All(x => char.IsDigit(x)); //Make sure all characters are numbers

                ((Entry)sender).Text = isValid ? args.NewTextValue : args.NewTextValue.Remove(args.NewTextValue.Length - 1);
            }
        }


    }
}



