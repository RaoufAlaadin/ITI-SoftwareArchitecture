using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAL
{

    /* 1- Non-Query => used for update,insert,delete,
            Anything that returns ` {N} rows got affected` statement.
       2- Scalar => Returns one value from the table. 
                so it's used with : Aggregate functions like : Count(),Sum(),Avg()....
       3- DataTable => there is no special command for it like the others,
            It uses the DataAdapter whcih handles opening/closing the connection
            And it alos retrive the data and store it in a DataTable. 
    
     */
    public class DBManager
    {

        SqlConnection sqlCN;
        SqlCommand sqlCmd;
        SqlDataAdapter sqlDA;
        DataTable dt;


        #region DBManger constructor and intilizing DAO variables (Data Access Object) .

        public DBManager()
        {
            try
            {
                sqlCN = new SqlConnection(ConfigurationManager.ConnectionStrings["pubsCN"].ConnectionString);
                sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = sqlCN;
                sqlDA = new(sqlCmd);
                dt = new();
            }
            catch
            {
                //Log Exception
                // You can write the logs into a text file. 
            }
        }
        #endregion


        #region 1- Parameter-less SP
        public int ExecuteNonQuery(string SPName)
        {
            try
            {
                /* Clearing the parameters here isn't necessary, as this signtures
                 dosn't need input parameteres for it's stored procedure.
                
                 We added it just as best practice for later I guess.*/
                sqlCmd.Parameters.Clear();

                sqlCmd.CommandText = SPName;

                if (sqlCN.State == ConnectionState.Closed)
                    sqlCN.Open();

                /* Returns number of rows affected.*/
                return sqlCmd.ExecuteNonQuery();

            }
            catch
            {
                return -1;
            }
            finally
            {
                sqlCN.Close();
            }
        }

        public object ExecuteScalar(string SPName)
        {
            try
            {
                sqlCmd.Parameters.Clear();

                sqlCmd.CommandText = SPName;

                if (sqlCN.State == ConnectionState.Closed)
                    sqlCN.Open();

                return sqlCmd.ExecuteScalar();

            }
            catch
            {
                return new();
            }
            finally
            {
                sqlCN.Close();
            }
        }



        public DataTable ExecuteDataTable(string SPName)
        {
            try
            {
                dt.Clear();
                sqlCmd.Parameters.Clear();

                sqlCmd.CommandText = SPName;
                /* We have already connected `sqlCmd` reference to `sqlDA` in 
                 The DBManger object initilization.*/
                sqlDA.Fill(dt);

                return dt;
            }
            catch
            {
                return new();
            }
            finally
            {
                sqlCN.Close();
            }
        }
        #endregion

        #region 2-Parameterized SP


            /*Note: Dictionary takes `string` because a name is always a  `String`
                    for the value, it might have different DataTypes, so we
                    set it as `Object` to handle any incomming DataType.*/
        public int ExecuteNonQuery(string SPName, Dictionary<string, object> ParmLst)
        {
            try
            {
                sqlCmd.Parameters.Clear();

                foreach (var item in ParmLst)
                    sqlCmd.Parameters.Add(new SqlParameter(item.Key, item.Value));

                sqlCmd.CommandText = SPName;

                if (sqlCN.State == ConnectionState.Closed)
                    sqlCN.Open();

                return sqlCmd.ExecuteNonQuery();

            }
            catch
            {
                return -1;
            }
            finally
            {
                sqlCN.Close();
            }
        }



        public object ExecuteScalar(string SPName, Dictionary<string, object> ParmLst)
        {
            try
            {
                sqlCmd.Parameters.Clear();

                foreach (var item in ParmLst)
                    sqlCmd.Parameters.Add(new SqlParameter(item.Key, item.Value));

                sqlCmd.CommandText = SPName;

                if (sqlCN.State == ConnectionState.Closed)
                    sqlCN.Open();

                return sqlCmd.ExecuteScalar();

            }
            catch
            {
                return new();
            }
            finally
            {
                sqlCN.Close();
            }
        }


        public DataTable ExecuteDataTable(string SPName, Dictionary<string, object> ParmLst)
        {
            try
            {
                dt.Clear();
                sqlCmd.Parameters.Clear();

                foreach (var item in ParmLst)
                    sqlCmd.Parameters.Add(new SqlParameter(item.Key, item.Value));

                sqlCmd.CommandText = SPName;

                sqlDA.Fill(dt);

                return dt;
            }
            catch
            {
                return new();
            }
            finally
            {
                sqlCN.Close();
            }
        } 
        #endregion

    }
}