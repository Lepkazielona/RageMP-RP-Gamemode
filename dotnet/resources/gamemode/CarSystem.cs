using System.Threading;
using GTANetworkAPI;


namespace RpGamemode
{
    public class CarSystem : Script
    {


        [Command("newveh", "/newtempcar")]
        public void CmdNewTempCar(Player player, string model, float rot = 0f, int color1 = 200, int color2 = 200, string plate = ":)")
        {
            
            //CreateTempCar(NAPI.Util.GetHashKey(model), new Vector3(-426,1154,325), rot, color1, color2, plate);
        }
/*
        [Command("poj")]
        public void PojCmd(Player player, string veh)
        {
//            NAPI.Vehicle.CreateVehicle(NAPI.Util.VehicleNameToModel(veh), player.Position,0f, 2, 2)
            NAPI.Vehicle.CreateVehicle(NAPI.Util.VehicleNameToModel(veh), player.Position.Around(5), player.Rotation, 140,140, ":)");

        }
  */      
        
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
        public GTANetworkAPI.Vehicle CreateVeh(string carModel,bool isTemporary, GTANetworkAPI.Vector3 cords, float rot, int color1, int color2, string plate = "hui")
        {
            //NAPI.Task.Run();
            if (isTemporary)
            {
                GTANetworkAPI.Vehicle veh = NAPI.Vehicle.CreateVehicle(NAPI.Util.VehicleNameToModel(carModel), cords, rot, color1, color2, plate);
                veh.SetData("isTemporary", true);
                return veh;
            }
            else
            {
                var dbCall = new DB.Interface().searchVehModel(carModel);
                if (dbCall.Result.Item2 != null)
                {
                    
                }
            }

            return null;
        }
    }
}