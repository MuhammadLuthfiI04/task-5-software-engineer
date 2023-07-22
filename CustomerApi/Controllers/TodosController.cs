using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("api/todos")]
    public class TodosController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TodosController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult> GetTodos()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return Ok(content);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTodoById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/todos/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return Ok(content);
        }
    }
}
