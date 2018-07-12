using System;

namespace BrSoftNet.App.UI.Win.Security.State
{
    public static class AppStateSession
    {
        public static string IdSession { get; set; }
        public static DateTime DateTimeSession { get; set; }
        public static string MachineName { get; set; }
        public static string MachineIP { get; set; }
        public static int LogonNumber { get; set; }
    }
}
