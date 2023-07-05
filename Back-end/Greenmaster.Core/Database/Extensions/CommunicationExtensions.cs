using Greenmaster.Core.Communication.Mail;
using Microsoft.Extensions.DependencyInjection;

namespace Greenmaster.Core.Database.Extensions;

public static class CommunicationExtensions
{
    public static void AddMailingService(this IServiceCollection collection)
    {
        collection.AddSingleton<IMailService>(x => MailService.getInstance());
    }
}