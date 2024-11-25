using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PStudent.Data
{
    public class Student
    {
        public int StudentId { get; set; } // Первичный ключ

        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(100, ErrorMessage = "Имя не должно превышать 100 символов")]
        public string FirstName { get; set; } = string.Empty; // Имя

        [Required(ErrorMessage = "Фамилия обязательна")]
        [StringLength(100, ErrorMessage = "Фамилия не должна превышать 100 символов")]
        public string LastName { get; set; } = string.Empty; // Фамилия

        [Required(ErrorMessage = "Дата рождения обязательна")]
        // public DateTime DateOfBirth { get; set; } = DateTime.MinValue; // Дата рождения
        public DateTime DateOfBirth { get; set; } = new DateTime(DateTime.Now.Year - 18, 1, 1); // Предполагаемое совершеннолетие


        [Required]
        [RegularExpression("Мужской|Женский", ErrorMessage = "Выберите 'Мужской' или 'Женский'.")]
        public string Gender { get; set; } = string.Empty; // Пол (например, "Мужской", "Женский")

        [Required(ErrorMessage = "Паспортные данные обязательны")]
        [StringLength(50, ErrorMessage = "Паспортные данные не должны превышать 50 символов")]
        public string PassportData { get; set; } = string.Empty; // Паспортные данные

        [Required(ErrorMessage = "Дата поступления обязательна")]
        public DateTime EnrollmentDate { get; set; } = new DateTime(DateTime.Now.Year, 1, 1); // Дата поступления
        public DateTime? GraduationDate { get; set; } // Дата окончания (может быть null, если студент ещё учится)

        [StringLength(200, ErrorMessage = "Контактная информация не должна превышать 200 символов")]
        public string ContactInfo { get; set; } = string.Empty; // Контактная информация (телефон, email)

        [Required(ErrorMessage = "Выберите группу")]
        public int GroupId { get; set; } // Внешний ключ на группу
        public Group? Group { get; set; } // Навигационное свойство на группу

        [Required(ErrorMessage = "Выберите направление")]
        public int DirectionId { get; set; } // Внешний ключ на направление
        public Direction? Direction { get; set; } // Навигационное свойство на направление

        [Required(ErrorMessage = "Выберите тип оплаты")]
        public int PaymentTypeId { get; set; } // Внешний ключ на тип оплаты
        public PaymentType? PaymentType { get; set; } // Навигационное свойство на тип оплаты

        [Required(ErrorMessage = "Выберите тип обучения")]
        public int EducationTypeId { get; set; } // Внешний ключ на тип обучения
        public EducationType? EducationType { get; set; } // Навигационное свойство на тип обучения
    }

    public class Group
    {
        public int GroupId { get; set; } // Первичный ключ

        [Required(ErrorMessage = "Название группы обязательно")]
        [StringLength(100, ErrorMessage = "Название группы не должно превышать 100 символов")]
        public string GroupName { get; set; } = string.Empty; // Название группы

        public ICollection<Student> Students { get; set; } = new List<Student>(); // Студенты группы
    }

    public class Direction
    {
        public int DirectionId { get; set; } // Первичный ключ

        [Required(ErrorMessage = "Название направления обязательно")]
        [StringLength(100, ErrorMessage = "Название направления не должно превышать 100 символов")]
        public string DirectionName { get; set; } = string.Empty; // Название направления

        public ICollection<Student> Students { get; set; } = new List<Student>(); // Студенты на направлении
        public ICollection<Course> Courses { get; set; } = new List<Course>(); // Курсы направления
    }

    public class Course
    {
        public int CourseId { get; set; } // Первичный ключ

        [Required(ErrorMessage = "Название курса обязательно")]
        [StringLength(100, ErrorMessage = "Название курса не должно превышать 100 символов")]
        public string CourseName { get; set; } = string.Empty; // Название курса

        public int DirectionId { get; set; } // Внешний ключ на направление
        public Direction? Direction { get; set; } // Навигационное свойство на направление
    }

    public class PaymentType
    {
        public int PaymentTypeId { get; set; } // Первичный ключ

        [Required(ErrorMessage = "Название типа оплаты обязательно")]
        [StringLength(100, ErrorMessage = "Название типа оплаты не должно превышать 100 символов")]
        public string PaymentName { get; set; } = string.Empty; // Название типа оплаты

        public ICollection<Student> Students { get; set; } = new List<Student>(); // Студенты с данным типом оплаты
    }

    public class EducationType
    {
        public int EducationTypeId { get; set; } // Первичный ключ

        [Required(ErrorMessage = "Название типа обучения обязательно")]
        [StringLength(100, ErrorMessage = "Название типа обучения не должно превышать 100 символов")]
        public string TypeName { get; set; } = string.Empty; // Название типа обучения

        public ICollection<Student> Students { get; set; } = new List<Student>(); // Студенты с данным типом обучения
    }
}