using edTechSpark.Core.Entities;
using edTechSpark.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using edTechSpark.Services.Interfaces;
using edTechSpark.Services.Implementations;
using edTechSpark.Core;
using edTechSpark.Repositories.Implementations;

namespace edTechSpark.Services.Configuration
{
    public static class ConfigureDependencies
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            services.AddScoped<DbContext, AppDbContext>();

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<Course>, Repository<Course>>();
            services.AddScoped<IRepository<Mentor>, Repository<Mentor>>();
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<IRepository<CourseTopic>, Repository<CourseTopic>>();
            services.AddScoped<IRepository<CourseLesson>, Repository<CourseLesson>>();
            services.AddScoped<IRepository<Subscription>, Repository<Subscription>>();

            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

            services.AddScoped<IRepository<CartItem>, Repository<CartItem>>();
            services.AddScoped<IRepository<OrderItem>, Repository<OrderItem>>();
            services.AddScoped<IRepository<PaymentDetail>, Repository<PaymentDetail>>();

            //Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IService<Course>, Service<Course>>();
            services.AddScoped<IService<CourseTopic>, Service<CourseTopic>>();
            services.AddScoped<IService<CourseLesson>, Service<CourseLesson>>();
            services.AddScoped<IService<Category>, Service<Category>>();
            services.AddScoped<IService<Subscription>, Service<Subscription>>();
            services.AddScoped<IService<Mentor>, Service<Mentor>>();

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IMentorService, MentorService>();
        }
    }
}
