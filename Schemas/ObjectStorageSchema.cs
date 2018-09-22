using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IndyECM.Framework.Configuration.Schemas
{
  ///<summary>
  /// Database object schema model. Used to define database object mapping
  ///</summary>
  [DataContract]
  public sealed class ObjectStorageSchema : Dictionary<string,string>
  {
    ///<summary>
    /// Constructor
    /// <remarks>If object is new/empty, then add some default entries</remarks>
    ///</summary>
    public ObjectStorageSchema()
    {
      if(this.Count == 0)
      {
        Add("Table", "Schema.Table");
      }
    }
  }
}