using System.Data.Common;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Extensions;

public static class EntityFrameworkExtensions
{
    public static DbCommand LoadStoredProc(
      this DbContext context, string storedProcName)
    {
        DbCommand cmd = context.Database.GetDbConnection().CreateCommand();
        cmd.CommandText = storedProcName;
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        return cmd;
    }

    public static DbCommand WithSqlParam(this DbCommand cmd, string paramName, object paramValue)
    {
        if (string.IsNullOrEmpty(cmd.CommandText))
        {
            throw new InvalidOperationException(
              "Call LoadStoredProc before using this method");
        }

        DbParameter param = cmd.CreateParameter();
        param.ParameterName = paramName;
        param.Value = paramValue;
        cmd.Parameters.Add(param);
        return cmd;
    }

    public static List<T> MapToList<T>(this DbDataReader dr)
    {
        List<T> objList = new();
        IEnumerable<PropertyInfo> props = typeof(T).GetRuntimeProperties();

        Dictionary<string, DbColumn> colMapping = dr.GetColumnSchema()
          .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
          .ToDictionary(key => key.ColumnName.ToLower());

        if (dr.HasRows)
        {
            while (dr.Read())
            {
                T obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in props)
                {
                    object val =
                      dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                    prop.SetValue(obj, val == DBNull.Value ? null : val);
                }
                objList.Add(obj);
            }
        }
        return objList;
    }

    public static async Task<List<T>> ExecuteStoredProc<T>(this DbCommand command)
    {
        using (command)
        {
            if (command.Connection.State == System.Data.ConnectionState.Closed)
            {
                command.Connection.Open();
            }

            try
            {
                using (DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    return reader.MapToList<T>();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }

}
