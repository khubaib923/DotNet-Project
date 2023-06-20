namespace ContractService
{
    public interface ICitiesService
    {
        public Guid ServiceInstance { get;  }
        public List<string> GetCities();


    }
}