using BiryukovMkt_41_21.Database;
using BiryukovMkt_41_21.Models;
using BiryukovMkt_41_21.Interfaces.TeacherInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace BiryukovMkt_41_21.Interfaces.TeacherInterfaces
{
    public interface ITeacherModifierService
    {
        Task CreateTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default);
        Task EditTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default);
        Task RemoveTeacherAsync(int teacherId, CancellationToken cancellationToken = default);
        Task RemoveTeacherByCathedraAndLastnameAsync(int cathedraId, string lastname, CancellationToken cancellationToken = default);
    }

    public class TeacherModifierService : ITeacherModifierService
    {
        private readonly TeacherDbContext _dbContext;

        public TeacherModifierService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            bool isTeacherExists = await _dbContext.Set<Teacher>().AnyAsync(t => t.TeacherId == teacher.TeacherId, cancellationToken);
            if (isTeacherExists)
            {
                throw new KeyNotFoundException($"Преподаватель с таким идентификатором уже существует!");
            }

            await _dbContext.Set<Teacher>().AddAsync(teacher, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task EditTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            var existingTeacher = await _dbContext.Set<Teacher>().FindAsync(new object[] { teacher.TeacherId }, cancellationToken);
            if (existingTeacher == null)
            {
                throw new KeyNotFoundException($"Преподаватель не найден!");
            }

            // Обновляем поля существующего преподавателя
            existingTeacher.FirstName = teacher.FirstName;
            existingTeacher.LastName = teacher.LastName;
            existingTeacher.MiddleName = teacher.MiddleName;
            existingTeacher.Position = teacher.Position;
            existingTeacher.Degree = teacher.Degree;
            existingTeacher.CathedraId = teacher.CathedraId;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveTeacherAsync(int teacherId, CancellationToken cancellationToken = default)
        {
            var teacher = await _dbContext.Set<Teacher>().FindAsync(new object[] { teacherId }, cancellationToken);
            if (teacher == null)
            {
                throw new KeyNotFoundException($"Преподаватель не найден!");
            }

            _dbContext.Set<Teacher>().Remove(teacher);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveTeacherByCathedraAndLastnameAsync(int cathedraId, string lastname, CancellationToken cancellationToken = default)
        {
            var teacher = await _dbContext.Set<Teacher>()
                .FirstOrDefaultAsync(t => t.CathedraId == cathedraId && t.LastName == lastname, cancellationToken);

            if (teacher == null)
            {
                throw new KeyNotFoundException($"Преподаватель с фамилией {lastname} и кафедрой с ID {cathedraId} не найден!");
            }

            _dbContext.Set<Teacher>().Remove(teacher);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

