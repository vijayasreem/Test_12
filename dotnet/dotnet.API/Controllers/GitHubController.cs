
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DataAccess;
using dotnet.DTO;
using dotnet.Service;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly GitHubService _gitHubService;

        public GitHubController(GitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        [HttpPost]
        public async Task<IActionResult> AddGitHub([FromBody] GitHubModel gitHub)
        {
            try
            {
                int result = await _gitHubService.AddGitHub(gitHub);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGitHub()
        {
            try
            {
                List<GitHubModel> gitHubs = await _gitHubService.GetAllGitHub();
                return Ok(gitHubs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGitHubById(int id)
        {
            try
            {
                GitHubModel gitHub = await _gitHubService.GetGitHubById(id);
                if (gitHub == null)
                {
                    return NotFound();
                }
                return Ok(gitHub);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGitHub(int id, [FromBody] GitHubModel gitHub)
        {
            try
            {
                gitHub.Id = id;
                int result = await _gitHubService.UpdateGitHub(gitHub);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGitHub(int id)
        {
            try
            {
                int result = await _gitHubService.DeleteGitHub(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
