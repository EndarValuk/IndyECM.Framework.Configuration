using System.Runtime.Serialization;

namespace IndyECM.Framework.Configuration.Base
{
  ///<summary>
  /// CORS configuration section for API hosting
  ///</summary>
  [DataContract]
  public class CorsSection
  {
    ///<summary>
    /// Allowed origins for CORS-requests
    ///</summary>
    [DataMember]
    public string AllowedOrigins = "http://localhost:1337";

    ///<summary>
    /// Allowed headers for CORS-requests
    ///</summary>
    [DataMember]
    public string AllowedHeaders = "Accept, Content-Type";

    ///<summary>
    /// Allowed methods for CORS-requests
    ///</summary>
    [DataMember]
    public string AllowedMethods = "POST, PUT, DELETE";
  }
}