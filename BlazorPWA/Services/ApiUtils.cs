using BoleteriaOnline.Core.Utils;
using Radzen;

namespace BlazorPWA.Services;
public static class ApiUtils<T> where T : class
{
    public static void NotifyResponse(NotificationService notificationService, WebResult<T> response, Action func)
    {
        notificationService.Notify(new NotificationMessage() { Severity = response.Success ? NotificationSeverity.Success : NotificationSeverity.Error, Summary = response.Message, Duration = 3000 });
        if (!response.Success)
        {
            foreach (var error in response.ErrorMessages)
            {
                foreach (var validation in error.Value)
                {
                    notificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = validation, Duration = 3000 });
                }
            }
        }
        else
        {
            func();
        }
    }

}
