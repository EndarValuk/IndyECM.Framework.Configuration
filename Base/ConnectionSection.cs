using System;
using System.Runtime.Serialization;

namespace IndyECM.Framework.Configuration.Base
{
  ///<summary>
  /// Base connection section model
  ///</summary>
  [DataContract]
  public class ConnectionSection : AuthSection
  {
    ///<summary>
    /// Host name/address to listen on/connect to
    ///</summary>
    [DataMember]
    public string Server { get; set; }

    ///<summary>
    /// Host port to listen on/connect to
    ///</summary>
    [DataMember]
    public int Port = 1337;

    ///<summary>
    /// Bandwidth throttling in bytes/sec
    ///</summary>
    [DataMember]
    public long BandwidthLimit = 524288;

    ///<summary>
    /// Connections limit
    ///</summary>
    [DataMember]
    public long ConnectionsLimit = 1024;

    ///<summary>
    /// Connection timeout
    ///</summary>
    [DataMember]
    public TimeSpan ConnectTimeout = new TimeSpan(0, 0, 10);

    ///<summary>
    /// Loadbalance timeout
    ///</summary>
    [DataMember]
    public TimeSpan LoadBalanceTimeout = new TimeSpan(0, 0, 10);
  }
}