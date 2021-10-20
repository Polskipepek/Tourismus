namespace Api.Model.Database {
    public partial class UserCredential {
        public UserCredential() { }

        public int Id { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
    }
}
