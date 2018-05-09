using System.Data.SqlClient;
using System.Runtime.Serialization;
using IndyECM.Framework.Configuration.Base;
using IndyECM.Framework.Definition.Enumeration.Types;

namespace IndyECM.Framework.Configuration
{
  ///<summary>
  /// Data storage connection configuration section
  ///</summary>
  [DataContract]
  public sealed class DataStorageSection
  {
    ///<summary>
    /// Storage type
    ///</summary>
    [DataMember]
    public DatabaseType Type = DatabaseType.MSSQL;

    ///<summary>
    /// MSSQL specific storage settings
    ///</summary>
    ///<returns></returns>
    [DataMember]
    public DataStorageMSSQLSection MSSQL = new DataStorageMSSQLSection();

    ///<summary>
    /// Storage server connection settings
    ///</summary>
    [DataMember]
    public MultiServerStorageSection Server = new MultiServerStorageSection
    {
      Main = new StorageServerSection
      {
        Provider = "System.Data.SqlClient",
        Server = "localhost",
        Catalogue = "IndyECM",
        Scheme = "2016"
      }
    };

    ///<summary>
    /// Generated connection string, based on configured values
    ///</summary>
    ///<returns>Returns connection string</returns>
    public string ConnectionString
    {
      get
      {
        var result = string.Empty;

        switch(Type)
        {
          case DatabaseType.MSSQL:
          {
            var builder = new SqlConnectionStringBuilder
            {
              ApplicationName = Settings.Config.Application.Name,
              ConnectTimeout = (int)Server.Main.ConnectTimeout.TotalSeconds,
              DataSource = $"{Server.Main.Server},{Server.Main.Port}",
              InitialCatalog = Server.Main.Catalogue,
              IntegratedSecurity = MSSQL.UseIntegratedSecurity,
              LoadBalanceTimeout = (int)Server.Main.LoadBalanceTimeout.TotalSeconds,
              MinPoolSize = 1,
              MaxPoolSize = 10,
            };
            // If reserve server defined, let connection string know about it
            if(Server.Fallback != null)
            {
              builder.FailoverPartner = $"{Server.Fallback.Server},{Server.Fallback.Port}";
            }
            // If we dont want to use Single Sign-On, use defined user/password
            if(!MSSQL.UseIntegratedSecurity)
            {
              builder.UserID = Server.Main.Account;
              builder.Password = Server.Main.Password;
            }
            result = builder.ConnectionString;
          }break;
          default:
          {
            result = string.Empty;
          }break;
        }
        return result;
      }
    }
  }
}