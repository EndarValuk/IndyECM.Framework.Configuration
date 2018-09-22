using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using IndyECM.Framework.Definition.Enumeration.Services;
using IndyECM.Framework.Definition.Interfaces.Configuration;

namespace IndyECM.Framework.Configuration
{
  ///<summary>
  /// Identity and Access Management section model
  ///</summary>
  [DataContract]
  public sealed class IAMSection : IStorageServerSection<IamServiceType>
  {
#region ICanAuthSection implementation

    /// <inheritdoc />
    [DataMember]
    public string Account { get; set; }

    /// <inheritdoc />
    [DataMember]
    public string Password { get; set; }

#endregion

#region ICanConnectSection implementation

    /// <inheritdoc />
    [DataMember]
    public string Server { get; set; }

    /// <inheritdoc />
    [DataMember]
    public int Port { get; set; }

    /// <inheritdoc />
    [DataMember]
    public TimeSpan ConnectTimeout { get; set; }

#endregion

#region ICanStoreDataSection implementation

    /// <inheritdoc />
    [DataMember]
    public IamServiceType Type { get; set; }

    /// <inheritdoc />
    [DataMember]
    public string Catalogue { get; set; }

    /// <inheritdoc />
    [DataMember]
    public string Scheme { get; set; }

    /// <inheritdoc />
    [DataMember]
    public Dictionary<IamServiceType, Dictionary<string, string>> ExtendedProperties { get; set; }

#endregion

    ///<summary>
    /// Are we using ActiveDirectory handler?
    ///</summary>
    public bool UsingActiveDirectory => Type == IamServiceType.ActiveDirectory;
  }
}