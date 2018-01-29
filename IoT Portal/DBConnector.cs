using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

// Gebruikte bronnen:
// https://www.codeproject.com/Articles/4416/Beginners-guide-to-accessing-SQL-Server-through-C
// https://www.codeproject.com/Articles/823854/How-to-connect-SQL-Database-to-your-Csharp-program

namespace IoT_Portal
{
    class DBConnector
    {
        SqlConnection connectDatabase;
        SqlCommand sendQuery;

        string table = "FROM ";
        string select = "SELECT ";
/*
        string connectionString = "";
        string userName = "Gilbert";
        string password = "asdf";
        string serverUrl = "localhost";
        string databaseName = "sensortable";
        string trustedConnection = "true";
        string timeout = "30";
        */

        public DBConnector(string _userName = "root", string _password = "wortel", string _serverUrl = "[localhost]", string _databaseName = "[MySQL Router]", string _trustedConnection = "false", string _timeout = "5")
        {
            string connectionString = "";
            string userName = "Gilbert";
            string password = "asdf";
            string serverUrl = "localhost";
            string databaseName = "sensortable";
            string trustedConnection = "true";
            string timeout = "30";

            if (userName != _userName)
            {
                userName = _userName;
            }

            if ( password != _password)
            {
                password = _password;
            }

            if (serverUrl != _serverUrl)
            {
                serverUrl = _serverUrl;
            }

            if (databaseName != _databaseName)
            {
                databaseName = _databaseName;
            }

            if(trustedConnection != _trustedConnection)
            {
                trustedConnection = _trustedConnection;
            }

            if(timeout != _timeout)
            {
                timeout = _timeout;
            }

            connectionString = "user id=" + userName + ";password=" + password + ";server=" + serverUrl + ";Trusted_Connection=" + trustedConnection + ";database=" + databaseName + ";connection timeout=" + timeout;
            connectDatabase = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Opens connection to database. Also opens MessageBox when exeption occurs.
        /// </summary>
        public void OpenDB()
        {
            try
            {
                connectDatabase.Open();
            }

            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void CloseDB()
        {
            connectDatabase.Close();
        }

        /// <summary>
        /// Het lezen van data uit de database
        /// </summary>
        /// <param name="query">query to send to database</param>
        public void SendReadQuery(string query)
        {
            SqlDataReader reader = null;
            sendQuery = new SqlCommand(query, connectDatabase);
            reader = sendQuery.ExecuteReader();
            while (reader.Read())
            {
                //hier moet nog iets komen zo
            }

            sendQuery.ExecuteNonQuery();
        }
    }
}
