using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iocs_analizer_api.Data;
using iocs_analizer_api.Dtos;
using iocs_analizer_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace iocs_analizer_api.Controller
{
    public class IocsController : BaseApiController
    {
        private IIocRepo _repository;
        private readonly IMapper _mapper;

        public IocsController(IIocRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIocsAsync()
        {
            var items = await _repository.GetAllIocsAsync();

            return Ok(_mapper.Map<IEnumerable<IocReadDto>>(items));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIocByIdAsync(int id)
        {
            var item = await _repository.GetIocByIdAsync(id);

            if(item == null)
                return NotFound("error.not_found");

            return Ok(_mapper.Map<IocReadDto>(item));
        }

        [HttpPost]
        public async Task<IActionResult> CreateIocAsync(IocCreateDto ioc)
        {
            var item = _mapper.Map<Ioc>(ioc);

            await _repository.CreateIocAsync(item);
            await _repository.SaveChangesAsync();

            var iocReadDto = _mapper.Map<IocReadDto>(item);

            // return CreatedAtRoute(nameof(GetIocByIdAsync), new { Id = iocReadDto.Id }, iocReadDto);
            // return Ok(_mapper.Map<IocReadDto>(item));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIocAsync(int id, IocUpdateDto ioc)
        {
            var item = await _repository.GetIocByIdAsync(id);
            if(item == null)
                return NotFound("error.not_found");

            _mapper.Map(ioc, item);

            _repository.UpdateIoc(item);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIocAsync(int id)
        {
            var item = await _repository.GetIocByIdAsync(id);
            if (item == null)
                return NotFound("error.not_found");

            _repository.DeleteIoc(item);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}