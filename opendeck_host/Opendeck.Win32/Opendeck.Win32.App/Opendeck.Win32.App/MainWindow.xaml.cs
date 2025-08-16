using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Opendeck.Win32.App.Extensions;
using Opendeck.Win32.App.Services.TcpServer;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Opendeck.Win32.App
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private readonly ITcpServer _tcpServer;

        public MainWindow()
        {
            InitializeComponent();
            _tcpServer = new TcpServer(9876);
            serviceToggleProgress.IsActive = false;
            _tcpServer.AddLogger(AppendToDebugTextbox);
        }

        private async void ToggleSwitch_Toggled(object sender, RoutedEventArgs _)
        {
            ToggleSwitch? toggleSwitch = sender as ToggleSwitch;

            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    await _tcpServer.StartListenerAsync();
                }
                else
                {
                    serviceToggleProgress.Show();
                    await _tcpServer.StopListenerAsync();
                    serviceToggleProgress.Hide();
                }
            }
        }

        private void AppendToDebugTextbox(string message)
        {
            DispatcherQueue.TryEnqueue(() =>
            {
                if (debug.Text == "Debug output will appear here...")
                {
                    debug.Text = "";
                }
                var timestampedMessage = $"[{DateTime.Now:HH:mm:ss}] {message}\n";
                debug.Text += timestampedMessage;

                if (debug.Text.Length > 1000)
                {
                    var text = debug.Text;
                    var cutPoint = text.Length - 800;
                    var newlineIndex = text.IndexOf('\n', cutPoint);
                    if (newlineIndex > 0)
                        cutPoint = newlineIndex + 1;
                    debug.Text = text.Substring(cutPoint);
                }

                debug.Select(debug.Text.Length, 0);
            });
        }
    }
}
