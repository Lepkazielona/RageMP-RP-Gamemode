using GTANetworkAPI;

namespace RpGamemode.UserSystem
{
    public class CharacterCreator
    {
        [Command("cr")]
        public void cmdCharacterCreatorDebug(Player p)
        {
            NAPI.ClientEvent.TriggerClientEvent(p, "");
        }
    }
}