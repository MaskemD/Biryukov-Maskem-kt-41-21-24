using System.Text.Json.Serialization;

namespace BiryukovMkt_41_21.Models
{
    public class Cathedra
    {
        public int CathedraId { get; set; }

        public required string Name { get; set; }

        public int? HeadTeacherId { get; set; }

        [JsonIgnore]
        public Teacher? HeadTeacher { get; set; }
    }
}
