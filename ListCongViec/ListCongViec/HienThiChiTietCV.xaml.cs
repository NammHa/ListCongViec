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
    public partial class HienThiChiTietCV : ContentPage
    {
        public HienThiChiTietCV(CongViec cv)
        {
            InitializeComponent();
            ChiTietDSCV();
            //OnAdd();
        }
        public async void ChiTietDSCV()
        {
            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslpolicyerrors) => { return true; };
            HttpClient client = new HttpClient(clienthandler);

            //////httpclient client = new httpclient();

            var response = await client.GetAsync("https://qlcv-api.conveyor.cloud/api/GetListCV");
            string listcvjson = await response.Content.ReadAsStringAsync();
            listCV cvobj = new listCV();
            cvobj = JsonConvert.DeserializeObject<listCV>(listcvjson);
            LV.ItemsSource = cvobj.DATA;
        }



        //private const string URL = "https://qlcv-api.conveyor.cloud/api/GetCVById";
        //public HttpClient _client = new HttpClient();

        //async void OnAdd(object sender, System.EventArgs e)
        //{
        //    var post = new CongViec();
        //    var content = JsonConvert.SerializeObject(post);
        //    await _client.PostAsync(URL, new StringContent(content));
        //}
    }

}