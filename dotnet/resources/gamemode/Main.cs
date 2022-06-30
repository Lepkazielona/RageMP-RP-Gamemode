using System;
using System.Threading.Tasks;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using DB;

namespace RpGamemode
{
    public class Main : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            
            
            using (var context = new DB.DBContext())
            {
                context.Database.EnsureCreated();
                context.SaveChanges();
            }
            new Inteface().createUser("Lpk", "asdasd", "aasdasd", 7, DateTime.Now);
        }
        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Player player)
        {
            new IDSystem().InitializeID(player);
        }
        
        [Command("myid", "/myid")]
        public void CMD_MyID(Player player)
        { 
            player.SendNotification("twoje id   " + new IDSystem().getIDFromPlayer(player));
        }
    }
}
