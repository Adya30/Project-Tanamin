using Npgsql;
using System;

namespace Project_Tanamin.app.dbconnect
{
    public class connectdata
    {
        string db_host;
        string db_user;
        string db_pass;
        string db_name;
        public string connstring;

        public connectdata()
        {
            db_host = "localhost";
            db_user = "postgres";
            db_pass = "12345";
            db_name = "ProjectPBO";

            connstring = $"Host={db_host};Username={db_user};Password={db_pass};Database={db_name};";
        }
    }
}
