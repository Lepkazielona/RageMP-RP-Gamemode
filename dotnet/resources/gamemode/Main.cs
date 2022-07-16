using System;
using System.IO;
using System.Threading.Tasks;
using GTANetworkAPI;

using Microsoft.EntityFrameworkCore;
using DB;
using Object = GTANetworkAPI.Object;

namespace RpGamemode
{
    public class Main : Script
    {
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

        [RemoteEvent("Server_Chat_Send_Message")]
        private void ChatSend(Player player, string message)
        {
            NAPI.Chat.SendChatMessageToAll("asdasadsd");
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
