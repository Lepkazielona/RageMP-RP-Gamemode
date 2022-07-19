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
            Events.Add("client::chat::messageSend", (args =>
            {
                RAGE.Chat.Output("From client");
                Events.CallRemote("server::chat::sendMessage", args[0]);
            }));
            Events.Add("client::chat::onMessage", args =>
            {
                browser.ExecuteJs($"Alpine.store('chat').newMessage('{args[0]}', '{args[1]}')");
            });
            Events.Add("client::hideCursor", args =>
            {
                RAGE.Ui.Cursor.Visible = false;
            });
            Events.OnPlayerReady += (() =>
            {
               // RAGE.Chat.Show(false);
                activateBrowser(true);
                browser.MarkAsChat();
                browser.ExecuteJs("Alpine.store('playerInfo').nickname =' " + _player.Name.ToString() + "'");
            });
            

            RAGE.Input.Bind(VirtualKeys.R, false, () =>
            {
                RAGE.Ui.Cursor.Visible = true;
                browser.ExecuteJs("Alpine.store('chat').focusChat()");
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