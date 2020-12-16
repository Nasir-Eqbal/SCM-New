using Microsoft.AspNetCore.Mvc;
using SCM.RuleEngine.Core;
using SCM.RuleEngine.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SCM.RuleEngine.API.Controllers
{
    [Route("api/[ruleengine]")]
    [ApiController]
    public class RuleEngineController : ControllerBase
    {
        private readonly IPaymentRuleEvaluator _ruleEvaluator;
        public RuleEngineController(IPaymentRuleEvaluator ruleEvaluator)
        {
            _ruleEvaluator = ruleEvaluator;
        }

        /// <summary>
        /// Order object has to be passed
        /// </summary>
        /// <param name="idOrUserName">Users id or username to unexpire password</param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> ProcessPaymentRule([FromBody] Order orderModel)
        {
            var processRule = await _ruleEvaluator.EvaluateRule(orderModel);

            return Ok(processRule);
        }

    }
}
