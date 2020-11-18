using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListCongViec
{
    public partial class MainPage : ContentPage
    {
        Dictionary<string, int> listUser = new Dictionary<string, int>();
        
        int IDND = -1;
        //public List<string> User { get; set; }
        User _user = new User();
        public MainPage()
        {
            InitializeComponent();
            //blabla();
        }
        //private async void blabla()
        //{
        //    HttpClientHandler clientHandler = new HttpClientHandler();
        //    clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        //    HttpClient client = new HttpClient(clientHandler);

        //    var response = await client.GetAsync("https://qlcv-api.conveyor.cloud/api/GetListNguoiDung");
        //    string listCVJSON = await response.Content.ReadAsStringAsync();
        //    listUser userobj = new listUser();
        //    userobj = JsonConvert.DeserializeObject<listUser>(listCVJSON);

        //    IList<User> us = new List<User>();
        //    us = userobj.DATA;

        //    listUser.Clear();

        //    foreach (var hihi in us)
        //    {
        //        if (txtUser.Text == hihi.UserName)
        //        {
        //            IDND = hihi.Id;
        //            //_user.FullName = hihi.FullName;
        //            //_user.FirstName = hihi.FirstName;
        //            //_user.LastName = hihi.LastName;
        //            //_user.Tel = hihi.Tel;
        //            //_user.isAdmin = hihi.isAdmin;
        //            //_user.Email = hihi.Email;
        //        }
        //    }
        //}
        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            //blabla();
            //if (_user != null)
            //{
            //    //_user.Id = IDND;
            //    _user.UserName = txtUser.Text;
            //    _user.Password = txtPassword.Text;

            //}

            //string url = "https://qlcv-api.conveyor.cloud/";
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(url + "api/Login");

            //HttpResponseMessage response = await client.PostAsJsonAsync<User>("Login", _user);

            //if (response.IsSuccessStatusCode)
            //{
            //    string result = await response.Content.ReadAsStringAsync();
            //    await Navigation.PushAsync(new HienThiDSCV());

            //}
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                await DisplayAlert("Thông báo", "Không được để trống tên đăng nhập", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                await DisplayAlert("Thông báo", "Không được để trống mật khẩu", "Ok");
                return;
            }
            char[] a = txtUser.Text.ToCharArray();
            int j = 0;
           for (int i = 0; i < a.Count(); i++)
           {
                if (a[i] == '.')
                {
                    j++;
                }   
                                
           }
           if (j == 1)
           {
                string[] str1 = txtUser.Text.Split('.');
                string str2 = "aits@412";

                if (str1[1] == "aits" && txtPassword.Text == str2)
                {
                    Navigation.PushAsync(new HienThiDSCV());
                }
                else
                {
                    await DisplayAlert("Thông báo", "Mời nhập đúng cú pháp", "OK");
                }
            }    
            else
            {
                await DisplayAlert("Thông báo", "Mời nhập đúng cú pháp", "OK");
            }    
           
                
            

        }

        private void ButtonQuenMatKhau_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QuenMatKhau());
        }
    }
}
