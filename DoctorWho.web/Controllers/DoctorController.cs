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

namespace DoctorWho.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorRepository doctorRepository,IMapper mapper)
        {
            _doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(IDoctorRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));

        }

        // GET: api/Doctor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors()
        {
            var doctors = await _doctorRepository.GetDoctorsAsync();
            return Ok(_mapper.Map<IEnumerable<DoctorDto>>(doctors));
        }




    }
}
