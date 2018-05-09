using System;
using System.Runtime.Serialization;
using IndyECM.Framework.Configuration.Base;
using IndyECM.Framework.Definition.Enumeration.Services;

namespace IndyECM.Framework.Configuration
{
  ///<summary>
  /// Identity and Access Management section model
  ///</summary>
  [DataContract]
  public sealed class IAMSection
  {
    ///<summary>
    /// IAM handler type
    ///</summary>
    [DataMember]
    public IamServiceType Type = IamServiceType.ActiveDirectory;

    ///<summary>
    /// Настройки сервера обработчика аутентификации пользователей в системе
    ///</summary>
    [DataMember]
    public MultiServerStorageSection Server = new MultiServerStorageSection
    {
      Main = new StorageServerSection
      {
        Server = "dc01.somedomain.com",
        Catalogue = "SOMEDOMAIN",
        Scheme = "DC=somedomain,DC=com"
      }
    };

    ///<summary>
    /// Are we using ActiveDirectory handler?
    ///</summary>
    public bool UsingActiveDirectory => Type == IamServiceType.ActiveDirectory;

    ///<summary>
    /// Cache timeout for info about user
    ///</summary>
    [DataMember]
    public TimeSpan UserInfoCacheTimeout = TimeSpan.FromMinutes(3);
  }
}