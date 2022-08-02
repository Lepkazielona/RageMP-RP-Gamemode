using System;
using System.IO;
using System.Threading.Tasks;
using GTANetworkAPI;

using Microsoft.EntityFrameworkCore;
using DB;
using Object = GTANetworkAPI.Object;

///
/// Registering Events Here
/// 

namespace RpGamemode
{
    public class Main : Script
    {
        //private IDSystem _idSystem = new IDSystem();
        public StreamReader ConfigReader = File.OpenText("config.toml");
        
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {

            using (var context = new DB.DBContext())
            {
                context.Database.EnsureCreated();
                context.SaveChanges();
                Console.WriteLine("Datbase Synced");
            }
            /*
        new Inteface().createUser("Lpk", "asdasd", "aasdasd", 7, DateTime.Now);
    */
        }

        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Player player)
        {
            IDSystem.initializeID(player);
        }
        
        [Command("myid", "/myid")]
        public void CMD_MyID(Player player)
        { 
            player.SendNotification("Twoje ID: " + player.GetSharedData<int>("ID"));
            //player.SendNotification("twoje id   " + new IDSystem().getIDFromPlayer(player));
        }
        
    }
}
