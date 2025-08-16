using Opendeck.Win32.App.Handlers;
using Opendeck.Win32.App.Models;
using System.Threading.Tasks;

namespace Opendeck.Win32.App.Services.MessageRouter;

internal sealed class MessageRouter : IMessageRouter
{
    private readonly LaunchProgram _launchProgramHandler;
    private readonly ExecuteKeystroke _executeKeyStrokeHandler;

    public async Task RouteMessageAsync(Message message) => await (message.Topic switch
    {
        Topic.LaunchProgram => _launchProgramHandler.HandleAsync(message.Payload),
        Topic.ExecuteKeystroke => _executeKeyStrokeHandler.HandleAsync(message.Payload),
        _ => throw new System.NotImplementedException()
    });
}
