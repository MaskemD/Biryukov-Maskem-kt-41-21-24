using System.Text.Json.Serialization;

namespace BiryukovMkt_41_21.Models
{
    public class Teacher
    {
        // [JsonIgnore] //при сериализации объекта в JSON этот свойство должно игнорироваться. То есть, оно не будет включено в JSON-представление объекта
        [JsonIgnore]
        public int TeacherId { get; set; }

        public required string FirstName { get; set; } = string.Empty;

        public required string LastName { get; set; } = string.Empty;

        public required string MiddleName { get; set; } = string.Empty;
        public required string Position { get; set; }

        public string? Degree { get; set; }

        public int CathedraId { get; set; }

        [JsonIgnore]
        public Cathedra? Cathedra { get; set; }

        public bool HasAcademicDegree() => Degree != null;
    }
}
