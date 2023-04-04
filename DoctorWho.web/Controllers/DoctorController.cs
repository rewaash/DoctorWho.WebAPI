using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoctorWho.Db.DAL;
using DoctorWho.Db.DataModels;
using DoctorWho.Db.Repositories.DoctorRepository;
using DoctorWho.web.Models;
using AutoMapper;
using System.Security.Cryptography.Xml;
using DoctorWho.web.DTOs;
using DoctorWho.web.Validators;

namespace DoctorWho.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(IDoctorRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));

        }

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors()
        {
            var doctors = await _doctorRepository.GetDoctorsAsync();
            return Ok(_mapper.Map<IEnumerable<DoctorDto>>(doctors));
        }

        [HttpPost("{doctorId}")]
        public async Task<ActionResult<DoctorDto>> Upsert(int doctorId, DoctorForUpsertDto doctorforupsertdto)
        {
            var validator = new DoctorForUpsertValidator();
            var result = validator.Validate(doctorforupsertdto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var doctor = _mapper.Map<Doctor>(doctorforupsertdto);
            var upsertedEntity = await _doctorRepository.UpsertDoctorAsync(doctor, doctorId);
            return Ok(_mapper.Map<DoctorDto>(upsertedEntity));
        }


        [HttpDelete("{doctorId}")]
        public async Task<ActionResult> DeleteDoctor(int doctorId)
        {
           var affectedRows = await _doctorRepository.DeleteDoctorAsync(doctorId);
            if (affectedRows >0)
                return Ok();
            else return NotFound();


        }




    }
}
