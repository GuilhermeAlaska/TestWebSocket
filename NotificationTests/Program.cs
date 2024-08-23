using Microsoft.AspNetCore.SignalR.Client;

var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7222/notificationHub")
                .Build();

connection.On<Notification>("ReceiveNotification", (notification) =>
{
    Console.WriteLine($"Notificação recebida: {notification.Text}");
});

try
{
    await connection.StartAsync();
    Console.WriteLine("Conectado ao Hub de Notificações.");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao conectar ao Hub: {ex.Message}");
}

Console.WriteLine("Pressione qualquer tecla para sair.");
Console.ReadKey();

await connection.StopAsync();



public class Notification
{
    public string Text { get; set; }

    public Notification(string text)
    {
        Text = text;
    }
}