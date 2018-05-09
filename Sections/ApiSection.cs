using System;
using System.Runtime.Serialization;
using IndyECM.Framework.Configuration.Base;
using IndyECM.Framework.Definition.Enumeration.Services;

namespace IndyECM.Framework.Configuration
{
  ///<summary>
  /// API hosting configuration section
  ///</summary>
  [DataContract]
  public sealed class ApiSection : ConnectionSection
  {
    ///<summary>
    /// API response type
    ///</summary>
    [DataMember]
    public ApiResponseType Type = ApiResponseType.Json;

    ///<summary>
    /// CORS-request/response settings
    ///</summary>
    [DataMember]
    public CorsSection CORS = new CorsSection();

    ///<summary>
    /// Is compression enabled for response?
    ///</summary>
    [DataMember]
    public bool CompressionEnabled = false;

    ///<summary>
    /// Is cache enabled for response?
    ///</summary>
    [DataMember]
    public bool CachingEnabled = false;

    ///<summary>
    /// Response cache timeout
    ///</summary>
    [DataMember]
    public TimeSpan CacheTimeOut = TimeSpan.FromHours(3);
  }
}