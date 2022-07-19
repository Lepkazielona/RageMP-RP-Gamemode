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

        [RemoteEvent("server::chat::sendMessage")]
        private void ChatSend(Player player, string message)
        {
            Console.WriteLine("Napisano wiadomosc");
            NAPI.Chat.SendChatMessageToAll($"{player.Name} - {message}");
            OnChatMessage(player, message);
        }

        [ServerEvent(Event.ChatMessage)]
        private void OnChatMessage(Player player, String message)
        {
            foreach (Player p in NAPI.Pools.GetAllPlayers())
            {
                p.SendChatMessage("From server");
                NAPI.ClientEvent.TriggerClientEvent(p, "client::chat::onMessage",player.Name, message);
            }
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
