using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.DB;
using WebApplication2.Models.Request;
using WebApplication2.Models.Response;
namespace WebApplication2.Controllers
{
    [ApiController]
    public class PlayController : Controller
    {

        private readonly DataContext _db;


        /* private readonly ILogger<PlayController> _logger;

         public PlayController(ILogger<PlayController> logger)
         {
             _logger = logger;
         }*/
        public PlayController(DataContext context)
        {
            _db = context;
        }

        [HttpPost("new")]
        public async Task<IActionResult> PostNew([FromBody] NewGameRequest newGame)
        {
            if (!newGame.CheckСonditions() || !ModelState.IsValid)
                return BadRequest(new { message = "Ошибка запроса" });

            var fieldArray = FieldManager.CreateFieldUser(newGame.width, newGame.height);
            var fieldList = Converter.TwoDimensionalToList(fieldArray);
            var gId = CodeGenerator.GenerateCode();
            PlaySession session = new PlaySession()
            {
                GameId = gId,
                Height = newGame.height,
                Width = newGame.width,
                OneMove = true,
                ServerField = Converter.TwoDimensionalToString(fieldArray),
                UserField = Converter.TwoDimensionalToString(fieldArray),
                MinesCount = newGame.mines_count
            };

            _db.playSessions.Add(session);
            await _db.SaveChangesAsync();
            return Ok(new GameInfoResponse(gId, newGame.width, newGame.height, newGame.mines_count, fieldList));
        }

        [HttpPost("turn")]
        public async Task<IActionResult> PostTurn([FromBody] GameTurnRequest gameTurn)
        {
            PlaySession session = await _db.playSessions.FindAsync(gameTurn.game_id);
            if (session == null)
                return BadRequest(new { message = "Игры не существует или она завершена!" });

            string fieldBomb = null;
            string fieldUser = session.UserField;

            if (Move.OpenCell(session.UserField, gameTurn.col, gameTurn.row, session.Width))
                return BadRequest(new { message = "Клетка уже открыта!" });

            if (session.OneMove == true)
            {
                fieldBomb = Converter.TwoDimensionalToString(FieldManager.CreateFieldFull(session.Width, session.Height, session.MinesCount, gameTurn.row, gameTurn.col));
                session.ServerField = fieldBomb;
                session.OneMove = false;
            }
            else
                fieldBomb = session.ServerField;

            var result = Move.StringUserMove(fieldUser, fieldBomb, gameTurn.col, gameTurn.row, session.Height, session.Width);
            if (result.Item1 == false)
            {
                _db.playSessions.Remove(session);
                await _db.SaveChangesAsync();
                return Ok(new GameInfoResponse(gameTurn.game_id, session.Width, session.Height,
                                               session.MinesCount, Converter.StringToList(result.Item2, session.Height, session.Width), true));
            }



            session.UserField = result.Item2;
            await _db.SaveChangesAsync();
            return Ok(new GameInfoResponse(gameTurn.game_id, session.Width, session.Height,
                                               session.MinesCount, Converter.StringToList(result.Item2, session.Height, session.Width)));
        }

    }
}
