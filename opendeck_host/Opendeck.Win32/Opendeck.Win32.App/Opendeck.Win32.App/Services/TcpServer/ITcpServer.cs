using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Opendeck.Win32.App.Services.TcpServer;

public interface ITcpServer
{
    Task StartListenerAsync();

    Task StopListenerAsync();

    Task<IReadOnlyList<string>> GetConnectedClientsAsync();

    bool GetServerStatus();

    void AddLogger(Action<string> callback);
}
