using Radzen;

namespace ProyectoFinal.Client.Notification;

public static class Notification
{
	public static void ShowNotification(this NotificationService notifier,
		string titulo,
		string mensaje,
		NotificationSeverity severity)
	{
		var message = new NotificationMessage
		{
			Severity = severity,
			Summary = titulo,
			Detail = mensaje,
			Duration = 3000
		};

		notifier.Notify(message);
	}
}