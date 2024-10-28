using System.Text.Json.Serialization;

namespace test_mvc.Utils;

public class ResponseWrapper<T>
{
    public T Data { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public object Extra { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
    public Paging Paging { get; set; }

    public ResponseWrapper(T data, object extra = null, Paging paging = null)
    {
        Data = data;
        Extra = extra;
        Paging = paging;
    }

    public static ResponseWrapper<T> Success(T data, object extra = null, Paging paging = null)
    {
        return new ResponseWrapper<T>(data, extra, paging);
    }

    public static ResponseWrapper<T> Error(object extra = null)
    {
        return new ResponseWrapper<T>(default, extra);
    }
}