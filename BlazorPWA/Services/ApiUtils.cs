using BoleteriaOnline.Core.Utils;
using Radzen;

namespace BlazorPWA.Services;
public static class ApiService<T> where T : class
{
    public static void NotifyResponse(NotificationService notificationService, WebResult<T> response, Action successAction)
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
            successAction();
        }
    }

    public static void ShowErrors(NotificationService notificationService, WebResult<T> response)
    {
        foreach (var error in response.ErrorMessages)
        {
            foreach (var validation in error.Value)
            {
                notificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = validation, Duration = 3000 });
            }
        }
    }

}
