namespace TpIntegradorSofttek.DTOs
{
	public class PaginateDataDto<T>
	{
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public string PrevUrl { get; set; }
        public string NextUrl { get; set; }
        public List<T> Items { get; set; }
    }
}
