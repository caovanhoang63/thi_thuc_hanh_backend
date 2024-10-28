namespace test_mvc.Utils;

using System.Text.Json;
using System.Text.Json.Serialization;

public class DataJsonConverter<T> : JsonConverter<T>
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<T>(ref reader, options);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        // Nếu `value` là một danh sách, serialize dưới dạng mảng
        if (value is IEnumerable<object>)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
        else
        {
            // Ngược lại, serialize như đối tượng bình thường
            writer.WriteStartObject();
            writer.WritePropertyName("data");
            JsonSerializer.Serialize(writer, value, options);
            writer.WriteEndObject();
        }
    }
}
