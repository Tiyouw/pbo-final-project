﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Npgsql;

//namespace Tugas_Akhir_PBO.DB
//{
//    internal class DBConnection : IDisposable
//    {
//        private readonly string _connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=310305;Database=BonsaRental";
//        private NpgsqlConnection _connection;

//        public NpgsqlConnection Connection
//        {
//            get
//            {
//                if (_connection == null)
//                {
//                    _connection = new NpgsqlConnection(_connectionString);
//                }
//                return _connection;
//            }
//        }

//        public void Open()
//        {
//            if (_connection == null)
//            {
//                _connection = new NpgsqlConnection(_connectionString);
//            }
//            if (_connection.State != System.Data.ConnectionState.Open)
//            {
//                _connection.Open();
//            }
//        }

//        public void Close()
//        {
//            if (_connection != null && _connection.State != System.Data.ConnectionState.Closed)
//            {
//                _connection.Close();
//            }
//        }

//        public void Dispose()
//        {
//            Close();
//            if (_connection != null)
//            {
//                _connection.Dispose();
//                _connection = null;
//            }
//        }
//    }
//}

