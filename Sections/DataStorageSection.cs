using System.Data.SqlClient;
using System.Runtime.Serialization;
using IndyECM.Framework.Definition.Enumeration.Types;
using IndyECM.Framework.Definition.Interfaces.Configuration;

namespace IndyECM.Framework.Configuration
{
  ///<summary>
  /// Data storage connection configuration section
  ///</summary>
  [DataContract]
  public sealed class DataStorageSection : IReliableStorageServerSection<StorageServerSection>
  {
    /// <inheritdoc />
    [DataMember]
    public StorageServerSection Main { get; set; }

    /// <inheritdoc />
    [DataMember]
    public StorageServerSection Fallback { get; set; }

    /// <inheritdoc />
    [DataMember]
    public StorageServerSection Cache { get; set; }

    ///<summary>
    /// Generated connection string, based on configured values
    ///</summary>
    ///<returns>Returns connection string</returns>
    public string ConnectionString
    {
      get
      {
        var result = string.Empty;

        switch(Main.Type)
        {
          case DatabaseType.MSSQL:
          {
            var usingIntegratedSecurity = false;
            if(Main.ExtendedProperties != null && Main.ExtendedProperties.ContainsKey(Main.Type)) {
              bool.TryParse(Main.ExtendedProperties[Main.Type]["UseIntegratedSecurity"], out usingIntegratedSecurity);
            }

            var builder = new SqlConnectionStringBuilder
            {
              //ToDo: ApplicationName = Settings.Config.Application.Name,
              ConnectTimeout = (int)Main.ConnectTimeout.TotalSeconds,
              DataSource = $"{Main.Server},{Main.Port}",
              InitialCatalog = Main.Catalogue,
              IntegratedSecurity = usingIntegratedSecurity,
              // TODO: LoadBalanceTimeout = (int)Main..TotalSeconds,
              //MinPoolSize = 1,
              //MaxPoolSize = 10,
              PacketSize = 32768 // FIXME: On linux there is some perfomance bug with low packet size
            };
            // If reserve server defined, let connection string know about it
            if(Fallback != null)
            {
              builder.FailoverPartner = $"{Fallback.Server},{Fallback.Port}";
            }
            // If we dont want to use Single Sign-On, use defined user/password
            if(!usingIntegratedSecurity)
            {
              builder.UserID = Main.Account;
              builder.Password = Main.Password;
            }
            result = builder.ConnectionString;
          }break;
          case DatabaseType.PostgreSQL:
          {
            result = $"Server={Main.Server};Port={Main.Port};User Id={Main.Account};Password={Main.Password};Database={Main.Catalogue}";
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