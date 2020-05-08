using CSFtp_CLI.ftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFtp_CLI
{
    public class HashTableSerialization
    {
        public static void Enter()
        {
            UserData userData = UserData.Get();

            userData.Load();

            if(userData.HasUser("wudi"))
            {
                Console.WriteLine("wudi is existed");
                Console.WriteLine(userData.GetUserPassword("wudi"));
                Console.WriteLine(userData.GetUserStartingDirectory("wudi"));
                return;
            }

            userData.AddUser("wudi");

            userData.SetUserPassword("wudi", "123456");
            userData.SetUserStartingDirectory("wudi", "C:\\test");
            userData.Save();
        }
    }
}
