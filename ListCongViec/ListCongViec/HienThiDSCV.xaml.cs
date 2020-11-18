using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListCongViec
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HienThiDSCV : ContentPage
    {

        public HienThiDSCV()
        {
            InitializeComponent();
            GetDSCV();
            StartTimer();
        }
        async void ButtonDangXuat_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Đăng xuất", "Bạn có chắc chắn muốn thoát ra khỏi hệ thống?", "Yes", "No");
            Debug.WriteLine("Answer: " + answer);
            if (answer == true)
            {
                await Navigation.PopAsync();
            }
        }
        public async void GetDSCV()
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
            LV.ItemsSource = cv;
        }
        public void StartTimer()
        {
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
              {
                  Device.BeginInvokeOnMainThread(() =>
                  {
                      GetDSCV();
                  });
                  return true;
              });
        }
        public async void SearchBar_TextChanged(object Ssender, TextChangedEventArgs e)
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
            LV.ItemsSource = cv;

            LV.ItemsSource = cv.Where(x => Convert.ToString(x.NGAY_BAT_DAU).StartsWith(e.NewTextValue)
            || Convert.ToString(x.NGAY_KET_THUC).StartsWith(e.NewTextValue)
            || x.KET_QUA_CV.StartsWith(e.NewTextValue));

        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ThemMoi(null));
        }

        private void btnChinhSua_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditCV());
        }

        private async void TapGestureRecognizer_Tapped_Edit(object sender, EventArgs e)
        {

            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;
            var listCV = LV.ItemsSource as List<CongViec>;
            CongViec cv = listCV.Where(x => x.ID == (int)tappedEventArgs.Parameter).FirstOrDefault();
            await Navigation.PushAsync(new EditCV(cv));


        }

        private void LV_Refreshing(object sender, EventArgs e)
        {
            GetDSCV();
            LV.IsRefreshing = false;
        }
        private async void TapGestureRecognizer_Tapped_Delete(object sender, EventArgs e)
        {
            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;
            var listCV = LV.ItemsSource as List<CongViec>;
            CongViec cv = listCV.Where(x => x.ID == (int)tappedEventArgs.Parameter).FirstOrDefault();

            CongViec _congviec = new CongViec();
            if (_congviec != null)
            {
                _congviec.ID = cv.ID;
                _congviec.TT_XOA = cv.TT_XOA;
            }
            bool answer = await DisplayAlert("Thông báo", "Bạn có chắc chắn muốn xóa dữ liệu này?", "Yes", "No");
            Debug.WriteLine("Answer: " + answer);
            if (answer == true)
            {
                string url = "https://qlcv-api.conveyor.cloud/";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url + "api/DeleteCV");

                HttpResponseMessage response = await client.PostAsJsonAsync<CongViec>("DeleteCV", _congviec);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                }
                await DisplayAlert("Thông báo", "Bạn đã xóa dữ liệu thành công!", "OK");
            }
        }
    }
};
