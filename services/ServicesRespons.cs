namespace CustoMate.services
{
    public class ServicesRespons <T>
    {
        public T Data { get; set; }

        public bool IsSucess { get; set; }

        public string Message { get; set; }
    }
}
