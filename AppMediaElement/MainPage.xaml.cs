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


namespace AppMediaElement
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            myControl.Source = new Uri("ms-appx:///Assets/Sounds/Phone_Ring.wav", UriKind.RelativeOrAbsolute);
            myControl.AutoPlay = true;
            myControl.Volume = 0.5;
            myControl.Play();
        }

        private void Play_Button_Click(object sender, RoutedEventArgs e)
        {

            myControl.Play();
        }

        private void Pause_Button_Click(object sender, RoutedEventArgs e)
        {
            myControl.Pause();
        }

        private void Stop_Button_Click(object sender, RoutedEventArgs e)
        {
            myControl.Stop();
        }

        private MediaState state = MediaState.Stopped;

        private void PayVideo_Button_Click(object sender, RoutedEventArgs e)
        {
            //myControl.Source = new Uri("ms-appx:///Assets/Videos/Toystory.mp4", UriKind.RelativeOrAbsolute);
            //myControl.Play();

            if (state == MediaState.Stopped)
            {
                myControl.Source = new Uri("ms-appx:///Assets/Videos/Toystory.mp4", UriKind.RelativeOrAbsolute);
                state = MediaState.Playing;
                myControl.Play();
            }
            else if (state == MediaState.Playing)
            {
                state = MediaState.Paused;
                myControl.Pause();
            }
            else if (state == MediaState.Paused)
            {
                state = MediaState.Playing;
                myControl.Play();
            }
        }

        public enum MediaState
        {
            Stopped,
            Playing,
            Paused
        }

        private void myControl_Ended(object sender, RoutedEventArgs e)
        {
            state = MediaState.Stopped;
        }
    }
}
