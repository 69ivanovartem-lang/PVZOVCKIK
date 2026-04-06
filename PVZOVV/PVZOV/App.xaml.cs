using System.Windows;

namespace PVZOV
{
    public partial class App : Application
    {
        public static class ServerConfig
        {
            // Замени localhost на IP своего сервера, когда выложишь его на хостинг
            public static string ApiUrl { get; set; } = "http://localhost:5000/api";
            public static bool IsMobileMode { get; set; } = false;
        }
    }
}