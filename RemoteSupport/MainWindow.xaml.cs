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
  
  public partial class MainWindow : Window
  {
    ScreenRecorder screenRecorder;

    public MainWindow()
    {
      InitializeComponent();
      screenRecorder = new ScreenRecorder();
    }

    private void GetScreenShoot(object sender, RoutedEventArgs e)
    {
      var timer = new System.Timers.Timer();
      timer.Interval = 100;

      timer.Elapsed += OnTimedEvent;
      timer.Enabled = true;
    }

    private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
      this.Dispatcher.Invoke(() =>
      {
        this.ScreenShot.Source = screenRecorder.GetScreenShotOfProcess();
      });
    }
  }
}
