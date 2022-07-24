//  functions for comunicating with DB 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    //TODO document all functions
    //Someone should do this
    //this code sucks ass :{
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
        
         
        public async Task<Exception> CreateVeh(int characterId, int carModelId, Vector3 coords, int mileage)
        {
            try
            {
                using (var context = new DBContext())
                {
                    var character = context.Characters
                        .Where(b => b.ID.Equals(characterId))
                        .ToList();
                    var carModel = context.CarModels
                        .Where(b => b.ID.Equals(carModelId))
                        .ToList();
                    
                    await context.Cars.AddAsync(new Car
                    {
                        x = (int) coords.X,
                        y = (int) coords.Y,
                        z = (int) coords.Z,
                        mileage = mileage,
                        Owner = character[0],
                        CarModel = carModel[0]
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
         
        /*
         *
         * Query stuff
         * 
         */

        public async Task<DB.Car> searchCar(int carId)
        {
            try
            {
                await using (var context = new DBContext())
                {
                    var car = context.Cars
                        .Where(b => b.ID.Equals(carId))
                        .FirstOrDefaultAsync();
                    return car.Result;
                    //return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        /// <summary>
        ///  Returns model from database
        /// </summary>
        /// <param name="name">Name of car in DB</param>
        /// <returns>Return Tuple (CarModel, Exception)</returns>
        public async Task<(CarModel, Exception)> searchVehModel(int DBId)
        {
            try
            {
                await using (var context = new DBContext())
                {
                    var carModels = context.CarModels
                        .Where(b => b.ID.Equals(DBId))
                        .ToList();
                    return (carModels[0], null);
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
