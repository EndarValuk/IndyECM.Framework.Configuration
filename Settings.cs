using System;
using System.IO;
using ServiceStack.Text;
using IndyECM.Framework.Configuration.Schemas;

namespace IndyECM.Framework.Configuration
{
  ///<summary>
  /// Configuration reader
  ///</summary>
  public class Settings
  {
    ///<summary>
    /// Reading database schema from JSON file
    ///</summary>
    ///<param name="fileName">Configuration file name without extension. Usually be a object type name</param>
    ///<returns>Returns instance of schema, defined in JSON file</returns>
    public static ObjectStorageSchema Schema(string fileName) => ReadConfigFile<ObjectStorageSchema>(fileName);

    ///<summary>
    /// Reading application configuration from JSON file
    ///</summary>
    ///<returns>Returns application configuration, defined in JSON file</returns>
    public static ConfigurationSchema Config => ReadConfigFile<ConfigurationSchema>("Config");

    ///<summary>
    /// Reading configuration from JSON file. If file not found, it will be created with default values
    ///</summary>
    ///<param name="fileName">Configuration file name without extension</param>
    ///<typeparam name="T">Configuration model definition class</typeparam>
    ///<returns>Returns instance of configuration, defined in JSON file</returns>
    private static T ReadConfigFile<T>(string fileName) where T : new()
    {
      var basePath = AppContext.BaseDirectory;
      var configFileName = String.Format("{0}.db", fileName);
      var configPath = Path.Combine(basePath, configFileName);
      var typeParameterType = typeof(T);

      if(File.Exists(configPath))
      {
        var text = File.ReadAllText(configPath);
        return (T)JsonSerializer.DeserializeFromString(text, typeParameterType);
      }
      else
      {
        var defaults = new T();
        File.WriteAllText(configPath, JsonSerializer.SerializeToString(defaults, typeParameterType));
        return ReadConfigFile<T>(fileName);
      }
    }
  }
}