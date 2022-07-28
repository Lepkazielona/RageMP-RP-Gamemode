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
        private IDSystem _idSystem = new IDSystem();
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

        [RemoteEvent("server::chat::sendMessage")]
        private void ChatSend(Player player, string message)
        {
            Console.WriteLine($"[{_idSystem.getID(player)}]{player.Name} - {message}");
            NAPI.Chat.SendChatMessageToAll($"{player.Name} - {message}");
            //OnChatMessage(player, message);
        }

        [ServerEvent(Event.ChatMessage)]
        private void OnChatMessage(Player player, String message)
        {
            foreach (Player p in NAPI.Pools.GetAllPlayers())
            {
                if (p.Position.DistanceTo(player.Position) > 15)
                {
                    p.SendChatMessage(player.Name, message);
                    NAPI.ClientEvent.TriggerClientEvent(p, "client::chat::onMessage",player.Name, message);
                }
            }
        }
        
        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Player player)
        {
            _idSystem.initializeID(player);
            //new IDSystem().InitializeID(player);
            
        }
        
        [Command("myid", "/myid")]
        public void CMD_MyID(Player player)
        { 
            player.SendNotification("Twoje ID: " + player.GetSharedData<int>("ID"));
            //player.SendNotification("twoje id   " + new IDSystem().getIDFromPlayer(player));
        }
        
    }
}
