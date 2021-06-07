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
    public sealed partial class SettingsPage : Page
    {

        public SettingsPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }
        private void ThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ThemeComboBox.SelectedIndex.Equals(0)) // Dark theme
            {
                App.selectedTheme = 1;
                this.Frame.Navigate(typeof(MainPage));
            }
            else // Light theme
            {
                App.selectedTheme = 2;
                this.Frame.Navigate(typeof(MainPageLight));
            }

        }

        private void InstrumentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InstrumentComboBox.SelectedIndex.Equals(0)) // Piano
            {
                App.selectedInstrument = "Piano";
            }
            else if (InstrumentComboBox.SelectedIndex.Equals(1)) // Drums
            {
                App.selectedInstrument = "Drums";
            }
            else // Bells
            {
                App.selectedInstrument = "Bell";
            }
        }

        private void VolumeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
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

        private void KeyNotesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (KeyNotesComboBox.SelectedIndex.Equals(0)) // Key Notes On
            {
                App.areKeysLabeled = "Yes";
            }
            else // Key Notes Off
            {
                App.areKeysLabeled = "No";
            }
        }
    }
}