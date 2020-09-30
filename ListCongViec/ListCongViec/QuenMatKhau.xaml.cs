using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListCongViec
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuenMatKhau : ContentPage
    {
        public QuenMatKhau()
        {
            InitializeComponent();
        }

        async void ButtonXacNhan_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Thông báo", "Bạn có chắc chắn muốn đổi thành mật khẩu mới này?", "Yes","No ");
            Debug.WriteLine("Answer: " + answer);
            if (answer == true)
            {
                await DisplayAlert("Thông báo", "Thay đổi mật khẩu thành công!", "OK");
                await Navigation.PushAsync(new MainPage());
            }    
        }

        private void ButtonHuy_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}