using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DataAccess;
using dotnet.DTO;

namespace dotnet.Service
{
    public class GitHubService : IGitHubService
    {
        private readonly IGitHubRepository _gitHubRepository;

        public GitHubService(IGitHubRepository gitHubRepository)
        {
            _gitHubRepository = gitHubRepository;
        }

        public async Task<int> AddGitHub(GitHubModel gitHub)
        {
            return await _gitHubRepository.AddGitHub(gitHub);
        }

        public async Task<List<GitHubModel>> GetAllGitHub()
        {
            return await _gitHubRepository.GetAllGitHub();
        }

        public async Task<GitHubModel> GetGitHubById(int id)
        {
            return await _gitHubRepository.GetGitHubById(id);
        }

        public async Task<int> UpdateGitHub(GitHubModel gitHub)
        {
            return await _gitHubRepository.UpdateGitHub(gitHub);
        }

        public async Task<int> DeleteGitHub(int id)
        {
            return await _gitHubRepository.DeleteGitHub(id);
        }
    }
}