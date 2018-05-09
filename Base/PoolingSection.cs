using System.Runtime.Serialization;

namespace IndyECM.Framework.Configuration.Base
{
  ///<summary>
  /// Base multithreaded pooling section model
  ///</summary>
  [DataContract]
  public class PoolingSection
  {
    ///<summary>
    /// Min count of pool threads
    ///</summary>
    [DataMember]
    public int MinimalSize = 1;

    ///<summary>
    /// Max count of pool threads
    ///</summary>
    [DataMember]
    public int MaximalSize = 10;
  }
}