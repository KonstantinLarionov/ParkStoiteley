using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.Configs
{
    public static class ConfigDatabase
    {
        /// <summary>
        /// DONT TOUCH IF DEBUG AND DEVELOP
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return $"Server=localhost;Database={DB};User={UserDB};Password={PasswordDB};";
            }
        }
        /// <summary>
        /// DONT TOUCH IF DEBUG AND DEVELOP
        /// </summary>
        public static readonly string UserDB = "UserPinguin";
        /// <summary>
        /// DONT TOUCH IF DEBUG AND DEVELOP
        /// </summary>
        public static readonly string PasswordDB = "KinderPingui321123";
        /// <summary>
        /// DONT TOUCH IF DEBUG AND DEVELOP
        /// </summary>
        public static readonly string DB = "ParkDB";
    }
}
