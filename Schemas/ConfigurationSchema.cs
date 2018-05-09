using System.Runtime.Serialization;

namespace IndyECM.Framework.Configuration.Schemas
{
  ///<summary>
  /// Main configuraion model definition
  ///</summary>
  [DataContract]
  public sealed class ConfigurationSchema
  {
    ///<summary>
    /// Application section
    ///</summary>
    ///<returns>Returns application configuration and current state info</returns>
    [DataMember]
    public ApplicationSection Application = new ApplicationSection();

    ///<summary>
    /// Identity and access management section
    ///</summary>
    ///<returns>Returns identity and access management configuration settings</returns>
    [DataMember]
    public IAMSection IAM = new IAMSection();

    ///<summary>
    /// Datastorage section
    ///</summary>
    ///<returns>Returns datastorage configuration settings</returns>
    [DataMember]
    public DataStorageSection DataStorage = new DataStorageSection();

    ///<summary>
    /// API hosting section
    ///</summary>
    ///<returns>Returns API hosting configuration settings</returns>
    [DataMember]
    public ApiSection API = new ApiSection();
  }
}