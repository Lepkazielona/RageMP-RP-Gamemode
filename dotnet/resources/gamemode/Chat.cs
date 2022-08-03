using GTANetworkAPI;
using System;

namespace RpGamemode
{
    public class Chat : Script
    {
    /*
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

    */
        [RemoteEvent("server::chat::sendChatMessage")]
        private void sendChatMessage(Player player, object[] args)
        {
            Console.WriteLine($"{player.Name}: {args[0]}");
            if (!args[0].ToString().StartsWith("/"))
            {
                NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 5, "client::chat::sendMessageToCef", player.Name ,args[0]);
            }
                //NAPI.ClientEvent.TriggerClientEventForAll("client::chat::sendMessageToCef", player.Name ,args[0]);
        }
    }
}