﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListCongViec
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCV : ContentPage
    {
        Dictionary<string, int> ListHT = new Dictionary<string, int>();
        Dictionary<string, int> HopDong = new Dictionary<string, int>();
        Dictionary<string, int> NguoiCT = new Dictionary<string, int>();

        int? IDHT = -1;
        int? IDPLHD = -1;
        int? IDNGCT = -1;
        
        CongViec _congviec = new CongViec();


        public EditCV(CongViec cv = null)
        {
            _congviec.ID = null;
            InitializeComponent();
            if (cv != null)
            {
                _congviec.ID = cv.ID;
                this.txtTenCongViec.Text = cv.TEN_CONG_VIEC;
                this.txtTenHT.Title = cv.TEN;
                this.txtPLHĐ.Title = cv.MA_HOP_DONG;
                this.DateStart.Date = (DateTime)cv.NGAY_BAT_DAU;
                this.DateFinish.Date = (DateTime)cv.NGAY_KET_THUC;
                this.txtChuTri.Title = cv.FullName;
                this.txtKQ.Text = Convert.ToString(cv.ID_KET_QUA_CV);
                this.txtGhiChu.Text = cv.GHI_CHU;
                IDHT = cv.ID_HE_THONG;
                IDPLHD = cv.ID_HOP_DONG;
                IDNGCT = cv.ID_NGUOI_CHU_TRI;
            }
        }

        private async void SearchBarEditCV_TextChanged(object sender, TextChangedEventArgs e)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            var response = await client.GetAsync("https://qlcv-api.conveyor.cloud/api/GetListCV");
            string listCVJSON = await response.Content.ReadAsStringAsync();
            listCV cvobj = new listCV();
            cvobj = JsonConvert.DeserializeObject<listCV>(listCVJSON);
            IList<CongViec> cv = new List<CongViec>();
            cv = cvobj.DATA;
            foreach (var item in cv)
            {

                switch (item.ID_KET_QUA_CV)
                {
                    case 1:
                        item.KET_QUA_CV = "Hoàn thành";
                        break;
                    case 2:
                        item.KET_QUA_CV = "Hủy";
                        break;
                    case 3:
                        item.KET_QUA_CV = "Đang làm";
                        break;
                    default:
                        item.KET_QUA_CV = "";
                        break;
                }
            }
        }
        private async void txtTenHT_Focused(object sender, FocusEventArgs e)
        {
            var picker = (Picker)sender;

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            var response = await client.GetAsync("https://qlcv-api.conveyor.cloud/api/GetListHT");
            string listCVJSON = await response.Content.ReadAsStringAsync();
            listDSHT cvobj = new listDSHT();
            cvobj = JsonConvert.DeserializeObject<listDSHT>(listCVJSON);

            IList<HeThong> cv = new List<HeThong>();
            cv = cvobj.DATA;

            ListHT.Clear();

            foreach (var ht in cv)
            {
                picker.Items.Add(ht.TEN);
                ListHT.Add(ht.TEN, ht.ID);
            }
        }

        private async void txtPLHĐ_Focused(object sender, FocusEventArgs e)
        {
            var picker = (Picker)sender;

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            var response = await client.GetAsync("https://qlcv-api.conveyor.cloud/api/GetListHD");
            string listCVJSON = await response.Content.ReadAsStringAsync();
            listPLHD cvobj = new listPLHD();
            cvobj = JsonConvert.DeserializeObject<listPLHD>(listCVJSON);

            IList<HopDong> cv = new List<HopDong>();
            cv = cvobj.DATA;

            HopDong.Clear();

            foreach (var plhđ in cv)
            {
                picker.Items.Add(plhđ.MA_HOP_DONG);
                HopDong.Add(plhđ.MA_HOP_DONG, plhđ.ID);
            }
        }

        private async void txtNCT_Focused(object sender, FocusEventArgs e)
        {
            var picker = (Picker)sender;

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            var response = await client.GetAsync("https://qlcv-api.conveyor.cloud/api/GetListNguoiDung");
            string listCVJSON = await response.Content.ReadAsStringAsync();
            listNgCT cvobj = new listNgCT();
            cvobj = JsonConvert.DeserializeObject<listNgCT>(listCVJSON);

            IList<NguoiCT> cv = new List<NguoiCT>();
            cv = cvobj.DATA;

            NguoiCT.Clear();

            foreach (var nct in cv)
            {
                picker.Items.Add(nct.FullName);
                NguoiCT.Add(nct.FullName, nct.Id);

            }
        }
        private void txtTenHT_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;

            if (picker.SelectedIndex == -1)
            {
                IDHT = -1;
            }
            else
            {
                var htName = picker.Items[picker.SelectedIndex];
                IDHT = ListHT[htName];
            }
        }

        private void txtPLHĐ_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;

            if (picker.SelectedIndex == -1)
            {
                IDPLHD = -1;
            }
            else
            {
                var plhdName = picker.Items[picker.SelectedIndex];
                IDPLHD = HopDong[plhdName];
            }
        }

        private void txtChuTri_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;

            if (picker.SelectedIndex == -1)
            {
                IDNGCT = -1;
            }
            else
            {
                var nctName = picker.Items[picker.SelectedIndex];
                IDNGCT = NguoiCT[nctName];
            }
        }


        private async void ButtonCapNhat_Clicked(object sender, EventArgs e)
        {
            if (_congviec != null)
            {

                _congviec.TEN_CONG_VIEC = txtTenCongViec.Text;
                _congviec.ID_HE_THONG = IDHT;
                _congviec.ID_HOP_DONG = IDPLHD;
                _congviec.ID_NGUOI_CHU_TRI = IDNGCT;
                _congviec.ID_KET_QUA_CV = Convert.ToInt32(txtKQ.Text);
                _congviec.NGAY_BAT_DAU = DateStart.Date;
                _congviec.NGAY_KET_THUC = DateFinish.Date;
                _congviec.GHI_CHU = txtGhiChu.Text;
            }

            bool answer = await DisplayAlert("Thông báo", "Bạn có chắc chắn muốn cập nhật dữ liệu không?", "Yes", "No");
            Debug.WriteLine("Answer: " + answer);
            if (answer == true)
            {
                string url = "https://qlcv-api.conveyor.cloud/";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url + "api/EditCV");

                HttpResponseMessage response = await client.PostAsJsonAsync<CongViec>("EditCV", _congviec);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    await DisplayAlert("Thông báo", "Bạn đã cập nhật dữ liệu thành công!", "OK");
                    await Navigation.PopAsync();

                }
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
                _tenht.SelectedItem = txtTenHT.SelectedItem;
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
                _mahopdong.SelectedItem = txtPLHĐ.SelectedItem;
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
                _tenchutri.SelectedItem = txtChuTri.SelectedItem;
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
}