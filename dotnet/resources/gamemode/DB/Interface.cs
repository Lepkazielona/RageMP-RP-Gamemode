//  functions for comunicating with DB 

using System;
using System.Threading.Tasks;

namespace DB
{
    public class Inteface
    {
        public async Task createUser(string nickname, string password, string passwordSol,int rank, DateTime creationDate, long gametime = 0)
        {
            try
            {
                using(var context = new DBContext())
                {
                    context.Users.AddAsync(new User
                    {
                        nickname = nickname,
                        password = password,
                        passwordSol = passwordSol,
                        creationDate = creationDate,
                        rank = rank,
                        gameTime = gametime
                    });
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}