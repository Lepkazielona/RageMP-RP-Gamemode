using System.Diagnostics.Tracing;
using DB;
using GTANetworkAPI;

namespace RpGamemode.UserSystem
{
    public class AccountSystem : Script
    {
        //[ServerEvent(Event.PlayerConnected)]
        [Command("/login")]
        private void LoginOnJoin(Player p)
        {
            var a = new Interface().searchUserByAuth(p.SocialClubId).Result;
            var b = new Interface().searchUserByAuth(p.SocialClubId).Result;
            if (a != null && b != null)
            {
                p.SendNotification($"Succesfully logged in, on account {a.nickname}");
            }
            else
            {
                p.SendNotification("Nie zalogowano, stworz konto");
            }
        }
    }
}