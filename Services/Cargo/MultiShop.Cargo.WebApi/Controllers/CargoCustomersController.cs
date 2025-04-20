using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }
        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
               Name= createCargoCustomerDto.Name,
               Surname= createCargoCustomerDto.Surname,
               Address= createCargoCustomerDto.Address,
               Email= createCargoCustomerDto.Email,
               Phone= createCargoCustomerDto.Phone,
               City= createCargoCustomerDto.City,
               District= createCargoCustomerDto.District,
               UserCustomerId= createCargoCustomerDto.UserCustomerId,
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Kargo müşteri ekleme işlemi başarıyla yapıldı");
        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo müşteri silme işlemi başarıyla yapıldı");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var values = _cargoCustomerService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                Name = updateCargoCustomerDto.Name,
                Surname = updateCargoCustomerDto.Surname,
                Address = updateCargoCustomerDto.Address,
                Email = updateCargoCustomerDto.Email,
                Phone = updateCargoCustomerDto.Phone,
                City = updateCargoCustomerDto.City,
                District = updateCargoCustomerDto.District,
                UserCustomerId=updateCargoCustomerDto.UserCustomerId,
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo müşteri güncelleme işlemi başarıyla yapıldı");
        }
        [HttpGet("GetCargoCustomerById")]
        public IActionResult GetCargoCustomerById(string id)
        {
            return Ok(_cargoCustomerService.TGetCargoCustomerById(id));
        }
    }
}
