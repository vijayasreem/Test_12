using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace dotnet
{
    public class GitHubRepository : IGitHubService
    {
        private readonly string connectionString;

        public GitHubRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> AddGitHub(GitHubModel gitHub)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO GitHub (GitHubUsername, GitHubPassword, GitHubURL, RepositoryName) " +
                            "VALUES (@Username, @Password, @URL, @Repository)";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", gitHub.GitHubUsername);
                command.Parameters.AddWithValue("@Password", gitHub.GitHubPassword);
                command.Parameters.AddWithValue("@URL", gitHub.GitHubURL);
                command.Parameters.AddWithValue("@Repository", gitHub.RepositoryName);

                return await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<List<GitHubModel>> GetAllGitHub()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM GitHub";
                var command = new MySqlCommand(query, connection);

                var gitHubs = new List<GitHubModel>();
                var reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    var gitHub = new GitHubModel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        GitHubUsername = reader["GitHubUsername"].ToString(),
                        GitHubPassword = reader["GitHubPassword"].ToString(),
                        GitHubURL = reader["GitHubURL"].ToString(),
                        RepositoryName = reader["RepositoryName"].ToString()
                    };
                    gitHubs.Add(gitHub);
                }
                reader.Close();

                return gitHubs;
            }
        }

        public async Task<GitHubModel> GetGitHubById(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM GitHub WHERE Id = @Id";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                var reader = await command.ExecuteReaderAsync();
                if (reader.Read())
                {
                    var gitHub = new GitHubModel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        GitHubUsername = reader["GitHubUsername"].ToString(),
                        GitHubPassword = reader["GitHubPassword"].ToString(),
                        GitHubURL = reader["GitHubURL"].ToString(),
                        RepositoryName = reader["RepositoryName"].ToString()
                    };
                    reader.Close();

                    return gitHub;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }

        public async Task<int> UpdateGitHub(GitHubModel gitHub)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "UPDATE GitHub SET GitHubUsername = @Username, GitHubPassword = @Password, " +
                            "GitHubURL = @URL, RepositoryName = @Repository WHERE Id = @Id";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", gitHub.GitHubUsername);
                command.Parameters.AddWithValue("@Password", gitHub.GitHubPassword);
                command.Parameters.AddWithValue("@URL", gitHub.GitHubURL);
                command.Parameters.AddWithValue("@Repository", gitHub.RepositoryName);
                command.Parameters.AddWithValue("@Id", gitHub.Id);

                return await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<int> DeleteGitHub(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM GitHub WHERE Id = @Id";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                return await command.ExecuteNonQueryAsync();
            }
        }
    }
}