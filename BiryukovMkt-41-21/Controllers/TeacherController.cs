using BiryukovMkt_41_21.Filters;
using BiryukovMkt_41_21.Interfaces.TeacherInterfaces;
using BiryukovMkt_41_21.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiryukovMkt_41_21.Controllers
{
    [ApiController] //Атрибут, который указывает, что этот класс является контроллером API. Он включает в себя некоторые улучшения, такие как автоматическая обработка ошибок и валидация моделей
    [Route("[controller]")] //Определяет маршрут для контроллера. [controller] будет заменен на имя контроллера без суффикса "Controller", т.е. на "teacher".
    public class TeacherController : ControllerBase
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly ITeacherGetterService _teacherGetterService;
        private readonly ITeacherModifierService _teacherModifierService;

        public TeacherController(ILogger<TeacherController> logger, ITeacherGetterService teacherGetterService, ITeacherModifierService teacherModifierService)
        {
            _logger = logger;
            _teacherGetterService = teacherGetterService;
            _teacherModifierService = teacherModifierService;
        }
        [HttpPost("GetTeachersByCathedra")] //Получение преподавателей по кафедре
        public async Task<IActionResult> GetTeachersByCathedraAsync(TeacherCathedraFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherGetterService.GetTeachersByCathedraAsync(filter, cancellationToken);
            return Ok(teachers);
        }


        [HttpPost("GetTeachersByDegree")]
        public async Task<IActionResult> GetTeachersByDegreeAsync(TeacherDegreeFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherGetterService.GetTeachersByDegreeAsync(filter, cancellationToken);
            return Ok(teachers);
        }

        [HttpPost("GetTeachersByPosition")]
        public async Task<IActionResult> GetTeachersByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherGetterService.GetTeachersByPositionAsync(filter, cancellationToken);
            return Ok(teachers);
        }

        [HttpPost("GetTeachersByFIO")]
        public async Task<IActionResult> GetTeachersByFIOAsync(TeacherFIOFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherGetterService.GetTeachersByFIOAsync(filter, cancellationToken);
            return Ok(teachers);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            await _teacherModifierService.CreateTeacherAsync(teacher, cancellationToken);
            return Ok();
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> EditTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            await _teacherModifierService.EditTeacherAsync(teacher, cancellationToken);
            return Ok();
        }

        [HttpPost("Remove")]
        public async Task<IActionResult> RemoveTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            await _teacherModifierService.RemoveTeacherAsync(teacher, cancellationToken);
            return Ok();
        }
    }
}
