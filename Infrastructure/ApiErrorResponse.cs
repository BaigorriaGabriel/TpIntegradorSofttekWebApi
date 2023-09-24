namespace TpIntegradorSofttek.Infrastructure
{
    public class ApiErrorResponse
    {
        public int Status { get; set; }

        public List<ResponseError> Error { get; set; }

        public class ResponseError 
        {
            public string? Error { get; set; }
        }
    }
}
