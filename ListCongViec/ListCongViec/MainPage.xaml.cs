using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListCongViec
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HienThiDSCV());
        }

        private void ButtonQuenMatKhau_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QuenMatKhau());
        }
    }
}
