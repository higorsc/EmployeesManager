using EmployeesManager.Models;
using EmployeesManager.Models.DTO;
using EmployeesManager.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public IHttpClientFactory _clientFactory;

        public EmployeesRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            using (var client = _clientFactory.CreateClient())
            {
                client.BaseAddress = new Uri("https://gorest.co.in/public/v2/");

                var response = await client.GetAsync("https://gorest.co.in/public/v2/users");

                var content = await response.Content.ReadAsStringAsync();

                var parsedContent = JsonConvert.DeserializeObject<List<Employee>>(content);

                return parsedContent;
            }
        }

        public async Task<List<Employee>> GetEmployeesByName(string name)
        {
            using (var client = _clientFactory.CreateClient())
            {
                client.BaseAddress = new Uri("https://gorest.co.in/public/v2/");

                var response = await client.GetAsync($"https://gorest.co.in/public/v2/users?name={name}");

                var content = await response.Content.ReadAsStringAsync();

                var parsedContent = JsonConvert.DeserializeObject<List<Employee>>(content);

                return parsedContent;
            }
        }


        public async Task<EmployeeDTO> AddEmployee(EmployeeDTO employee)
        {
            using (var client = _clientFactory.CreateClient())
            {
                client.BaseAddress = new Uri("https://gorest.co.in/public/v2/");

                client.DefaultRequestHeaders.Add("Authorization", "Bearer 0bf7fb56e6a27cbcadc402fc2fce8e3aa9ac2b40d4190698eb4e8df9284e2023");
                var parsedEmployee = JsonConvert.SerializeObject(employee);
                var requestContent = new StringContent(parsedEmployee);
                requestContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                var response = await client.PostAsync("https://gorest.co.in/public/v2/users", requestContent);

                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Unable to save employee details!");
                }

                return JsonConvert.DeserializeObject<EmployeeDTO>(responseContent);
            }
        }

    }
}
