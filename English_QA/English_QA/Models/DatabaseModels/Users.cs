namespace English_QA.Models.DatabaseModels
{
    public class Users
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public long UserTypeID { get; set; }
        public Usertype? userType { get; set; }

    }
}
