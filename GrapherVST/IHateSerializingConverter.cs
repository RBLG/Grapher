using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Reflection;
using System.Threading.Tasks;
using Grapher.Modules;
using Grapher.Modes;
using Grapher.Scale;
using Grapher.Scale.Related;

namespace GrapherVST
{
    /// <summary>
    /// implements safe-ish (de)serialization of polymorphism through filtering by namespace
    /// </summary>
    /// <typeparam name="TBase">the interface to handle</typeparam>
    public abstract class IHSConverter<TBase> : JsonConverter<TBase> where TBase : class
    {

        protected string TypePropertyName => "Type";

        /// <summary>
        /// Gets the expected property name of the object in JSON containing the object data payload.
        /// </summary>
        protected abstract string DataPropertyName { get; }

        /// <inheritdoc/>
        public override TBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Assert(reader.TokenType != JsonTokenType.StartObject, "JsonExceptionNotStartObject");

            reader.Read();
            Assert(reader.TokenType != JsonTokenType.PropertyName, "JsonExceptionMalformedText");

            string? typePropertyName = reader.GetString();
            Assert(typePropertyName != TypePropertyName, "JsonExceptionInvalidTypeName" + typePropertyName! + TypePropertyName);

            reader.Read();
            Assert(reader.TokenType != JsonTokenType.String, "JsonExceptionTypeValueNotString");

            string stype = reader.GetString() ?? throw new JsonException("type is null");
            Type type = typenames[stype];
            Assert(!type.IsAssignableTo(typeof(TBase)), "type " + stype + " is not assignable to " + typeof(TBase));
            Assert(!types.Contains(type), "type was not whitelisted");


            reader.Read();
            Assert(reader.TokenType != JsonTokenType.PropertyName, "JsonExceptionMalformedText");

            string? dataPropertyName = reader.GetString();

            Assert(dataPropertyName != DataPropertyName, "JsonExceptionInvalidTypeName" + dataPropertyName! + DataPropertyName);

            reader.Read();
            Assert(reader.TokenType != JsonTokenType.StartObject, "JsonExceptionDataValueNotObject");


            TBase? readValue = Deserialize(ref reader, type);//ReadFromType(ref reader, type);
            reader.Read();

            return readValue;
        }

        public TBase Deserialize(ref Utf8JsonReader reader, Type type)
        {
            object nobj = JsonSerializer.Deserialize(ref reader, type, Cereal.CreateOptions())
                ?? throw new JsonException("obj is null");
            Assert(nobj is not TBase, "obj was not OBJ");
            return (TBase)nobj!;
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, TBase value, JsonSerializerOptions options)
        {
            if (writer == null)
            { throw new ArgumentNullException(nameof(writer)); }

            if (value == null)
            { throw new ArgumentNullException(nameof(value)); }

            string type = value.GetType().FullName ?? throw new Exception("type fullname is null");


            writer.WriteStartObject();
            writer.WriteString(TypePropertyName, type);

            writer.WriteStartObject(DataPropertyName);

            //THIS PRODUCE DOUBLE CURLY BRACKET WHICH ARE ELIMINATED IN PLUGINPERSISTENCE
            JsonSerializer.Serialize(writer, value, value.GetType(), options);

            // a better way to do so... in .net6
            //string rstr = JsonSerializer.Serialize(value, value.GetType(), options);
            //rstr = rstr[1..^1];
            //writer.WriteRawValue(rstr,false);

            writer.WriteEndObject();

            writer.WriteEndObject();
        }

        ////////////////////////////////////////////////

        protected IHSConverter(string nspace)
        {
            types.AddRange(GetTypesInNamespace(typeof(TBase)!, nspace));
            foreach (Type type in types)
            {
                typenames.Add(type.FullName!, type);
            }
        }

        protected static void Assert(Boolean condition, string excepmsg)
        { if (condition) { throw new JsonException(excepmsg); } }

        protected List<Type> types = new();
        protected Dictionary<string, Type> typenames = new();
        private static List<Type> GetTypesInNamespace(Type inassembly, string nameSpace)
        {
            return (Assembly
                    .GetAssembly(inassembly) ?? throw new Exception("no assembly found"))
                    .GetTypes()
                    .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                    .ToList();
        }

    }

    // ///////////////////// STATIC CLASS CEREAL /////////////////////

    public static class Cereal
    {

        public static OBJ Deserialize<OBJ>(string njson)
        {
            OBJ? nobj = JsonSerializer.Deserialize<OBJ>(njson, CreateOptions());
            if (nobj == null) { throw new JsonException("obj was null"); }
            return nobj;
        }

        public static string Serialize<OBJ>(OBJ obj)
        {
            string njson = JsonSerializer.Serialize<OBJ>(obj, CreateOptions());
            return njson;
        }

        public static JsonSerializerOptions CreateOptions() => new()
        {
            Converters = {
                new IModuleConverter(),
                new IInputScaleConverter(),
                new IOutputScaleConverter(),
                new ITimeScaleConverter(),
                new IModeConverter()
            },
            IncludeFields = true,
            IgnoreReadOnlyProperties = true,
            IgnoreReadOnlyFields = true,
        };
    }

    // //////////////////CONVERTERS////////////////////

    public class IModuleConverter : IHSConverter<IModule>
    {
        protected override string DataPropertyName => "IModule";
        public IModuleConverter() : base(typeof(Grapher.Modules.TableModule).Namespace!) { }
    }

    public class IInputScaleConverter : IHSConverter<IInputScale>
    {
        protected override string DataPropertyName => "IInputScale";
        public IInputScaleConverter() : base(typeof(Grapher.Scale.PhaseInputScale).Namespace!) { }
    }

    public class IOutputScaleConverter : IHSConverter<IOutputScale>
    {
        protected override string DataPropertyName => "IOutputScale";
        public IOutputScaleConverter() : base(typeof(Grapher.Scale.PhaseInputScale).Namespace!) { }
    }

    //temporary till i find a better solution to envelloppe handling and ITimeScale can be removed
    public class ITimeScaleConverter : IHSConverter<ITimeScale>
    {
        protected override string DataPropertyName => "ITimeScale";
        public ITimeScaleConverter() : base(typeof(Grapher.Scale.PhaseInputScale).Namespace!) { }
    }

    public class IModeConverter : IHSConverter<IMode>
    {
        protected override string DataPropertyName => "IMode";
        public IModeConverter() : base(typeof(Grapher.Modes.MultiplyMode).Namespace!) { }
    }




}
