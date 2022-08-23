using GTANetworkAPI;

namespace RPApi
{
    public class Chat : Script
    {
        public static void sendMsg(Player player, string message)
        {
            //NAPI.ClientEvent.TriggerClientEventInRange(player.Position, 5, "client::chat::sendMessageToCef", player.Name ,args[0]);
            NAPI.ClientEvent.TriggerClientEvent(player, "client::chat::sendMessageToCef","server", message);
        }

        public static void sendMsgToAll(string message)
        {
            NAPI.ClientEvent.TriggerClientEventForAll("client::chat::sendMessageToCef","server", message);
        }
    }
}