using Lime.SplashScreen;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lime
{
    // <summary>
    // Logique d'interaction pour App.xaml
    // </summary>  
    public partial class App : Application
    {

        public SplashScreenLoading SplashScreen;
        public App()
        {
            this.MainWindow = new MainWindow();

            this.SplashScreen = new SplashScreenLoading(@"./Images/settings.png");
            this.SplashScreen.Show();
        }

        //Source : https://programmezendotnet.wordpress.com/2014/03/03/un-splashscreen-evolue-en-wpf/

        //protected override async void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);

        //    // Longest loading
        //    await this.LongLoading();

        //    this.MainWindow.Show();

        //    // Shortest loading
        //    await this.ShortLoading();

        //    this.SplashScreen.Close();
        //    this.SplashScreen = null;
        //}

        public async Task LongLoading()
        {
            this.SplashScreen.SetProgress("Etape 1 sur 4", 0, 4);
            await Task.Delay(1250);

            this.SplashScreen.SetProgress("Etape 2 sur 4", 1, 4);
            await Task.Delay(1250);

            this.SplashScreen.SetProgress("Etape 3 sur 4", 2, 4);
            await Task.Delay(1250);
        }

        public async Task ShortLoading()
        {
            this.SplashScreen.SetProgress("Etape 4 sur 4", 3, 4);
            await Task.Delay(1750);
        }


    }



}
