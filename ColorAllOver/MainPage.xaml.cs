using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ColorAllOver
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        Random rnd = new Random();
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            for (int i = 0; i < 200; i++)
            {
                GenerateColorsInGridView();
            }
            
        }

        private void GenerateColorsInGridView()
        {
            const byte fullByteValue = 255;
            var color = Color.FromArgb(fullByteValue, GenerateColorByte(), GenerateColorByte(), GenerateColorByte());
            Rectangle rectangleToAdd = new Rectangle { Fill = new SolidColorBrush(color),
                Width = 50,
                Height = 50 };
            ColorsGridView.Items.Add(rectangleToAdd);
        }

        private byte GenerateColorByte()
        {
            return (byte)rnd.Next(0, 256);
        }
    }
}
