using HQWebApi.Models;
using HQWebApi.SQL;
using System.Web.Http;

namespace HQWebApi.Controllers
{
    public class PlayersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetPlayer(int id)
        {
            var player = PlayerProvider.GetPlayer(id);

            if (player == null)
            {
                return NotFound();
            }            

            return Ok(player);
        }

        [HttpPut]
        [Route("~/api/players/create")]
        public IHttpActionResult PutPlayer([FromBody] Player player)
        {
            var result = PlayerProvider.CreatePlayer(player.Name);
           
            return Ok(result);
        }

        [HttpPut]
        [Route("~/api/players/update")]
        public IHttpActionResult UpdatePlayer([FromBody] Player player)
        {
            var result = PlayerProvider.UpdatePlayer(player);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
