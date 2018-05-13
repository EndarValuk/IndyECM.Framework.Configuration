using System;
using System.Runtime.Serialization;
using IndyECM.Framework.Definition.Enumeration.Services;
using IndyECM.Framework.Definition.Interfaces.Configuration;

namespace IndyECM.Framework.Configuration
{
  ///<summary>
  /// API hosting configuration section
  ///</summary>
  [DataContract]
  public sealed class HostSection : ICanConnectSection, ICanCacheSection, ICanCompressSection, ICanLimitConnectionsSection, IKnowCORSSection
  {
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

#region ICanCacheSection implementation

    /// <inheritdoc />
    [DataMember]
    public bool CachingEnabled { get; set; }

    /// <inheritdoc />
    [DataMember]
    public TimeSpan CacheTimeOut { get; set; }

#endregion

#region ICanCompressSection implementation

    /// <inheritdoc />
    [DataMember]
    public bool CompressionEnabled { get; set; }
 
 #endregion
 
#region ICanLimitConnectionsSection implementation

    /// <inheritdoc />
    [DataMember]
    public long BandwidthLimit { get; set; }

    /// <inheritdoc />
    [DataMember]
    public long ConnectionsLimit { get; set; }

#endregion 

#region IKnowCORSSection implementation

    /// <inheritdoc />
    [DataMember]
    public string AllowedOrigins { get; set; }

    /// <inheritdoc />
    [DataMember]
    public string AllowedHeaders { get; set; }

    /// <inheritdoc />
    [DataMember]
    public string AllowedMethods { get; set; }

#endregion
  }
}