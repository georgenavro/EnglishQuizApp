using English_QA.Models;
using English_QA.Models.DatabaseModels;

namespace English_QA.Seeders
{
    public class UserType_Seeder
    {
        public static void Seed(DBContext dBContext)
        {     
                var userType = new List<Usertype>
                {
                    new Usertype { Id = 1, UserType = "Admin" },
                    new Usertype { Id = 2, UserType = "User" }
                };
                dBContext.UserType.AddRange(userType);
                dBContext.SaveChanges();
        }
    }
}
