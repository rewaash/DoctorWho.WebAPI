using AutoMapper;
using DoctorWho.Db.DataModels;
using DoctorWho.Db.Repositories.AuthorRepository;
using DoctorWho.web.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorRepository authorRepository,IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpPut("{AuthorId}")]
        public async Task<ActionResult> UpdateAuthor(int AuthorId,AuthorForUpdateDto authorForUpdateDto)
        {
            if (!await _authorRepository.AuthorExistsAsync(AuthorId))
           return NotFound(); 

            var author = _mapper.Map<Author>(authorForUpdateDto);
            author.Id = AuthorId;
            await _authorRepository.UpdateAuthor(author);
            return NoContent();


        }
    }
}
