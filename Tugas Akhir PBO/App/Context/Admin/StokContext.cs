﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tugas_Akhir_PBO.App.Core;
using Tugas_Akhir_PBO.App.Models.Admin;

namespace Tugas_Akhir_PBO.App.Context.Admin
{
    internal class StokContext : Database
    {
        private static string table = "produk";

        public static void UpdateStok(int id, int stok)
        {
            string query = $"UPDATE {table} SET stok = @stok WHERE id = @id";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@stok", stok),
                new NpgsqlParameter("@id", id)
            };

            commandExecutor(query, parameters);
        }
    }
}
