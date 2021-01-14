using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unzipPackage.Class
{
    public class DbConnectionMySqlOffline
    {
        public static string MainServer = Program.MainServer;
        public static string MainDB = Program.MainDB;
        public static string Port = Program.port_mysql;
        public static string user = "........";
        public static string password = "";
        public static string get_config(string _id)
        {
            RegistryWriter rg = new RegistryWriter();
            return rg.valuekey(_id);
        }
    }
    public class DbAccessMySqlOffline
    {
        private global::MySql.Data.MySqlClient.MySqlConnection _cnn { get; set; }

        private global::MySql.Data.MySqlClient.MySqlTransaction _sqlTran;

        private global::MySql.Data.MySqlClient.MySqlCommand cmd;

        private bool connectionMode = true;    // true=> Main Database, false => Read only DB. ( Phục vụ cho việc tối ưu hệ thống ).

        /// <summary>
        /// Open Connection
        /// </summary>
        public void Open()
        {
            if (_cnn == null)
            {
                if (connectionMode)
                    _cnn = new global::MySql.Data.MySqlClient.MySqlConnection(@"server=" + DbConnectionMySqlOffline.MainServer + ";Port=" + DbConnectionMySqlOffline.Port + ";user id=" + DbConnectionMySqlOffline.user + ";password=" + DbConnectionMySqlOffline.password + ";persistsecurityinfo=True;database=" + DbConnectionMySqlOffline.MainDB + ";allowuservariables=True;convert zero datetime=True;Charset='utf8';");    //Allow Zero Datetime=true
                else
                    _cnn = new global::MySql.Data.MySqlClient.MySqlConnection(@"server=" + DbConnectionMySqlOffline.MainServer + ";Port=" + DbConnectionMySqlOffline.Port + ";user id=" + DbConnectionMySqlOffline.user + ";password=" + DbConnectionMySqlOffline.password + ";persistsecurityinfo=True;database=" + DbConnectionMySqlOffline.MainDB + ";allowuservariables=True;convert zero datetime=True;Charset='utf8';");   // cái này dùng khi có 2 database tự đồng bộ với nhau mới sử dụng nhé.
            }
            if (_cnn.State != ConnectionState.Open)
                _cnn.Open();

        }

        public void setConnectionMode(bool _mode)
        {
            connectionMode = _mode;
        }
        /// <summary>
        /// Close Connection
        /// </summary>
        public void Close()
        {
            if (_cnn.State != ConnectionState.Closed)
            {
                _cnn.Close();
                _cnn.Dispose();
            }
        }
        public global::MySql.Data.MySqlClient.MySqlConnection MySqlConnection
        {
            get { return _cnn; }
            set { _cnn = value; }
        }

        #region "Create and Add parameter for SqlCommand"
        /// <summary>
        /// Create New SqlCommand
        /// </summary>
        public void CreateNewSqlCommand()
        {
            this.Open();
            cmd = new global::MySql.Data.MySqlClient.MySqlCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = MySqlConnection;

        }
        public void CreateNewSqlCommand_Text()
        {
            this.Open();
            cmd = new global::MySql.Data.MySqlClient.MySqlCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = MySqlConnection;
        }
        /// <summary>
        /// Add Parameters for calling stored procedures
        /// </summary>
        /// <param name="paramName">Name of Parameter</param>
        /// <param name="value">Value of Parameter</param>
        public void AddParameter(string paramName, object value)
        {
            global::MySql.Data.MySqlClient.MySqlParameter param = new global::MySql.Data.MySqlClient.MySqlParameter();
            param.ParameterName = paramName;
            param.Value = value;
            cmd.Parameters.Add(param);
        }

        #endregion

        public DataTable ExecuteDataTable(string sProcName)
        {
            DataTable dt = new DataTable();
            try
            {
                Open();
                global::MySql.Data.MySqlClient.MySqlDataAdapter da = new global::MySql.Data.MySqlClient.MySqlDataAdapter();
                cmd.CommandText = sProcName;
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                Close();
            }
            return dt;
        }
        public int Execute_int(string sProcName)
        {
            DataTable dt = new DataTable();
            int dt_ = 0;
            try
            {
                Open();
                global::MySql.Data.MySqlClient.MySqlDataAdapter da = new global::MySql.Data.MySqlClient.MySqlDataAdapter();
                cmd.CommandText = sProcName;
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                Close();
            }
            dt_ = dt.Rows.Count;
            return dt_;
        }
        public string ExecuteData_string(string sProcName)
        {
            string dt_ = "";
            DataTable dt = new DataTable();
            try
            {
                Open();
                global::MySql.Data.MySqlClient.MySqlDataAdapter da = new global::MySql.Data.MySqlClient.MySqlDataAdapter();
                cmd.CommandText = sProcName;
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                Close();
            }
            dt_ = dt.Rows[0][0].ToString();
            return dt_;
        }
        public bool ExecuteData_bool(string sProcName)
        {
            DataTable dt = new DataTable();
            try
            {
                Open();
                global::MySql.Data.MySqlClient.MySqlDataAdapter da = new global::MySql.Data.MySqlClient.MySqlDataAdapter();
                cmd.CommandText = sProcName;
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                Close();
            }
            return true;
        }
        #region "Transaction"
        /// <summary>
        /// BeginTransction
        /// </summary>
        public void BeginTransaction()
        {
            Open();
            _sqlTran = MySqlConnection.BeginTransaction();
        }

        /// <summary>
        /// Close Connection
        /// </summary>
        public void CommitTransaction()
        {
            _sqlTran.Commit();
            Close();
        }

        public void RollbackTransaction()
        {
            _sqlTran.Rollback();
            Close();
        }
        #endregion
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
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                this.Close();
            }
        }
        public bool ExecuteNonQueryWithTransaction(string sProcName)
        {
            try
            {
                cmd.CommandText = sProcName;
                cmd.Transaction = _sqlTran;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw ex;
            }
        }
        public bool ExecuteNonQueryWithTransaction_Text(string sProcName)
        {
            try
            {
                cmd.CommandText = sProcName;
                cmd.Transaction = _sqlTran;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw ex;
            }
        }
    }
}
