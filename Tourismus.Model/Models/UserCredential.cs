
namespace Tourismus.Model.Models {
    public class UserCredential {
        public int Id { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}