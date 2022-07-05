using GTANetworkAPI;

namespace RpGamemode
{
    public class CarSystem
    {
        /// <summary>
        /// Creates Temporary car (Doesn't synced with DB)
        /// </summary>
        /// <param name="carModel"> Model of car from Database table "CarModel"</param>
        /// <param name="r"> Red</param>
        /// <param name="g"> Green</param>
        /// <param name="b"> Blue</param>
        /// <param name="plate"> Plate number</param>
        public void CreateTempCar(string carModel, Vector3 cords, Vector3 rot, int r, int g, int b, string plate = ":)")
        {
           // NAPI.Vehicle.CreateVehicle(carModel);
        }
    }
}