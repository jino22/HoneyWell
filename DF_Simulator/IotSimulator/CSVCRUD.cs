﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace IOTSimulator
{
    internal class CSVCRUD
    {

        /// <summary>
        /// function for converting CSV to Datatable
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static DataTable readCSV(string filePath)
        {
            var dt = new DataTable();
            // Creating the columns
            File.ReadLines(filePath).Take(1)
                .SelectMany(x => x.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(x => dt.Columns.Add(x.Trim()));

            // Adding the rows
            File.ReadLines(filePath).Skip(1)
                .Select(x => x.Split(';'))
                .ToList()
                .ForEach(line => dt.Rows.Add(line));
            return dt;
        }
    }
}
