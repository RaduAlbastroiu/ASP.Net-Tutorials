using System.Drawing;
using System.Windows;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices;

namespace RemoteSupport
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  /// 
  class User32
  {
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
      public int left;
      public int top;
      public int right;
      public int bottom;
    }

    [DllImport("user32.dll")]
    public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
  }

  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void GetScreenShoot(object sender, RoutedEventArgs e)
    {
      var proc = System.Diagnostics.Process.GetProcessesByName("advinst")[0];
      var rect = new User32.Rect();
      User32.GetWindowRect(proc.MainWindowHandle, ref rect);

      int width = rect.right - rect.left;
      int height = rect.bottom - rect.top;

      var bmp = new Bitmap(width, height);
      Graphics graphics = Graphics.FromImage(bmp);
      graphics.CopyFromScreen(rect.left, rect.top, 0, 0, new System.Drawing.Size(width, height), CopyPixelOperation.SourceCopy);

      this.ScreenShot.Source = BitmapToImageSource(bmp);
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
