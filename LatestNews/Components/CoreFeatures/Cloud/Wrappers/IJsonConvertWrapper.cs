namespace LatestNews.Components.CoreFeatures.Cloud.Wrappers
{
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    ///     Wrapper of <see cref="JsonConvert"/> functionality.
    /// </summary>
    public interface IJsonConvertWrapper
    {
        /// <summary>
        ///     Deserializes the serialized object of the defined type using <see cref="JsonConvert"/>.
        /// </summary>
        /// <typeparam name="TResult">The type of the result object.</typeparam>
        /// <param name="value">The JSON serialized object.</param>
        /// <returns>The deserialized object of the defined type if no exception occurred. The default value, otherwise. </returns>
        TResult DeserializeObjectAsync<TResult>(string value);

        /// <summary>
        ///     Serializes the given object using <see cref="JsonConvert"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object to serialize.</typeparam>
        /// <param name="value">The object to serialize.</param>
        /// <returns>A JSON string of the serialized object.</returns>
        string SerializeObject<TObject>(TObject value);
    }
}