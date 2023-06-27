﻿namespace Serdiuk.Cloud.Api.Infrastructure
{
    public class AppData
    {
        public static string Administrator = "Administrator";
        public static string User = "User";

        public static IEnumerable<string> Roles
        {
            get
            {
                yield return Administrator;
                yield return User;
            }
        }
    }
}
