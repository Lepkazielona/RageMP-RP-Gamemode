using System;
using RAGE;
using RAGE.Elements;
using RAGE.Ui;

namespace ClientSide.cef
{
    public class CEF : Events.Script
    {
        public readonly RAGE.Ui.HtmlWindow browser = new RAGE.Ui.HtmlWindow("package://cs_packages/cef/MainGui.html");
        public Player _player = RAGE.Elements.Player.LocalPlayer;
        public CEF()
        {
            Events.Add("Chat_Send_Message", (args =>
            {
                Events.CallRemote("Server_Chat_Send_Message", args[0]);
            }));
            Events.OnPlayerReady += (() =>
            {
               // RAGE.Chat.Show(false);
                activateBrowser(true);
                browser.MarkAsChat();
                browser.ExecuteJs("Alpine.store('playerInfo').nickname =' " + _player.Name.ToString() + "'");
            });
            
            RAGE.Input.Bind(VirtualKeys.F5, false, () =>
            {
                browser.Reload(false);
            });
        }
        
        
        
        
        
        public void activateBrowser(bool toggle)
        {
            browser.Active = toggle; // Activating of browser
            
        }

        public void urlBrowser(string url)
        {
            browser.Url = url; // Changing url of browser
        }
    }
}