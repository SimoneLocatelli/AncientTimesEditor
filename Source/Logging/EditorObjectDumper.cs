#region Usings

using Editor.Logging.Dependencies;
using System.CodeDom.Compiler;
using System.Globalization;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;

#endregion Usings

namespace Editor.Logging
{
    /// <summary>
    ///     Object dumper used to analyze the current state of an object.
    /// </summary>
    public class EditorObjectDumper : IObjectDumper
    {
        /// <summary>
        ///     Dumps the input object retrieving al the properties and
        ///     the current value.
        /// </summary>
        /// <param name="value">The object to dump.</param>
        /// <returns></returns>
        public string Dump(object value)
        {
            var stringBuilder = new StringBuilder();
            var serializer = new Serializer();
            var stringWriter = new StringWriter(stringBuilder, CultureInfo.CurrentCulture);
            serializer.Serialize(new IndentedTextWriter(stringWriter), value);

            return stringBuilder.ToString();
        }
    }
}