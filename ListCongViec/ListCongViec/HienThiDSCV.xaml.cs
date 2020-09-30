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
            BindingContext = new HienThiDSCVViewModel(Navigation);
        }
        /*private void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ThemMoi());

            CongViec NewCV = new CongViec();
            NewCV.TEN_CONG_VIEC = null;
            NewCV.TEN = null;
            NewCV.MA_HOP_DONG = null;
            NewCV.FullName = null;
            NewCV.NGAY_BAT_DAU = null;
            NewCV.NGAY_KET_THUC = null;
            NewCV.KET_QUA_CV = null;
            NewCV.GHI_CHU = null;
            Navigation.PushAsync(new ThemMoi());
        }*/

        async void ButtonDangXuat_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Đăng xuất", "Bạn có chắc chắn muốn thoát ra khỏi hệ thống?", "Yes", "No");
            Debug.WriteLine("Answer: " + answer);
            if (answer == true)
            {
                await Navigation.PushAsync(new MainPage());
            }
        }
        public async void GetDSCV()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            //////HttpClient client = new HttpClient();

            var response = await client.GetAsync("https://qlcv-api.conveyor.cloud/api/GetListCV");
            string listCVJSON = await response.Content.ReadAsStringAsync();
            listCV cvobj = new listCV();
            cvobj = JsonConvert.DeserializeObject<listCV>(listCVJSON);

            IList<CongViec> cv = new List<CongViec>();
            cv = cvobj.DATA;
            foreach (var item in cv)
            {
                /*if (item.ID_KET_QUA_CV == 1)
                {
                    item.KET_QUA_CV = "Hoàn thành";
                }
                else if (item.ID_KET_QUA_CV == 2)
                {
                    item.KET_QUA_CV = "Hủy";
                }
                else if (item.ID_KET_QUA_CV == 3)
                {
                    item.KET_QUA_CV = "Đang làm";
                }*/
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

        private async void LV_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                //User user = e.Item as User;
                CongViec cv = e.Item as CongViec;
                await Navigation.PushAsync(new HienThiChiTietCV(cv));

            }
            catch (Exception ex)
            {
                await DisplayAlert("Input Error", ex.Message, "OK");
                return;
            }
        }

        public async void SearchBar_TextChanged(object Ssender, TextChangedEventArgs e)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);

            //////HttpClient client = new HttpClient();

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


            //LV.ItemsSource = cvobj.DATA.Where(x => x.TEN_CONG_VIEC.StartsWith(e.NewTextValue));

            //LV.ItemsSource = cvobj.DATA.Where(x => x.TEN.StartsWith(e.NewTextValue));

            //LV.ItemsSource = cvobj.DATA.Where(x => x.MA_HOP_DONG.StartsWith(e.NewTextValue));

            //LV.ItemsSource = cvobj.DATA.Where(x => x.FullName.StartsWith(e.NewTextValue));

            LV.ItemsSource = cv.Where(x => Convert.ToString(x.NGAY_BAT_DAU).StartsWith(e.NewTextValue)
            || Convert.ToString(x.NGAY_KET_THUC).StartsWith(e.NewTextValue)
            || x.KET_QUA_CV.StartsWith(e.NewTextValue));

            //LV.ItemsSource = cvobj.DATA.Where(x => Convert.ToString(x.NGAY_KET_THUC).StartsWith(e.NewTextValue));

            //LV.ItemsSource = cvobj.DATA.Where(x => Convert.ToString(x.ID_KET_QUA_CV).StartsWith(e.NewTextValue));

            //LV.ItemsSource = cvobj.DATA.Where(x => x.GHI_CHU.StartsWith(e.NewTextValue));
        }
    }
};

