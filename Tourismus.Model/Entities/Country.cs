#nullable disable

namespace Api.Model.Database {
    public partial class Country {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual City City { get; set; }
    }
}
