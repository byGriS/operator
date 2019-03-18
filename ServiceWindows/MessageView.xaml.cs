using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ServiceWindows {
  public partial class MessageView : Window {
    public MessageView(string message, string caption, MessageViewMode mode, bool autoClose = true) {
      InitializeComponent();
      this.Title = caption;
      textBlock.Text = message;
      if (mode == MessageViewMode.Message) {
        btn.Visibility = Visibility.Collapsed;
        System.Timers.Timer timer = new System.Timers.Timer(2000);
        timer.AutoReset = false;
        timer.Elapsed += Timer_Elapsed;
        timer.Enabled = autoClose;
      }
      switch (mode) {
        case MessageViewMode.Message:
          image.Source = new BitmapImage(new Uri("Resources/Message.png", UriKind.Relative));
          break;
        case MessageViewMode.Attention:
          image.Source = new BitmapImage(new Uri("Resources/Attention.png", UriKind.Relative));
          break;
        case MessageViewMode.Error:
          image.Source = new BitmapImage(new Uri("Resources/Error.png", UriKind.Relative));
          break;
      }
    }

    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
      Application.Current.Dispatcher.Invoke((Action)(() => {
        this.Close();
      }));
    }

    private void Close_Click(object sender, RoutedEventArgs e) {
      this.Close();
    }
  }

  public enum MessageViewMode {
    Error = 0,
    Message = 1,
    Attention = 2
  }
}
