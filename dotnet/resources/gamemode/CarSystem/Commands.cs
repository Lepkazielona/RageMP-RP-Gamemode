using DB;
using GTANetworkAPI;

namespace RpGamemode
{
    public class Commands : Script
    {
        //creates new temp vehicle
        [Command("nveh", "/nveh [Car Model ID], color id 1 = 120, color id 2 = 120, rejestracja = null, przebieg = 0")]
        public void CmdNVeh(Player player, int id,int color1 = 120, int color2 = 120, string plate = "JebacPis",  int mileage = 0)
        {
            player.SendNotification("~b~Spawning your car...");
            new CarSystem().CreateTempVeh(id, player.Position.Around(2), player.Rotation.X, color1, color2, mileage, plate);
            player.SendNotification("~g~Done!", false);
        }
        //creates new vehicle and seves it in DB
        [Command("nsveh")]
        public void CmdNSVeh()
        {
            //todo
        }

        [Command("restore", "/restore [car ID]")]
        public void CmdRestore(Player player, int carId)
        {
            Car car = new DB.Interface().searchCar(carId).Result;
            NAPI.Vehicle.CreateVehicle(NAPI.Util.VehicleNameToModel(car.CarModel.model), new Vector3(car.x, car.y, car.z), car.rot, car.color1, car.color2, car.plate, engine: false);
        }
    }
}