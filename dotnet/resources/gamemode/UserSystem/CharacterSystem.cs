using GTANetworkAPI;
using DB;

namespace RpGamemode.UserSystem
{
    public class CharacterSystem : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        public void onPlayerConnect(Player p)
        {
            
        }

        [Command("postac")]
        public void cmdPostac(Player p)
        {
            int pId = p.GetSharedData<int>("AccId");
            var a = new Interface().searchCharacterByOwner(pId).Result;
            RPApi.Chat.sendMsg(p,$"Postacie dla konta o id: {pId}");
            foreach (var b in a)
            {
                RPApi.Chat.sendMsg(p, b.name);
            }
        }
    }
}