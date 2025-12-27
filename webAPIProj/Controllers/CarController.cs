using CApp_DesignPattern_Advance;
using Microsoft.AspNetCore.Mvc;

namespace webAPIProj.Controllers
{
    public interface ICarCatelogFactory
    {
        ICarCatalog GetCatalog(string type);
    }

    // This is a actual FACTORY method which is responsible for creating underlying objects

    public class CarCatelogFactory : ICarCatelogFactory
    {
        public ICarCatalog GetCatalog(string type)
        {
            ICarCatalog catalog = null;
            switch (type)
            {
                case "P":
                    catalog = new PetrolCarCatalog();
                    break;

                case "D":
                    catalog = new DiseselCarCatalog();
                    break;
            }
            return catalog;
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarCatelogFactory _carCatalog;

        private readonly Func<string, ICarCatalog> _func;
        public CarController(ICarCatelogFactory carCatalog)//, Func<string, ICarCatalog> func)
        {
            this._carCatalog = carCatalog;

            //this._func = func;
        }
        
        // So here the object creation (i.e. the type of object which needs to be created) depends on
        // the external parameters (in this case query string)
        // in such cases factory method design pattern is suitable

        // Assume that this api endpoint is used from online portal
        // that portal will pass us type and based on the type proided we need return all Petrol/Diesel/Eletric Cars
        // i.e. based on type provided we need to ceate object collection

        [HttpGet]
        public IEnumerable<Car> Get([FromQuery] string type)
        {
            _func(type).GetCars();
            return _carCatalog.GetCatalog(type).GetCars();
        }
    }
}
