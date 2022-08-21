using System.Diagnostics.Tracing;
using DB;
using GTANetworkAPI;

namespace RpGamemode.UserSystem
{
    public class AccountSystem : Script
    {
        //[Command("login")]
        [ServerEvent(Event.PlayerConnected)]
        private void LoginOnJoin(Player p)
        {
            var a = new Interface().searchUserByRiD(p.SocialClubId.ToString()).Result;
            var b = new Interface().searchUserBySerial(p.Serial).Result;
            p.SendNotification($"R{a.Count} S{b.Count}");
            p.SendNotification( p.SocialClubId.ToString());
            p.SendNotification($"{b[0].nickname}");

            
            if (a.Count == 0 || b.Count == 0)
            { 
                p.SendNotification("Nie znaleziono kont z przypisanym twoim danymi");
            }
            else
            {
                if (a.Count > 1)
                {
                    p.SendNotification("Dwa konta przypisane do tego urządzenia, wybierz jedno");
                }
                p.SetSharedData("AccId", a[0].ID);
                p.SendNotification("Zalogowano");
            }
        }
    }
}