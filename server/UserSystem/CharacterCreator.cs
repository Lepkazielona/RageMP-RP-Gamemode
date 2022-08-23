using GTANetworkAPI;

namespace RpGamemode.UserSystem
{
    public class CharacterCreator : Script
    {
        [Command("char")]
        public void cmdCharacterCreatorDebug(Player p)
        {
            p.TriggerEvent("client::startCharacterCreator");
            //NAPI.ClientEvent.TriggerClientEvent(p, "client::startCharacterCreator");
        }
    }
}