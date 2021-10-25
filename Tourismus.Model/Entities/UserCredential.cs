using Tourismus.Model.Configuration._Infrastructure;

namespace Api.Model.Database {
    public partial class UserCredential : ModelBase {
        public UserCredential() { }

        public string Hash { get; set; }
        public string Salt { get; set; }
    }
}
