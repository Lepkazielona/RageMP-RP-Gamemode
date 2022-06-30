using System.Collections.Generic;
using DB;
using GTANetworkAPI;

namespace RpGamemode
{
    public class IDSystem
    {
        public List<string> IDList = new List<string>();

        public void InitializeID(Player player)
        {
            for (int i = 0; i < IDList.Count; i++)
            {
                if (IDList[i] == null)
                {
                    IDList[i] = player.Name;
                }
            } 
        }
        public Player getPlayerFromID(int id)
        {
            return NAPI.Player.GetPlayerFromName(IDList[id]);
        }
        public int getIDFromPlayer(Player player)
        {
            return IDList.IndexOf(player.Name);
        }
    }
}