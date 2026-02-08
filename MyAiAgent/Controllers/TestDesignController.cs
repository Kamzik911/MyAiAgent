using Microsoft.AspNetCore.Mvc;
using MyAiAgent.Models;
using MyAiAgent.Services;

namespace MyAiAgent.Controllers
{
    [ApiController]
    [Route("testdesign")]
    public class TestDesignController : ControllerBase
    {
        private readonly TestDesignAgent _agent;

        public TestDesignController(TestDesignAgent agent)
        {
            _agent = agent;
        }

        [HttpPost]
        public async Task<ActionResult<GenerateTestsResponse>> Generate([FromBody] GenerateTestsRequest request, CancellationToken cancToken)
        {
            var res = _agent.GenerateAsync(request);
            return Ok(res);
        }
    }
}
