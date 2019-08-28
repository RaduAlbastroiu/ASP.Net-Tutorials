using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestStack.White;

namespace RemoteSupport
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void GetScreenShoot(object sender, RoutedEventArgs e)
    {
      ScreenCapture sc = new ScreenCapture();

      var screenCapture = sc.CaptureScreenShot();
      var screenCaptureSource = BitmapToImageSource(screenCapture);

      this.ScreenShot.Source = screenCaptureSource;
    }

    private BitmapImage BitmapToImageSource(Bitmap bitmap)
    {
      using (System.IO.MemoryStream memory = new System.IO.MemoryStream())
      {
        bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
        memory.Position = 0;
        BitmapImage bitmapimage = new BitmapImage();
        bitmapimage.BeginInit();
        bitmapimage.StreamSource = memory;
        bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapimage.EndInit();

        return bitmapimage;
      }
    }
  }
}
