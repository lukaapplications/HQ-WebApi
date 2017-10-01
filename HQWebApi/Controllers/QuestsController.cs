using HQWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HQWebApi.Controllers
{
    public class QuestsController : ApiController
    {
        Quest[] quests = new Quest[]
        {
            new Quest { Id = 1, Name = "Tomato Soup", Type = "Groceries"},
            new Quest { Id = 2, Name = "Yo-yo", Type = "Toys"},
            new Quest { Id = 3, Name = "Hammer", Type = "Hardware"}
        };

        public IEnumerable<Quest> GetAllQuests()
        {
            return quests;
        }

        public IHttpActionResult GetQuest(int id)
        {
            var quest = quests.FirstOrDefault((p) => p.Id == id);
            if (quest == null)
            {
                return NotFound();
            }
            return Ok(quest);
        }
    }
}
