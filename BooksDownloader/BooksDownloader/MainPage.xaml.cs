using Android.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using DownloadManager;
using Android.OS;
using Android.Content.PM;
using Android;
using NuGet;
using Xamarin.Essentials;

namespace BooksDownloader
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

    private void Bottone_Pressed(object sender, EventArgs e)
        {
            var autorelibro = autore.Text;
            var titololibro = titolo.Text;
            var libroautore = titololibro + "-" + autorelibro;
            var link = $"https://dwnlg.link/book-n/{autorelibro}/{libroautore}/{titololibro}.pdf";
            getFile(link, titololibro,autorelibro);

        }

        //non capisco
        public void getFile(string link, string titololibro, string autorelibro)
        {
            //dichiara la directory
            string dir = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryDownloads);

            try
            {
                //dio can poco fa compilava
                Console.WriteLine(link);
                Console.WriteLine(dir);
                WebClient webClient = new WebClient();
                webClient.DownloadFile(link, $"{dir}/{titololibro}.pdf");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
