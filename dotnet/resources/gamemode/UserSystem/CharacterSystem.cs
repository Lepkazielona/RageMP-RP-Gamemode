using GTANetworkAPI;
using DB;

namespace RpGamemode.UserSystem
{
    public class CharacterSystem : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        public void onPlayerConnect(Player p)
        {
            p.SendNotification("Wpisz komende '/postac' by wybrać swoją postać, wpisz /postac list by zobaczyć posiadane postacie");
        }

        [Command("postac")]
        public void cmdPostac(Player player, string arg1, string arg2)
        {
            if (arg1 == "list")
            {
                var characters  = new Interface().searchCharacter(ownerId: 1).Result;
                foreach (var p in characters)
                {
                    player.SendChatMessage(p.name);
                }
            }
            else if (arg1 == "select")
            {
                
                var characters  = new Interface().searchCharacter(ownerId: 1).Result;
            }
        }
    }
}