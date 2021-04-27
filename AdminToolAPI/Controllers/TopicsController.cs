using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminToolsLogic.Logic;
using AdminToolsModels.LogicModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdminToolAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicsController : ControllerBase
    {
        private readonly TopicLogic _topicLogic;

        TopicsController(TopicLogic _topicLogic)
        {
            this._topicLogic = _topicLogic;
        }

        /// <summary>
        /// Get list of topics
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTopics()
        {
            return Ok(_topicLogic.GetSubjects());
        }

        
    }
}