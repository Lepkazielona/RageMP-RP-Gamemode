using System.Collections.Generic;
using DB;
using GTANetworkAPI;

namespace RpGamemode
{
    public class IDSystem
    {
        public static List<Player> IDList = new List<Player>();

        public static void initializeID(Player player)
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

        public static int getID(Player player)
        {
            return player.GetSharedData<int>("ID");
        }
    }
}