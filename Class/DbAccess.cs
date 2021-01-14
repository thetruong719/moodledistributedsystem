using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace unzipPackage.Class
{
    public class DbConnection
    {
        //sql nop diem
        public static string svr = "................";
        public static string db = Program.Name_Courses;      
        public static string user = "...."; 
        public static string password = ".........";
        public static SqlConnection _cnn { get; set; }
        public static SqlConnection SqlConnection
        {
            get { return _cnn; }
            set { _cnn = value; }
        }
        public static void Open()
        {
            if (_cnn == null || _cnn.State != ConnectionState.Open)
            {
                _cnn = new SqlConnection(@"Data Source=" + svr + "; Initial Catalog=" + Program.Name_Courses + ";User ID=" + user + ";Password=" + password + "");
                _cnn.Open();
            }
        }

        public static void Close()
        {
            if (_cnn.State != ConnectionState.Closed)
                _cnn.Close();
        }
        public static string get_config(string _id)
        {
            RegistryWriter rg = new RegistryWriter();
            return rg.valuekey(_id);
        }
    }


    public class DbAccess
    {
        SqlCommand cmd;
        SqlTransaction _sqlTran;
        #region "Open-Close Connection"
        /// <summary>
        /// Open Connection
        /// </summary>
        private void Open()
        {
            DbConnection.Open();
        }

        /// <summary>
        /// Close Connection
        /// </summary>
        private void Close()
        {
            DbConnection.Close();
        }
        #endregion

        #region "Transaction"
        /// <summary>
        /// BeginTransction
        /// </summary>
        public void BeginTransaction()
        {
            DbConnection.Open();
            _sqlTran = DbConnection.SqlConnection.BeginTransaction();
        }

        /// <summary>
        /// Close Connection
        /// </summary>
        public void CommitTransaction()
        {
            _sqlTran.Commit();
            DbConnection.Close();
        }

        public void RollbackTransaction()
        {
            _sqlTran.Rollback();
            DbConnection.Close();
        }
        #endregion

        #region "Create and Add parameter for SqlCommand"
        /// <summary>
        /// Create New SqlCommand
        /// </summary>
        public void CreateNewSqlCommand()
        {
            this.Open();
            cmd = new SqlCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = DbConnection.SqlConnection;
        }
        public void CreateNewSqlCommandText()
        {
            this.Open();
            cmd = new SqlCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = DbConnection.SqlConnection;
        }
        /// <summary>
        /// Add Parameters for calling stored procedures
        /// </summary>
        /// <param name="paramName">Name of Parameter</param>
        /// <param name="value">Value of Parameter</param>
        public void AddParameter(string paramName, object value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = paramName;
            param.Value = value;
            cmd.Parameters.Add(param);
        }
        public void AddParameter(string paramName, object value, string type)
        {
            SqlParameter param = new SqlParameter(paramName, SqlDbType.VarBinary, -1);
            param.Value = value;
            cmd.Parameters.Add(param);
        }
        #endregion

        #region "Execute SqlCommand"
        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="sProcName">Name of Stored Procedure</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sProcName)
        {
            try
            {
                cmd.CommandText = sProcName;
                this.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Close();
            }
        }

        /// <summary>
        /// ExecuteNonQueryWithTransaction
        /// </summary>
        /// <param name="sProcName">Name of Stored Procedure</param>        
        /// <returns></returns>
        public bool ExecuteNonQueryWithTransaction(string sProcName)
        {
            try
            {
                // cmd.CommandType
                cmd.CommandText = sProcName;
                cmd.Transaction = _sqlTran;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <param name="sProcName">Name of Stored Procedure</param>
        /// <returns></returns>
        public object ExecuteScalar(string sProcName)
        {
            try
            {
                cmd.CommandText = sProcName;
                this.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Close();
            }
        }
        public int ExecuteScalarWithTransaction(string sProcName)
        {
            int re = 0;
            try
            {
                cmd.CommandText = sProcName;
                cmd.Transaction = _sqlTran;
                re = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return re;
        }


        /// <summary>
        /// ExecuteReader
        /// </summary>
        /// <param name="sProcName">Name of Stored Procedure</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sProcName)
        {
            try
            {
                cmd.CommandText = sProcName;
                this.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ExecuteReaderWithOpenningConnection - Not close connection after reading
        /// </summary>
        /// <param name="sProcName">Name of Stored Procedure</param>        
        /// <returns></returns>
        public SqlDataReader ExecuteReaderWithOpenningConnection(string sProcName)
        {
            try
            {
                cmd.CommandText = sProcName;
                cmd.Transaction = _sqlTran;
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ExecuteDataTable
        /// </summary>
        /// <param name="sProcName">Name of Stored Procedure</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sProcName)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandText = sProcName;
                da.SelectCommand = cmd;
                da.Fill(dt);
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion
    }
}
