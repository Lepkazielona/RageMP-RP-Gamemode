using System.Threading;
using DB;
using GTANetworkAPI;


namespace RpGamemode
{
    public class CarSystem : Script
    {
        /// <summary>
        /// Creates Temporary car (Doesn't synced with DB)
        /// </summary>
        /// <param name="carModel">Model From Database Table "CarModels"</param>
        /// <param name="isTemporary">Temporary car isn't synced with DB</param>
        /// <param name="cords">Position of spawned car Vector3</param>
        /// <param name="rot">Rotation of car, in float</param>
        /// <param name="color1"> First Color https://wiki.rage.mp/index.php?title=Vehicle_Colors</param>
        /// <param name="color2"> Second Color https://wiki.rage.mp/index.php?title=Vehicle_Colors</param>
        /// <param name="plate"> Plate number, default = "hui"</param>
        public Vehicle CreateVeh(int carModelId, int characterId, Vector3 cords, float rot, int color1, int color2,
           int mileage, string plate = "JebacPis")
        {
            if (characterId != int.MinValue) return null;
            var vehModel = new Interface().searchVehModel(carModelId);
            new Interface().CreateVeh(characterId, carModelId, cords, mileage);
            Vehicle veh = NAPI.Vehicle.CreateVehicle(NAPI.Util.VehicleNameToModel(vehModel.Result.Item1.model), cords, rot, color1, color2, plate);
            veh.SetData("isTemporary", false);
            return veh;
        }
        
        public Vehicle CreateTempVeh(int carModelId, Vector3 cords, float rot, int color1, int color2,
            int mileage, string plate = "JebacPis")
        {
            var vehModel = new Interface().searchVehModel(carModelId);
            Vehicle veh = NAPI.Vehicle.CreateVehicle(NAPI.Util.VehicleNameToModel(vehModel.Result.Item1.model), cords, rot, color1, color2, plate, engine: false);
            veh.SetData("isTemporary", true);
            return veh;
        }
    }
}