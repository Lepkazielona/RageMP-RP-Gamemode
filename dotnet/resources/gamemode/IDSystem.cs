using System.Collections.Generic;
using DB;
using GTANetworkAPI;

namespace RpGamemode
{
    public class IDSystem
    {
        public List<Player> IDList = new List<Player>();

        public void initializeID(Player player)
        {
            foreach (var p in IDList)
            {
                if (p == null)
                {
                    IDList.Insert(IDList.IndexOf(p), player);
                    player.SetSharedData("ID", IDList.IndexOf(player));
                }
            }
        }

        public int getID(Player player)
        {
            return player.GetSharedData<int>("ID");
        }
    }
}