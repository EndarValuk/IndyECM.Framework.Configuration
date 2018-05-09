using System.Runtime.Serialization;
using IndyECM.Framework.Configuration.Base;

namespace IndyECM.Framework.Configuration
{
  ///<summary>
  /// Multiple storage server connection configuration section
  ///</summary>
  [DataContract]
  public sealed class MultiServerStorageSection
  {
    ///<summary>
    /// Main storage server connection settings
    ///</summary>
    [DataMember]
    public StorageServerSection Main { get; set; }

    ///<summary>
    /// Reserve storage server connection settings
    ///</summary>
    [DataMember]
    public StorageServerSection Fallback { get; set; }

    ///<summary>
    /// Cache storage server connection settings
    ///</summary>
    [DataMember]
    public StorageServerSection Cache { get; set; }
  }
}