using Opendeck.Win32.App.Models;
using System.Threading.Tasks;

namespace Opendeck.Win32.App.Services.MessageRouter;

internal interface IMessageRouter
{
    /// <summary>
    /// Routes message to one of the registered handlers
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    Task RouteMessageAsync(Message message);
}
