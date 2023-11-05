namespace app.Entities.Common
{
    public class DataGrid<T>
    {
        public IQueryable<T> Query { get; set; }
        public string term { get; set; }
        public SearchItem SearchItem { get; set; } = new SearchItem();
        public List<SearchItem> RepeaterList { get; set; } = new List<SearchItem>();
    }
    public class RepeaterViewModel
    {
        public List<SearchItem> RepeaterList { get; set; } = new List<SearchItem>();
    }
    public class SearchItem
    {
        public string term { get; set; }
    }
}
