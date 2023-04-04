using AutoMapper;
using DoctorWho.Db.DataModels;
using DoctorWho.Db.Repositories.DoctorRepository;
using DoctorWho.Db.Repositories.EpisodeRepository;
using DoctorWho.web.DTOs;
using DoctorWho.web.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMapper _mapper;

        public EpisodeController(IEpisodeRepository episodeRepository, IMapper mapper)
        {
            _episodeRepository = episodeRepository ?? throw new ArgumentNullException(nameof(IEpisodeRepository));
            _mapper = mapper?? throw new ArgumentNullException(nameof(IMapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EpisodeDto>>> GetEpisodes() {

         var episodes = await _episodeRepository.GatEpisodesAsync();
            return Ok(_mapper.Map<IEnumerable<EpisodeDto>>(episodes));


        }

        [HttpPost]
        public async Task<ActionResult> CreateEpisode(EpisodeForCreationDto episodeForCreationDto)
        {
            var validator = new EpisodeForCreationValidator();
            var result = validator.Validate(episodeForCreationDto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var episode = _mapper.Map<Episode>(episodeForCreationDto);
            await _episodeRepository.AddEpisode(episode);
            var episodeDto = _mapper.Map<EpisodeDto>(episode);
            return Ok(episodeDto.Id);
        }
    }
}
