using ContractService;

namespace Services
{
    public class CitiesService : ICitiesService,IDisposable
    {
        private List<string> _Cities { get; set; }

        public Guid ServiceInstance { get; set; }
        //public int MyProperty { get; set; }


        public CitiesService()
        {
            _Cities = new List<string>() { "Karachi", "Islamabad", "Multan", "Lahore" };
            ServiceInstance= Guid.NewGuid();
           
        }


        //public List<string> GetCities()
        //{
        //    return _Cities;
        //}
        public List<string> GetCities()
        {
            return _Cities;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
            //add logic to close db connection
        }
    }
}