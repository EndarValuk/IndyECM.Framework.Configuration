using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace IndyECM.Framework.Configuration
{
  ///<summary>
  /// System state configuration section
  ///</summary>
  [DataContract]
  public sealed class ApplicationSection
  {
    ///<summary>
    /// Application name
    ///</summary>
    [DataMember]
    public string Name = "IndyECM";

    ///<summary>
    /// Are we running under Windows?
    ///</summary>
    ///<returns>True</returns>
    public bool WindowsHosted => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
  }
}