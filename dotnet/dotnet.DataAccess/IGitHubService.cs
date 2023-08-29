
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DTO;

namespace dotnet.Service
{
    public interface IGitHubService
    {
        Task<int> AddGitHub(GitHubModel gitHub);
        Task<List<GitHubModel>> GetAllGitHub();
        Task<GitHubModel> GetGitHubById(int id);
        Task<int> UpdateGitHub(GitHubModel gitHub);
        Task<int> DeleteGitHub(int id);
    }
}
