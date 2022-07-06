//  functions for comunicating with DB 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class Interface
    {
        public async Task<Exception> CreateUser(string nickname, string password, string passwordSol, int rank,
            DateTime creationDate, long gametime = 0)
        {
            try
            {
                using (var context = new DBContext())
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
                return e;
            }

            return null;
        }
        
         
        public async Task<Exception> CreateVeh(int x, int y, int z, int mileage, int)
        {
            try
            {
                using (var context = new DBContext())
                {
                    context.Cars.AddAsync(new Car(
                    {
                        x = x,
                        y = y,
                        z = z,
                        mileage = mileage,
                        Owner = 
                    });
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return e;
            }

            return null;
        }
         

        /// <summary>
        ///  Returns model from database
        /// </summary>
        /// <param name="name">Name of car in DB</param>
        /// <returns>Return Tuple (CarModel, Exception)</returns>
        public async Task<(List<CarModel>, Exception)> searchVehModel(int DBId)
        {
            try
            {
                await using (var context = new DBContext())
                {
                    var carModels = context.CarModels
                        .Where(b => b.ID.Equals(DBId))
                        .ToList();
                    return (carModels, null);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (null, e);
                //throw;

            }
        }

    }
}
