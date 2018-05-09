using System.Runtime.Serialization;

namespace IndyECM.Framework.Configuration
{
  ///<summary>
  /// Data storage connection configuration section
  /// specific for MSSQL storage
  ///</summary>
  [DataContract]
  public sealed class DataStorageMSSQLSection
  {
    ///<summary>
    /// Enable/disable async processing
    ///</summary>
    ///<returns>Returns true, when async processing is enabled</returns>
    [DataMember]
    public bool UseAsyncProcessing { get; set; }

    ///<summary>
    /// Enable/disable context connection
    ///</summary>
    ///<returns>Returns true, when context connection is enabled</returns>
    [DataMember]
    public bool UseContextConnection { get; set; }

    ///<summary>
    /// Enable/disable SingleSignOn authentication
    ///</summary>
    ///<returns>Returns true, when SingleSignOn authentication enabled</returns>
    [DataMember]
    public bool UseIntegratedSecurity { get; set; }
  }
}