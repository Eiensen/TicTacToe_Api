namespace TestTask_TicTacToeApi.Controllers
{
    /// <summary>
    /// Контроллер Web Api для работы с полем для игры в Крестики-Нолики
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly IRepository _repository;

        public FieldController(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Запрос на получение текущего поля игры
        /// </summary>
        /// <returns>Возвращает объект с текущим сотоянием</returns>
        /// <response code="201">Возвращает текущее поле</response>
        /// <response code="400">Если поле получить не удалось</response>  
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public ActionResult GetField()
        {
            var field = JsonDocument.Parse(_repository.GetCurrentFeald());

            if(field != null)
            {
                return Ok(field);
            }

            return BadRequest();
        }

        /// <summary>
        /// Передаем в запрос ключ ячейки и ее значение
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Field
        ///     {        
        ///        "key": "A1",
        ///        "value": "x"
        ///     }
        ///
        /// </remarks>
        /// <param name="cellKey">Ключ ячейки</param>
        /// <param name="cellValue">Значение ячейки</param>
        /// <returns>Возвращает поле с обновленными ячейками</returns>
        /// <response code="201">Возвращает обновленное поле</response>
        /// <response code="400">Если поле получить не удалось</response>  
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult UpdateFieldAfterTurn(string cellKey, string cellValue)
        {
            var updatedCells = new CurrentCells();

            var field = JsonDocument.Parse(_repository.UpdateFieldAfterTurn(cellKey, cellValue));

            if(field != null)
            {
                updatedCells.CurrentFealdJson = field;
                updatedCells.GameStatus = _repository.GameResult.ToString();

                return Ok(updatedCells);
            }

            return BadRequest();
        }

        /// <summary>
        /// Запрос на получение очищенного поля с чистыми ячейками
        /// </summary>
        /// <returns>Возвращает новое поле с очищенными ячейками</returns>
        /// <response code="201">Возвращает новое поле</response>
        /// <response code="400">Если поле получить не удалось</response>  
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("api/continue")]
        public ActionResult ContinueGame() 
        {
            var field = JsonDocument.Parse(_repository.GetSavedField());

            if(field != null)
            {
                return Ok(field);
            }
            
            return BadRequest();
        }
    }
}
