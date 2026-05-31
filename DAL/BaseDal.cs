﻿using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace DAL
{
    public class BaseDal
    {
        protected string ConnectionString;
        protected OleDbConnection conn;

        public BaseDal()
        {
            // Path to Access DB file
            string DBfileName = @"data\mashovdb.accdb";

            // Move up from bin\Debug (or bin\Release) to project root
            string projectDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
            string dbFullPath = Path.Combine(projectDir, DBfileName);

            // Access connection string (.accdb)
            ConnectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbFullPath};Persist Security Info=False;";
            conn = new OleDbConnection(ConnectionString);
        }

        public int ExecuteInsertQuery(string sql)
        {
            return ExecuteQuery(sql);
        }

        public int ExecuteUpdateQuery(string sql)
        {
            return ExecuteQuery(sql);
        }

        public int ExecuteDeleteQuery(string sql)
        {
            return ExecuteQuery(sql);
        }

        /// <summary>
        /// מפעיל שאילתא שמחזירה טבלה
        /// למשל:
        /// select * from Students where Gender='male'
        /// </summary>
        public DataTable ExecuteSelectAllQuery(string sql)
        {
            DataTable table = new DataTable();
            OleDbCommand cmd = new OleDbCommand(sql, conn);

            try
            {
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception ex)
            {
                HandleError(ex, sql);
                throw;
            }
            finally
            {
                conn.Close();
            }

            return table;
        }

        /// <summary>
        /// מפעיל שאילתה שמחזירה מחרוזת
        /// </summary>
        public string ExecuteSelectStringQuery(string sql)
        {
            object obj = ExecuteSelectOneData(sql);
            return Convert.ToString(obj);
        }

        /// <summary>
        /// מפעיל שאילתה שמחזירה ערך בוליאני
        /// </summary>
        public bool ExecuteSelectBoolQuery(string sql)
        {
            object obj = ExecuteSelectOneData(sql);
            return Convert.ToBoolean(obj);
        }

        /// <summary>
        /// מפעיל שאילתה שמחזירה ערך שלם
        /// </summary>
        public int ExecuteSelectIntQuery(string sql)
        {
            object obj = ExecuteSelectOneData(sql);
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// מפעיל שאילתה שמחזירה ערך יחיד
        /// </summary>
        private object ExecuteSelectOneData(string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, conn);

            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                HandleError(ex, sql);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// מפעיל שאילתא שלא מחזירה ערך (INSERT, UPDATE, DELETE)
        /// </summary>
        private int ExecuteQuery(string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, conn);

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                HandleError(ex, sql);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public virtual void HandleError(Exception ex, string sql)
        {
            Console.WriteLine("DB Error:");
            Console.WriteLine(sql);
            Console.WriteLine(ex.Message);
        }
    }
}