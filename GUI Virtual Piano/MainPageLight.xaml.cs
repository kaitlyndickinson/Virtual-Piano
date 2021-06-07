using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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
    public sealed partial class MainPageLight : Page
    {
        private bool RecordToggle = false;
        private bool PlayToggle = false;
        private bool NewKey = false;
        private int KeyPlayed = 0;
        private Stopwatch PauseTime = new Stopwatch();

        List<int> KeyRecorded = new List<int>();
        List<long> PauseTimeRecorded = new List<long>();

        MediaElement key1 = new MediaElement();
        MediaElement key2 = new MediaElement();
        MediaElement key3 = new MediaElement();
        MediaElement key4 = new MediaElement();
        MediaElement key5 = new MediaElement();
        MediaElement key6 = new MediaElement();
        MediaElement key7 = new MediaElement();
        MediaElement key8 = new MediaElement();
        MediaElement key9 = new MediaElement();
        MediaElement key10 = new MediaElement();
        MediaElement key11 = new MediaElement();
        MediaElement key12 = new MediaElement();
        MediaElement key13 = new MediaElement();
        MediaElement key14 = new MediaElement();
        MediaElement key15 = new MediaElement();
        MediaElement key16 = new MediaElement();
        MediaElement key17 = new MediaElement();
        MediaElement key18 = new MediaElement();
        MediaElement key19 = new MediaElement();
        MediaElement key20 = new MediaElement();
        MediaElement key21 = new MediaElement();
        MediaElement key22 = new MediaElement();
        MediaElement key23 = new MediaElement();
        MediaElement key24 = new MediaElement();
        MediaElement key25 = new MediaElement();

        Windows.Storage.StorageFile key1File;
        Windows.Storage.StorageFile key2File;
        Windows.Storage.StorageFile key3File;
        Windows.Storage.StorageFile key4File;
        Windows.Storage.StorageFile key5File;
        Windows.Storage.StorageFile key6File;
        Windows.Storage.StorageFile key7File;
        Windows.Storage.StorageFile key8File;
        Windows.Storage.StorageFile key9File;
        Windows.Storage.StorageFile key10File;
        Windows.Storage.StorageFile key11File;
        Windows.Storage.StorageFile key12File;
        Windows.Storage.StorageFile key13File;
        Windows.Storage.StorageFile key14File;
        Windows.Storage.StorageFile key15File;
        Windows.Storage.StorageFile key16File;
        Windows.Storage.StorageFile key17File;
        Windows.Storage.StorageFile key18File;
        Windows.Storage.StorageFile key19File;
        Windows.Storage.StorageFile key20File;
        Windows.Storage.StorageFile key21File;
        Windows.Storage.StorageFile key22File;
        Windows.Storage.StorageFile key23File;
        Windows.Storage.StorageFile key24File;
        Windows.Storage.StorageFile key25File;

        bool isUpperKeys = false; // false = play lower keys with keyboard, true = play upper keys

        public MainPageLight()
        {
            this.InitializeComponent();
            loadCurrentlySelectedSampleLibrary("Piano");    // Could Be Piano, Drums, or Bell
            setLabeledPianoKeys("No");                      // Sending "Yes" means show labels, "No" means hide labels
            setLabeledRecordPlayButtons("Yes");             // Sending "Yes" means show labels, "No" means hide labels
            Window.Current.CoreWindow.CharacterReceived += CoreWindow_CharacterReceived;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (App.selectedInstrument != null)
            {
                loadCurrentlySelectedSampleLibrary(App.selectedInstrument);
            }

            if (App.areKeysLabeled != null)
            {
                if (App.areKeysLabeled == "Yes")
                {
                    setLabeledPianoKeys("Yes");
                }
                else
                {
                    setLabeledPianoKeys("No");
                }
            }
        }


        private async void CoreWindow_CharacterReceived(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.CharacterReceivedEventArgs args)
        {

            if (!isUpperKeys)
            {
                if (args.KeyCode == 'a')
                {
                    await playKey_C1();
                }
                else if (args.KeyCode == 'w')
                {
                    await playKey_CSharp1();
                }
                else if (args.KeyCode == 's')
                {
                    await playKey_D1();
                }
                else if (args.KeyCode == 'e')
                {
                    await playKey_DSharp1();
                }
                else if (args.KeyCode == 'd')
                {
                    await playKey_E1();
                }
                else if (args.KeyCode == 'f')
                {
                    await playKey_F1();
                }
                else if (args.KeyCode == 't')
                {
                    await playKey_FSharp1();
                }
                else if (args.KeyCode == 'g')
                {
                    await playKey_G1();
                }
                else if (args.KeyCode == 'y')
                {
                    await playKey_GSharp1();
                }
                else if (args.KeyCode == 'h')
                {
                    await playKey_A2();
                }
                else if (args.KeyCode == 'u')
                {
                    await playKey_ASharp2();
                }

                else if (args.KeyCode == 'j')
                {
                    await playKey_B2();
                }
                else if (args.KeyCode == 'k')
                {
                    await playKey_C2();
                }
                else if (args.KeyCode == 'o')
                {
                    await playKey_CSharp2();
                }
                else if (args.KeyCode == 'l')
                {
                    await playKey_D2();
                }
                else if (args.KeyCode == 'p')
                {
                    await playKey_DSharp2();
                }
                else if (args.KeyCode == ';')
                {
                    await playKey_E2();
                }
                // Map Keys To Lower Scale
                else if (args.KeyCode == 'z')
                {
                    isUpperKeys = false;
                }
                // Map Keys To Upper Scale
                else if (args.KeyCode == 'x')
                {
                    isUpperKeys = true;
                }
            }

            else
            {
                if (args.KeyCode == 'a')
                {
                    await playKey_A2();
                }
                else if (args.KeyCode == 'w')
                {
                    await playKey_ASharp2();
                }
                else if (args.KeyCode == 's')
                {
                    await playKey_B2();
                }
                else if (args.KeyCode == 'd')
                {
                    await playKey_C2();
                }
                else if (args.KeyCode == 'r')
                {
                    await playKey_CSharp2();
                }
                else if (args.KeyCode == 'f')
                {
                    await playKey_D2();
                }
                else if (args.KeyCode == 't')
                {
                    await playKey_DSharp2();
                }
                else if (args.KeyCode == 'g')
                {
                    await playKey_E2();
                }
                else if (args.KeyCode == 'h')
                {
                    await playKey_F2();
                }
                else if (args.KeyCode == 'u')
                {
                    await playKey_FSharp2();
                }

                else if (args.KeyCode == 'j')
                {
                    await playKey_G2();
                }
                else if (args.KeyCode == 'i')
                {
                    await playKey_GSharp2();
                }
                else if (args.KeyCode == 'k')
                {
                    await playKey_A3();
                }
                else if (args.KeyCode == 'o')
                {
                    await playKey_ASharp3();
                }
                else if (args.KeyCode == 'l')
                {
                    await playKey_B3();
                }
                else if (args.KeyCode == ';')
                {
                    await playKey_C3();
                }
                // Map Keys To Lower Scale
                else if (args.KeyCode == 'z')
                {
                    isUpperKeys = false;
                }
                // Map Keys To Upper Scale
                else if (args.KeyCode == 'x')
                {
                    isUpperKeys = true;
                }
            }
        }

        private async System.Threading.Tasks.Task playKey_C1()
        {
            var stream = await key1File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key1.SetSource(stream, key1File.ContentType);
            key1.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(1, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(1, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_CSharp1()
        {
            var stream = await key2File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key2.SetSource(stream, key2File.ContentType);
            key2.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(2, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(2, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }
        async System.Threading.Tasks.Task playKey_D1()
        {
            var stream = await key3File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key3.SetSource(stream, key3File.ContentType);
            key3.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(3, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(3, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_DSharp1()
        {
            var stream = await key4File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key4.SetSource(stream, key4File.ContentType);
            key4.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(4, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(4, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_E1()
        {
            var stream = await key5File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key5.SetSource(stream, key5File.ContentType);
            key5.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(5, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(5, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_F1()
        {
            var stream = await key6File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key6.SetSource(stream, key6File.ContentType);
            key6.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(6, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(6, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_FSharp1()
        {
            var stream = await key7File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key7.SetSource(stream, key7File.ContentType);
            key7.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(7, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(7, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_G1()
        {
            var stream = await key8File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key8.SetSource(stream, key8File.ContentType);
            key8.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(8, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(8, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_GSharp1()
        {
            var stream = await key9File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key9.SetSource(stream, key9File.ContentType);
            key9.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(9, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(9, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_A2()
        {
            var stream = await key10File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key10.SetSource(stream, key10File.ContentType);
            key10.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(10, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(10, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_ASharp2()
        {
            var stream = await key11File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key11.SetSource(stream, key11File.ContentType);
            key11.Play();

            if (RecordToggle == true)
            {
                if (PauseTime.IsRunning && PlayToggle == false)
                {
                    PauseTime.Stop();
                    Record(11, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(11, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_B2()
        {
            var stream = await key12File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key12.SetSource(stream, key12File.ContentType);
            key12.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(12, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(12, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_C2()
        {
            var stream = await key13File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key13.SetSource(stream, key13File.ContentType);
            key13.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(13, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(13, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_CSharp2()
        {
            var stream = await key14File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key14.SetSource(stream, key14File.ContentType);
            key14.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(14, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(14, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_D2()
        {
            var stream = await key15File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key15.SetSource(stream, key15File.ContentType);
            key15.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(15, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(15, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_DSharp2()
        {
            var stream = await key16File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key16.SetSource(stream, key16File.ContentType);
            key16.Play();

            if (RecordToggle == true)
            {
                if (PauseTime.IsRunning && PlayToggle == false)
                {
                    PauseTime.Stop();
                    Record(16, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(16, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_E2()
        {
            var stream = await key17File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key17.SetSource(stream, key17File.ContentType);
            key17.Play();

            if (RecordToggle == true)
            {
                if (PauseTime.IsRunning && PlayToggle == false)
                {
                    PauseTime.Stop();
                    Record(17, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(17, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_F2()
        {
            var stream = await key18File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key18.SetSource(stream, key18File.ContentType);
            key18.Play();

            if (RecordToggle == true)
            {
                if (PauseTime.IsRunning && PlayToggle == false)
                {
                    PauseTime.Stop();
                    Record(18, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(18, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_FSharp2()
        {
            var stream = await key19File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key19.SetSource(stream, key19File.ContentType);
            key19.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(19, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(19, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_G2()
        {
            var stream = await key20File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key20.SetSource(stream, key20File.ContentType);
            key20.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(20, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(20, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_GSharp2()
        {
            var stream = await key21File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key21.SetSource(stream, key21File.ContentType);
            key21.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(21, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(21, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_A3()
        {
            var stream = await key22File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key22.SetSource(stream, key22File.ContentType);
            key22.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(22, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(22, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_ASharp3()
        {
            var stream = await key23File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key23.SetSource(stream, key23File.ContentType);
            key23.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(23, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(23, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_B3()
        {
            var stream = await key24File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key24.SetSource(stream, key24File.ContentType);
            key24.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(24, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(24, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        async System.Threading.Tasks.Task playKey_C3()
        {
            var stream = await key25File.OpenAsync(Windows.Storage.FileAccessMode.Read);
            key25.SetSource(stream, key25File.ContentType);
            key25.Play();

            if (RecordToggle == true && PlayToggle == false)
            {
                if (PauseTime.IsRunning)
                {
                    PauseTime.Stop();
                    Record(25, PauseTime.ElapsedMilliseconds);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
                else
                {
                    Record(25, 0);
                    PauseTime.Reset();
                    PauseTime.Start();
                }
            }
        }

        private async void loadCurrentlySelectedSampleLibrary(string library)
        {
            Windows.Storage.StorageFolder samplesFolder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Samples");
            Windows.Storage.StorageFolder pianoFolder = await samplesFolder.GetFolderAsync(library);
            key1File = await pianoFolder.GetFileAsync("Key_1.wav");
            key2File = await pianoFolder.GetFileAsync("Key_2.wav");
            key3File = await pianoFolder.GetFileAsync("Key_3.wav");
            key4File = await pianoFolder.GetFileAsync("Key_4.wav");
            key5File = await pianoFolder.GetFileAsync("Key_5.wav");
            key6File = await pianoFolder.GetFileAsync("Key_6.wav");
            key7File = await pianoFolder.GetFileAsync("Key_7.wav");
            key8File = await pianoFolder.GetFileAsync("Key_8.wav");
            key9File = await pianoFolder.GetFileAsync("Key_9.wav");
            key10File = await pianoFolder.GetFileAsync("Key_10.wav");
            key11File = await pianoFolder.GetFileAsync("Key_11.wav");
            key12File = await pianoFolder.GetFileAsync("Key_12.wav");
            key13File = await pianoFolder.GetFileAsync("Key_13.wav");
            key14File = await pianoFolder.GetFileAsync("Key_14.wav");
            key15File = await pianoFolder.GetFileAsync("Key_15.wav");
            key16File = await pianoFolder.GetFileAsync("Key_16.wav");
            key17File = await pianoFolder.GetFileAsync("Key_17.wav");
            key18File = await pianoFolder.GetFileAsync("Key_18.wav");
            key19File = await pianoFolder.GetFileAsync("Key_19.wav");
            key20File = await pianoFolder.GetFileAsync("Key_20.wav");
            key21File = await pianoFolder.GetFileAsync("Key_21.wav");
            key22File = await pianoFolder.GetFileAsync("Key_22.wav");
            key23File = await pianoFolder.GetFileAsync("Key_23.wav");
            key24File = await pianoFolder.GetFileAsync("Key_24.wav");
            key25File = await pianoFolder.GetFileAsync("Key_25.wav");
        }

        private async void setLabeledRecordPlayButtons(string command)
        {

            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => {
                if (command.Equals("Yes"))
                {
                    this.RecordTextBlock.Text = "Record";
                    this.PlayTextBlock.Text = "Play";
                }
                else if (command.Equals("No"))
                {
                    string blank = "";
                    this.RecordTextBlock.Text = blank;
                    this.PlayTextBlock.Text = blank;
                }
            });
        }

        private async void setLabeledPianoKeys(string command)
        {

            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => {
                if (command.Equals("Yes"))
                {
                    this.C1.Content = "C1";
                    this.C_Sharp1.Content = "C#1\nD♭1";
                    this.D1.Content = "D1";
                    this.D_Sharp1.Content = "D#1\nE♭1";
                    this.E1.Content = "E1";
                    this.F1.Content = "F1";
                    this.F_Sharp1.Content = "F#1\nG♭1";
                    this.G1.Content = "G1";
                    this.G_Sharp1.Content = "G#1\nA♭2";

                    this.A2.Content = "A2";
                    this.A_Sharp2.Content = "A#2\nB♭2";
                    this.B2.Content = "B2";
                    this.C2.Content = "C2";
                    this.C_Sharp2.Content = "C#2\nD♭2";
                    this.D2.Content = "D2";
                    this.D_Sharp2.Content = "D#2\nE♭2";
                    this.E2.Content = "E2";
                    this.F2.Content = "F2";
                    this.F_Sharp2.Content = "F#2\nG♭2";
                    this.G2.Content = "G2";
                    this.G_Sharp2.Content = "G#2\nA♭3";

                    this.A3.Content = "A3";
                    this.A_Sharp3.Content = "A#3\nB♭3";
                    this.B3.Content = "B3";
                    this.C3.Content = "C3";
                }
                else if (command.Equals("No"))
                {
                    string blank = "";
                    this.C1.Content = blank;
                    this.C_Sharp1.Content = blank;
                    this.D1.Content = blank;
                    this.D_Sharp1.Content = blank;
                    this.E1.Content = blank;
                    this.F1.Content = blank;
                    this.F_Sharp1.Content = blank;
                    this.G1.Content = blank;
                    this.G_Sharp1.Content = blank;

                    this.A2.Content = blank;
                    this.A_Sharp2.Content = blank;
                    this.B2.Content = blank;
                    this.C2.Content = blank;
                    this.C_Sharp2.Content = blank;
                    this.D2.Content = blank;
                    this.D_Sharp2.Content = blank;
                    this.E2.Content = blank;
                    this.F2.Content = blank;
                    this.F_Sharp2.Content = blank;
                    this.G2.Content = blank;
                    this.G_Sharp2.Content = blank;

                    this.A3.Content = blank;
                    this.A_Sharp3.Content = blank;
                    this.B3.Content = blank;
                    this.C3.Content = blank;
                }
            });

        }

        private async void PlayPause_Checked(object sender, RoutedEventArgs e)
        {
            if (RecordToggle == false)
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    this.playTriangle.Stroke = Application.Current.Resources["playTriangle_Active"] as SolidColorBrush;
                });
                PlayToggle = true;
                Play();
            }
            else
            {
                Play_BTN.IsChecked = false;
            }
        }

        private async void PlayPaused_Unchecked(object sender, RoutedEventArgs e)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => {
                this.playTriangle.Stroke = Application.Current.Resources["playTriangle_Stopped"] as SolidColorBrush;
            });
            PlayToggle = false;
        }

        private async void Record_Checked(object sender, RoutedEventArgs e)
        {
            if (PlayToggle == false)
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    this.Record_BTN.Background = Application.Current.Resources["playTriangle_Active"] as SolidColorBrush;
                });
                KeyRecorded.Clear();
                PauseTimeRecorded.Clear();
                RecordToggle = true;
            }
            else
            {
                Record_BTN.IsChecked = false;
            }
        }

        private async void Record_Unchecked(object sender, RoutedEventArgs e)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => {
                this.Record_BTN.Background = Application.Current.Resources["playTriangle_Stopped"] as SolidColorBrush;
            });
            RecordToggle = false;
            PauseTime.Stop();
            PauseTime.Reset();
        }

        void Record(int key, long pause)
        {
            KeyRecorded.Add(key);
            PauseTimeRecorded.Add(pause);
        }

        async void Play()
        {
            while (PlayToggle == true)
            {
                for (int i = 0; i < KeyRecorded.Count; i++)
                {
                    Thread.Sleep((int)PauseTimeRecorded[i]);
                    switch (KeyRecorded[i])
                    {
                        case 1:
                            await playKey_C1();
                            break;
                        case 2:
                            await playKey_CSharp1();
                            break;
                        case 3:
                            await playKey_D1();
                            break;
                        case 4:
                            await playKey_DSharp1();
                            break;
                        case 5:
                            await playKey_E1();
                            break;
                        case 6:
                            await playKey_F1();
                            break;
                        case 7:
                            await playKey_FSharp1();
                            break;
                        case 8:
                            await playKey_G1();
                            break;
                        case 9:
                            await playKey_GSharp1();
                            break;
                        case 10:
                            await playKey_A2();
                            break;
                        case 11:
                            await playKey_ASharp2();
                            break;
                        case 12:
                            await playKey_B2();
                            break;
                        case 13:
                            await playKey_C2();
                            break;
                        case 14:
                            await playKey_CSharp2();
                            break;
                        case 15:
                            await playKey_D2();
                            break;
                        case 16:
                            await playKey_DSharp2();
                            break;
                        case 17:
                            await playKey_E2();
                            break;
                        case 18:
                            await playKey_F2();
                            break;
                        case 19:
                            await playKey_FSharp2();
                            break;
                        case 20:
                            await playKey_G2();
                            break;
                        case 21:
                            await playKey_GSharp2();
                            break;
                        case 22:
                            await playKey_A3();
                            break;
                        case 23:
                            await playKey_ASharp3();
                            break;
                        case 24:
                            await playKey_B3();
                            break;
                        case 25:
                            await playKey_C3();
                            break;

                        default:
                            break;
                    }
                }
                PlaybackFinished();
            }
        }

        void PlaybackFinished()
        {
            PlayToggle = false;
            Play_BTN.IsChecked = false;
        }

        private async void C1_Click(object sender, RoutedEventArgs e)
        {
            await playKey_C1();
        }

        private async void C_Sharp1_Click(object sender, RoutedEventArgs e)
        {
            await playKey_CSharp1();
        }

        private async void D1_Click(object sender, RoutedEventArgs e)
        {
            await playKey_D1();
        }

        private async void D_Sharp1_Click(object sender, RoutedEventArgs e)
        {
            await playKey_DSharp1();
        }

        private async void E1_Click(object sender, RoutedEventArgs e)
        {
            await playKey_E1();
        }

        private async void F1_Click(object sender, RoutedEventArgs e)
        {
            await playKey_F1();
        }

        private async void F_Sharp1_Click(object sender, RoutedEventArgs e)
        {
            await playKey_FSharp1();
        }

        private async void G1_Click(object sender, RoutedEventArgs e)
        {
            await playKey_G1();
        }

        private async void G_Sharp1_Click(object sender, RoutedEventArgs e)
        {
            await playKey_GSharp1();
        }

        private async void A2_Click(object sender, RoutedEventArgs e)
        {
            await playKey_A2();
        }

        private async void A_Sharp2_Click(object sender, RoutedEventArgs e)
        {
            await playKey_ASharp2();
        }

        private async void B2_Click(object sender, RoutedEventArgs e)
        {
            await playKey_B2();
        }

        private async void C2_Click(object sender, RoutedEventArgs e)
        {
            await playKey_C2();
        }

        private async void C_Sharp2_Click(object sender, RoutedEventArgs e)
        {
            await playKey_CSharp2();
        }

        private async void D2_Click(object sender, RoutedEventArgs e)
        {
            await playKey_D2();
        }

        private async void D_Sharp2_Click(object sender, RoutedEventArgs e)
        {
            await playKey_DSharp2();
        }

        private async void E2_Click(object sender, RoutedEventArgs e)
        {
            await playKey_E2();
        }

        private async void F2_Click(object sender, RoutedEventArgs e)
        {
            await playKey_F2();
        }

        private async void F_Sharp2_Click(object sender, RoutedEventArgs e)
        {
            await playKey_FSharp2();
        }

        private async void G2_Click(object sender, RoutedEventArgs e)
        {
            await playKey_G2();
        }

        private async void G_Sharp2_Click(object sender, RoutedEventArgs e)
        {
            await playKey_GSharp2();
        }

        private async void A3_Click(object sender, RoutedEventArgs e)
        {
            await playKey_A3();
        }

        private async void A_Sharp3_Click(object sender, RoutedEventArgs e)
        {
            await playKey_ASharp3();
        }

        private async void B3_Click(object sender, RoutedEventArgs e)
        {
            await playKey_B3();
        }


        private async void C3_Click(object sender, RoutedEventArgs e)
        {
            await playKey_C3();
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
