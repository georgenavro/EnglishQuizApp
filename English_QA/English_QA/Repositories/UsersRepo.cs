using English_QA.Auth;
using English_QA.Encryption;
using English_QA.Models;
using English_QA.Models.DatabaseModels;
using English_QA.Models.DTO;
using English_QA.Models.RequestBody;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;

using System.Text;

namespace English_QA.Repositories
{
    public class UsersRepo
    {
        public DBContext dbContext;
        public JWTSettings jwtSettings;
        public UsersRepo(DBContext dbcontext,JWTSettings jwtSettngs) 
        {
            dbContext = dbcontext;
            jwtSettings = jwtSettngs;
        }

        public async Task<Users> Create(Users entity)
        {
            try
            {
                var username = await dbContext
                    .Users.Where(us=> us.Username.ToLower() == entity.Username.ToLower())
                    .FirstOrDefaultAsync(); 

                if(username != null)
                {
                    return null;
                }
                else if (entity.Username == "" || entity.Password == "")
                {
                    entity.UserTypeID += 1;
                    return entity;
                }

                    entity.Salt = generateRandomString(8);
                entity.Password = Encryption.Encryption.DoHash(entity.Password + entity.Salt);
                dbContext.Users.Add(entity);
                await dbContext.SaveChangesAsync();
                return entity;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Users> Edit(Users entity)
        {
            try
            {
                var user = await dbContext.Users.FindAsync(entity.Id);

                var exist = await dbContext.Users
                    .Where(us => us.Username == entity.Username)
                    .FirstOrDefaultAsync();

                if(exist != null || user == null)
                {
                    return null;
                }

                if (!string.IsNullOrEmpty(entity.Name))
                {
                    user.Name = entity.Name;
                }

                if (!string.IsNullOrEmpty(entity.Username))
                {
                    user.Username = entity.Username;
                    
                }

                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Salt = generateRandomString(8);
                    user.Password =  Encryption.Encryption.DoHash(entity.Password + entity.Salt);
                   
                }

                dbContext.Users.Update(user);
                await dbContext.SaveChangesAsync();
                return entity;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var exist = await dbContext.Users.FindAsync(id);

                if(exist == null)
                {
                    return false;
                }
                dbContext.Users.Remove(exist);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<Users>?> GetUsersByUserType([FromBody]long usersTypeID)
        {
            try
            {
                var results = await dbContext.Users
                    .Where(ust => ust.UserTypeID == usersTypeID)
                    .Include(ust => ust.userType)
                    .ToListAsync();
                if(results == null)
                {
                    return null;
                }

                return results;

            }
            catch
            {
                return null;
            }
        }

        public async Task<LoginDTO?> login(LoginBody loginUser)
        {
            try
            {
                var exist = await dbContext.Users
                    .Where(us=> us.Username.ToLower() == loginUser.Username.ToLower())
                    .Include(us=> us.userType)
                    .FirstOrDefaultAsync();
                
                if (exist == null)
                {
                    return null;
                }

                loginUser.Password = Encryption.Encryption.DoHash(loginUser.Password + exist.Salt);

                if (exist.Password != loginUser.Password)
                {
                    return null;
                }
                var login_return = new LoginDTO();
                login_return.Id = exist.Id;
                login_return.jwtToken = generateJWTToken(exist);
                login_return.username = exist.Name;

                return login_return;
            }
            catch
            {
                return null;
            }

        }

        public string generateJWTToken(Users user)
        {
            try
            {
                if (user == null || user.userType == null) 
                {
                    return string.Empty;
                }
                var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTSettings.SecurityKey));

                var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,user.Username),
                    new Claim(ClaimTypes.Name,user.Name),
                    new Claim(ClaimTypes.Role, user.userType.UserType),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
                var token = new JwtSecurityToken(
                    issuer: JWTSettings.Issuer,
                    audience: JWTSettings.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(2),
                    signingCredentials: credentials
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
                throw;
            }
        }
        private static string generateRandomString(int length)
        {
            Random rnd = new Random();
            const string chars = "JbgqdZzRp6e4rNvy44F6MH5KXyJpc9SBxrj3cnrzmhxhYvA1hrqQCPdyQTxm";
                return new string(Enumerable.Repeat(chars,length).Select(x => x[rnd.Next(length)]).ToArray());
        }
        
    }
}
