using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testvswinform.Sql
{
    public class User
    {
        public static string LOGIN = "select * from user where name=@name and password=@password";
    }
}
