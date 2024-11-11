using BiryukovMkt_41_21.Interfaces.TeacherInterfaces;

namespace BiryukovMkt_41_21.ServiceExtensions
{
    public static class ServiceExtensions //Расширения услуг
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherGetterService, TeacherGetterService>();
            services.AddScoped<ITeacherModifierService, TeacherModifierService>();
            return services;
        }
    }
}
