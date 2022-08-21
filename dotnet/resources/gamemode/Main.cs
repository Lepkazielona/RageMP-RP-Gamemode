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
            RPApi.Chat.sendMsg(player, "test");
            IDSystem.initializeID(player);
         
            Console.WriteLine(player.Serial);
            Console.WriteLine(player.SocialClubId);
        }
        
        [Command("myid", "/myid")]
        public void CMD_MyID(Player player)
        { 
        
            //RPApi.Chat.sendMsg(player, "wssdasdasdakxncaksdnaskdnasknd");
            //RPApi.Chat.sendMsg(player, $"ur id: {player.GetSharedData<int>("ID")}");
            //player.SendNotification("Twoje ID: " + player.GetSharedData<int>("ID"));
            player.SendNotification("twoje id   " + IDSystem.getID(player));
        }
        
    }
}
