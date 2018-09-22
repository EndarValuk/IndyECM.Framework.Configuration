using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using IndyECM.Framework.Definition.Enumeration.Types;
using IndyECM.Framework.Definition.Interfaces.Configuration;

namespace IndyECM.Framework.Configuration
{
  ///<summary>
  /// Data storage connection configuration section
  ///</summary>
  public sealed class StorageServerSection : IStorageServerSection<DatabaseType>
  {
#region ICanStoreDataSection implementation

    /// <inheritdoc />
    [DataMember]
    public DatabaseType Type { get; set; }

    /// <inheritdoc />
    [DataMember]
    public string Catalogue { get; set; }

    /// <inheritdoc />
    [DataMember]
    public string Scheme { get; set; }

    /// <inheritdoc />
    [DataMember]
    public Dictionary<DatabaseType, Dictionary<string, string>> ExtendedProperties { get; set; }

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

#region ICanAuthSection implementation

    /// <inheritdoc />
    [DataMember]
    public string Account { get; set; }

    /// <inheritdoc />
    [DataMember]
    public string Password { get; set; }

#endregion
  }
}