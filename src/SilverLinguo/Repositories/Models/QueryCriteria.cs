namespace SilverLinguo.Repositories.Models
{
    public class QueryCriteria
    {
        public string SearchText { get; set; }
        public OrderByCriteria OrderByCriteria { get; set; }
        public int? Limit { get; set; }
    }

    public class OrderByCriteria
    {
        public OrderBy OrderBy { get; set; }
        public SortOrder SortOrder { get; set; }
    }

    public enum OrderBy
    {
        CreatedAt
    }

    public enum SortOrder
    {
        ASC,
        DESC
    }
}
