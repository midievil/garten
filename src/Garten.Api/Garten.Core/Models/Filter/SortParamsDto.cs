namespace Garten.Core.Models.Filter
{
    public class SortParamsDto
    {
        public string SortColumn { get; set; }
        public bool SortDesc { get; set; }
        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; }
    }
}
