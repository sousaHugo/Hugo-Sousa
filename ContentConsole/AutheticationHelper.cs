using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class AutheticationHelper
    {
        public class DummyUsernames
        {

            public const string MyUser = "MYUSER";
            public const string MyAdmin = "MYADMIN";
            public const string MyReader = "MYREADER";
            public const string MyCurator = "MYCURATOR";

        }
        public static string Login(string username)
        {
            switch (username.ToUpper())
            {
                case DummyUsernames.MyAdmin:
                    return Role.Administrator;
                case DummyUsernames.MyCurator:
                    return Role.ContentCurator;
                case DummyUsernames.MyReader:
                    return Role.Reader;
                case DummyUsernames.MyUser:
                    return Role.User;
                default:
                    return Role.NoRole;
            }
        }
    }
}
