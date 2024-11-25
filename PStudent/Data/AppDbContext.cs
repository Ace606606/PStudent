using Microsoft.EntityFrameworkCore;

namespace PStudent.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets для моделей
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<EducationType> EducationTypes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Course> Courses { get; set; }

        // Метод для добавления начальных данных
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Типы обучения
            modelBuilder.Entity<EducationType>().HasData(
                new EducationType { EducationTypeId = 1, TypeName = "Очное" },
                new EducationType { EducationTypeId = 2, TypeName = "Заочное" },
                new EducationType { EducationTypeId = 3, TypeName = "Очно-заочное" }
            );

            // Формы оплаты
            modelBuilder.Entity<PaymentType>().HasData(
                new PaymentType { PaymentTypeId = 1, PaymentName = "Бюджет" },
                new PaymentType { PaymentTypeId = 2, PaymentName = "Контракт" }
            );

            // Направления (например, для IT)
            modelBuilder.Entity<Direction>().HasData(
                new Direction { DirectionId = 1, DirectionName = "Программирование" },
                new Direction { DirectionId = 2, DirectionName = "Сетевые технологии" },
                new Direction { DirectionId = 3, DirectionName = "Информационная безопасность" }
            );

            // Добавление начальных данных для курсов
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, CourseName = "Основы программирования", DirectionId = 1 },
                new Course { CourseId = 2, CourseName = "Алгоритмы и структуры данных", DirectionId = 1 },
                new Course { CourseId = 3, CourseName = "Сетевые технологии", DirectionId = 2 },
                new Course { CourseId = 4, CourseName = "Операционные системы", DirectionId = 2 },
                new Course { CourseId = 5, CourseName = "Информационная безопасность", DirectionId = 3 },
                new Course { CourseId = 6, CourseName = "Технологии баз данных", DirectionId = 3 },
                new Course { CourseId = 7, CourseName = "Математика для программистов", DirectionId = 1 }
                    );

            // Группы (например, ИБ-22вп, ИТ-23, и т.д.)
            modelBuilder.Entity<Group>().HasData(
                new Group { GroupId = 1, GroupName = "ИБ-22вп" },
                new Group { GroupId = 2, GroupName = "ИБ-23вп" },
                new Group { GroupId = 3, GroupName = "ИТ-22вп" },
                new Group { GroupId = 4, GroupName = "ИТ-23вп" }
            );
        }
    }
}