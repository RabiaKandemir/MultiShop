using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }
        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
               Barcode = createCargoDetailDto.Barcode,
               CargoCompanyId=createCargoDetailDto.CargoCompanyId,
               ReceiverCustomer=createCargoDetailDto.ReceiverCustomer,
               SenderCustomer=createCargoDetailDto.SenderCustomer,
            };
            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo detayları başarıyla oluşturuldu");
        }
        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo detayları başarıyla silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var values = _cargoDetailService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
               Barcode=updateCargoDetailDto.Barcode,
               CargoCompanyId=updateCargoDetailDto.CargoCompanyId,
               CargoDetailId=updateCargoDetailDto.CargoDetailId,
               SenderCustomer=updateCargoDetailDto.SenderCustomer,
               ReceiverCustomer=updateCargoDetailDto.ReceiverCustomer,
            };
            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("Kargo detayları başarıyla güncellendi");
        }
    }
}
