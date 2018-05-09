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
    /// Gets or sets SingleSignOn authentication
    ///</summary>
    ///<returns>Returns true, when authentication set to SingleSignOn</returns>
    [DataMember]
    public bool UseIntegratedSecurity { get; set; }
  }
}