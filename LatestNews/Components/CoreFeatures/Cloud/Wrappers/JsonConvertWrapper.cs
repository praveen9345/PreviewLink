namespace LatestNews.Components.CoreFeatures.Cloud.Wrappers
{
    using System;
    using LatestNews.Components.ErrorManagement;
    using Newtonsoft.Json;

    /// <summary>
    ///     Implementation of the <see cref="JsonConvert"/> wrapper class.
    /// </summary>
    public class JsonConvertWrapper : IJsonConvertWrapper
    {
        private readonly IErrorLogger _errorLogger;

        /// <summary>
        ///     Initializes a new instance of <see cref="JsonConvertWrapper"/>.
        /// </summary>
        /// <param name="errorLogger"> The service for logging information and errors. </param>
        public JsonConvertWrapper(IErrorLogger errorLogger)
        {
            _errorLogger = errorLogger;
        }

        /// <summary>
        ///     Deserializes the serialized object of the defined type using <see cref="JsonConvert"/>.
        /// </summary>
        /// <typeparam name="TResult">The type of the result object.</typeparam>
        /// <param name="value">The JSON serialized object.</param>
        /// <returns>The deserialized object of the defined type if no exception occurred. The default value, otherwise. </returns>
        public TResult DeserializeObjectAsync<TResult>(string value)
        {
            try
            {
                return JsonConvert.DeserializeObject<TResult>(value);
            }
            catch (Exception e)
            {
                _errorLogger.LogError("JsonConvertWrapper.cs: DeserializeObjectAsync", e.Message);
                return default;
            }
            
        }

        /// <summary>
        ///     Serializes the given object using <see cref="JsonConvert"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object to serialize.</typeparam>
        /// <param name="value">The object to serialize.</param>
        /// <returns>A JSON string of the serialized object.</returns>
        public string SerializeObject<TObject>(TObject value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
