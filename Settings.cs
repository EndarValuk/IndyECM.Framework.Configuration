using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack.Text;
using IndyECM.Framework.Configuration.Schemas;
using IndyECM.Framework.Core.Exceptions;
using IndyECM.Framework.Definition.Enumeration.Types;

namespace IndyECM.Framework.Configuration
{
  ///<summary>
  /// Configuration reader class
  ///</summary>
  public class Settings
  {
    ///<summary>
    /// Reading database schema from JSON file
    ///</summary>
    ///<param name="objectType">Object type</param>
    ///<param name="operationType">Operation type</param>
    ///<returns>Returns instance of schema, defined in JSON file</returns>
    public static string ObjectStorageSchemaValue(ObjectType objectType, QueryOperationType operationType)
    {
      var fileName = objectType.ToString();
      var schema = Settings.ReadConfigFile<ObjectStorageSchema>(fileName);

      try
      {
        return schema[operationType.ToString()];
      }
      catch (NullReferenceException ex)
      {
        throw new MutatedException(OperationResultType.ErrorConfigurationReadNotFound, ex.Message);
      }
      catch (Exception ex)
      {
        throw new MutatedException(OperationResultType.ErrorConfigurationReadBadInput, ex.Message);
      }
    }

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

      if (File.Exists(configPath))
      {
        try
        {
          var text = File.ReadAllText(configPath);
          return (T)JsonSerializer.DeserializeFromString(text, typeParameterType);
        }
        catch (Exception ex)
        {
          throw new MutatedException(OperationResultType.ErrorConfigurationRead, ex.Message);
        }
      }
      else
      {
        try
        {
          var defaults = new T();
          File.WriteAllText(configPath, JsonSerializer.SerializeToString(defaults, typeParameterType));
          return ReadConfigFile<T>(fileName);
        }
        catch (Exception ex)
        {
          throw new MutatedException(OperationResultType.ErrorConfigurationAccess, ex.Message);
        }
      }
    }
  }
}

namespace IndyECM.Framework.Configuration
{
  public static class ConfigurationReader
  {
    public static T ReadSettingsSection<T>(this IConfiguration configuration, string section) where T: class
    {
      return configuration.GetSection("IndyECMSettings").GetSection(section).Get<T>() as T;
    }

    public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
      try
      {
        var settingsSection = configuration.GetSection("IndyECMSettings");
        if(settingsSection == null)
        {
          throw new MutatedException(OperationResultType.ErrorConfigurationReadNotFound);
        }
        // Inject IndyECMSettings so that others can use too
        else
        {
          services.Configure<ApplicationSection>(settingsSection.GetSection("Application"));
          services.Configure<IAMSection>(settingsSection.GetSection("IAM"));
          services.Configure<DataStorageSection>(settingsSection.GetSection("DataStorage"));
          services.Configure<HostSection>(settingsSection.GetSection("API"));
        }
      }
      catch (Exception ex)
      {
        throw new MutatedException(OperationResultType.ErrorConfigurationAccess, ex.Message);
      }
    }
  }
}