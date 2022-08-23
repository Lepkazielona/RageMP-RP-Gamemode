using System;
using GTANetworkAPI;
using DB;

namespace RpGamemode.UserSystem
{
    public class CharacterSystem : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        public void onPlayerConnect(Player p)
        {
            //Parse DB json and apply clothes and body
            
        }

        [Command("postac")]
        public void cmdPostac(Player p)
        {
            int pId = p.GetSharedData<int>("AccId");
            var a = new Interface().searchCharacterByOwner(pId).Result;
            RPApi.Chat.sendMsg(p,$"Postacie dla konta o id: {pId}");
            
            
            foreach (var b in a)
            {
                RPApi.Chat.sendMsg(p, $"[ID:{b.ID}] {b.name} {b.surname}");
            }
        }
    }
}