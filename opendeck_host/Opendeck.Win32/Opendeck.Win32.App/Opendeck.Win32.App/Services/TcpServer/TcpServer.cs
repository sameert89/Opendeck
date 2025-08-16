using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Opendeck.Win32.App.Services.TcpServer;

internal sealed class TcpServer : ITcpServer
{
    private readonly TcpListener _listener;
    private bool isListenerRunning;
    private int port;
    private CancellationTokenSource cancellationRequest;

    private Action<string> Logger;

    public TcpServer(int port)
    {
        isListenerRunning = false;
        this.port = port;
        _listener = new TcpListener(IPAddress.Any, port);
        cancellationRequest = new CancellationTokenSource();
    }

    public async Task StartListenerAsync()
    {
        if (isListenerRunning)
            return;

        _listener.Start();
        cancellationRequest = new CancellationTokenSource();

        Logger.Invoke("Server Started");

        isListenerRunning = true;

        while (!cancellationRequest.IsCancellationRequested)
        {
            try
            {
                var tcpClient = await _listener.AcceptTcpClientAsync();
                Logger.Invoke($"Client connected: {tcpClient.Client.RemoteEndPoint}");
                _ = Task.Run(() => HandleClientAsync(tcpClient, cancellationRequest.Token));
            }
            catch (Exception ex)
            {
                Logger.Invoke($"Error accepting client: {ex.Message}");
            }
        }
    }

    public Task<IReadOnlyList<string>> GetConnectedClientsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task StopListenerAsync()
    {
        await cancellationRequest.CancelAsync();
        _listener.Stop();
        isListenerRunning = false;
        Logger.Invoke("Server Stopped");
    }

    public bool GetServerStatus() => isListenerRunning;

    private async Task HandleClientAsync(TcpClient client, CancellationToken cancellationToken)
    {
        var clientEndpoint = "Unknown";

        try
        {
            if (client.Client.RemoteEndPoint != null)
                clientEndpoint = client.Client.RemoteEndPoint.ToString();

            Logger.Invoke($"Client connected: {clientEndpoint}");

            using (client)
            await using (var stream = client.GetStream())
            {
                var buffer = new byte[1_024];
                while (!cancellationToken.IsCancellationRequested && client.Connected)
                {
                    try
                    {
                        int bytesRead = await stream.ReadAsync(buffer, cancellationToken);
                        if (bytesRead == 0)
                            break;

                        var message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        Logger.Invoke($"[{client.Client.RemoteEndPoint}]: {message.Trim()}");
                    }
                    catch (IOException)
                    {
                        Logger.Invoke("IO Exception");
                        break;
                    }
                }
            }

            Logger.Invoke($"Client disconnected: {clientEndpoint}");
        }
        catch (Exception ex)
        {
            Logger.Invoke($"Error handling client: {ex.Message}");
        }
    }

    public void AddLogger(Action<string> callback)
    {
        Logger += callback;
    }
}
