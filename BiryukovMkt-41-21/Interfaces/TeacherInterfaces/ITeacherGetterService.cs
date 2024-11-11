using BiryukovMkt_41_21.Database;
using BiryukovMkt_41_21.Filters;
using BiryukovMkt_41_21.Models;
using Microsoft.EntityFrameworkCore;

namespace BiryukovMkt_41_21.Interfaces.TeacherInterfaces
{
    public interface ITeacherGetterService
    {
        public Task<Teacher[]> GetTeachersByDegreeAsync(TeacherDegreeFilter filter, CancellationToken cancellationToken = default);

        public Task<Teacher[]> GetTeachersByCathedraAsync(TeacherCathedraFilter filter, CancellationToken cancellationToken = default);

        public Task<Teacher[]> GetTeachersByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken = default);

        public Task<Teacher[]> GetTeachersByFIOAsync(TeacherFIOFilter filter, CancellationToken cancellationToken = default);


    }

    public class TeacherGetterService : ITeacherGetterService //Реализация интерфейса
    {
        private readonly TeacherDbContext _dbContext; // Поле для хранения контекста базы данных, которое будет использоваться для выполнения запросов

        public TeacherGetterService(TeacherDbContext dbContext) // Конструктор, который принимает контекст базы данных и инициализирует поле _dbContext
        {
            _dbContext = dbContext;
        }
        public Task<Teacher[]> GetTeachersByDegreeAsync(TeacherDegreeFilter filter, CancellationToken cancellationToken = default)  //Реализация методов
        {  //Каждый из методов реализует логику получения преподавателей на основе переданных фильтров
            var teachers = _dbContext.Set<Teacher>().Where(t => t.Degree == filter.Degree).ToArrayAsync();
            return teachers;
        } // Использует фильтр TeacherDegreeFilter для получения преподавателей с определенной степенью   ToArrayAsync() выполняет асинхронный запрос к базе данных и возвращает массив преподавателей

        public Task<Teacher[]> GetTeachersByCathedraAsync(TeacherCathedraFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teacher>().Where(t => t.Cathedra.Name == filter.CathedraName).ToArrayAsync();
            return teachers;
        }

        public Task<Teacher[]> GetTeachersByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teacher>().Where(t => t.Position == filter.Position).ToArrayAsync();
            return teachers;
        }

        public Task<Teacher[]> GetTeachersByFIOAsync(TeacherFIOFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teacher>().Where(t => t.FirstName == filter.FirstName && t.LastName == filter.LastName && t.MiddleName == filter.MiddleName).ToArrayAsync();
            return teachers;
        }

    }
}
