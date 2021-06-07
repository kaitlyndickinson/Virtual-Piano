using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GUI_Virtual_Piano
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InfoPage : Page
    {
        public InfoPage()
        {
            this.InitializeComponent();
        }

        void CommandBar_Closing(object sender, object e)
         => ((CommandBar)sender).IsOpen = true;

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            if (App.selectedTheme == 1)
            {
                this.Frame.Navigate(typeof(MainPage));
            }
            else
            {
                this.Frame.Navigate(typeof(MainPageLight));
            }
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            if (App.selectedTheme == 1)
            {
                this.Frame.Navigate(typeof(SettingsPage));
            }
            else
            {
                this.Frame.Navigate(typeof(SettingsPageLight));
            }
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            if (App.selectedTheme == 1)
            {
                this.Frame.Navigate(typeof(InfoPage));
            }
            else
            {
                this.Frame.Navigate(typeof(InfoPageLight));
            }
        }
    }
}
