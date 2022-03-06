namespace BoleteriaOnline.Core.ViewModels.Pagging;
public class Pagination
{
    public int PageIndex { get; set; }
    public int TotalPages { get; private set; }

    public int TotalItems { get; private set; }

    public bool HasPreviousPage => PageIndex > 1;

    public bool HasNextPage => PageIndex < TotalPages;

    public static Pagination Page(int count, int pageIndex, int pageSize)
    {
        return new Pagination()
        {
            PageIndex = pageIndex,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize),
            TotalItems = count
        };
    }

}
