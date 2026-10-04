using English_QA.Models;
using English_QA.Models.DatabaseModels;


namespace English_QA.Seeders
{
    public class Users_Seeder
    {
        public static void Seed(DBContext dBContext)
        {

            var salt = generateRandomString(8);
            var user = new List<Users>
            {
                new Users {Id = 1, Name = "Admin" , Username = "Admin", Salt = salt,Password= Encryption.Encryption.DoHash("@123456789"+ salt) ,UserTypeID = 1 }
            };
            dBContext.Users.AddRange(user);
            dBContext.SaveChanges();
        }

        private static string generateRandomString(int length)
        {
            Random rnd = new Random();
            const string chars = "JbgqdZzRp6e4rNvy44F6MH5KXyJpc9SBxrj3cnrzmhxhYvA1hrqQCPdyQTxm";
            return new string(Enumerable.Repeat(chars, length).Select(x => x[rnd.Next(length)]).ToArray());
        }
    }
}
