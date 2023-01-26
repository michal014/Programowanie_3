using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Tests
{
    internal class DBSelect : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        string connectionString;
        SqlConnection connection;
        SqlCommand command;
        string sql;
        SqlDataAdapter dataAdapter;
        DataTable dataTable = new DataTable();

        public DataTable SelectAccess
        {
            get
            {
                return dataTable;
            }
            set
            {
                dataTable = value;
                OnPropertyChanged("SelectAccess");
            }
        }

        public DBSelect(string connectionString, string sql)
        {
            this.connectionString = connectionString;
            connection = new SqlConnection(connectionString);
            this.sql = sql;
            command = new SqlCommand(sql, connection);
            dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);
        }

    }
}
