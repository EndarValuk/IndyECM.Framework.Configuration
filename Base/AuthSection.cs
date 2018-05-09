using System.Runtime.Serialization;

namespace IndyECM.Framework.Configuration.Base
{
  ///<summary>
  /// Base auth section model
  ///</summary>
  [DataContract]
  public class AuthSection
  {
    ///<summary>
    /// Account name, used to identify context user
    ///</summary>
    [DataMember]
    public string Account = "L0gin";

    ///<summary>
    /// Accounts password
    ///</summary>
    [DataMember]
    public string Password = "P@s$w0rd";
  }
}