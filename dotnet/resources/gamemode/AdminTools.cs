using GTANetworkAPI;

namespace RpGamemode
{
    public class AdminTools : Script
    {
        [Command("fly", "/fly")]
        public void CMD_fly(Player p)
        {
            NAPI.ClientEvent.TriggerClientEvent(p, "toggle_fly");
        }
    }
}