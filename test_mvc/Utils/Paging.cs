namespace test_mvc.Utils;

public class Paging
{
    public int Total { get; set; }
    public int Page { get; set; }
    public int Limit { get; set; }

    public Paging(int total, int page, int limit)
    {
        Total = total;
        Page = page;
        Limit = limit;
    }
}
