using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HRMiniApp.Shared.Services
{
    public class EmployeeApiService
    {
        private readonly HttpClient _httpClient;
        public EmployeeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeApiDto>> GetEmployeesAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<List<EmployeeApiDto>>("https://jsonplaceholder.typicode.com/users") ?? new List<EmployeeApiDto>();
        }
    }

    public class EmployeeApiDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
    }
}
