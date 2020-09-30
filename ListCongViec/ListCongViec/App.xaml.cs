using System;
using System.IO.Pipes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListCongViec
{
    public partial class App : Application
    {
        public NavigationPage HienThiDSCV;
        public NavigationPage QuenMatKhau;
        public NavigationPage ThemMoi;
        public NavigationPage HienThiChiTietCV;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            HienThiDSCV = new NavigationPage(new HienThiDSCV());
            QuenMatKhau = new NavigationPage(new QuenMatKhau());
            ThemMoi = new NavigationPage(new ThemMoi());
            CongViec cv = null;
            HienThiChiTietCV = new NavigationPage(new HienThiChiTietCV(cv));
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
