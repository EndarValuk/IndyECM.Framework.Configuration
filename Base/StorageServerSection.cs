using System.Runtime.Serialization;

namespace IndyECM.Framework.Configuration.Base
{
  ///<summary>
  /// Base storage section model
  ///</summary>
  public class StorageServerSection : ConnectionSection
  {
    ///<summary>
    /// Storage connection provider
    ///</summary>
    [DataMember]
    public string Provider = "SOME_PROVIDER";

    ///<summary>
    /// Storage catalogue
    ///<remarks>
    /// For database it should be database name.
    /// If we are using LDAP-container, we need to set here root canonical domain name.
    ///</remarks>
    ///</summary>
    [DataMember]
    public string Catalogue { get; set; }

    ///<summary>
    /// Storage scheme
    ///<remarks>
    /// For database storage it should be database version.
    /// If we are using LDAP-container, we need to set here root canonical domain container.
    ///</remarks>
    ///</summary>
    [DataMember]
    public string Scheme { get; set; }
  }
}