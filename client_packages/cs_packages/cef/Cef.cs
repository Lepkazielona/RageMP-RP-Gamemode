using System;
using System.Collections.Generic;
using RAGE;
using RAGE.Elements;
using RAGE.Ui;

namespace ClientSide.cef
{
    public class CEF : Events.Script
    {
        private ulong lastMessageTick = 0;
        private bool chatOpen = false;
        public readonly RAGE.Ui.HtmlWindow browser = new RAGE.Ui.HtmlWindow("package://cs_packages/cef/MainGui.html");
        public Player _player = RAGE.Elements.Player.LocalPlayer;
        public CEF()
        {
            Events.Tick += Tick;

            Events.Add("client::chat::messageSend", (args   =>
            {
                string msg = args[0].ToString();
                if (msg.StartsWith('/'))
                {
                    
                }
                RAGE.Chat.Output("From client");
                Events.CallRemote("server::chat::sendMessage", args[0]);
            }));
            Events.Add("client::closeChat", args =>
            {
                chatOpen = false;
            });
            Events.Add("client::chat::onMessage", args =>
            {
                browser.ExecuteJs("Alpine.store('chat').blur = false");
                browser.ExecuteJs($"Alpine.store('chat').newMessage('{args[0]}', '{args[1]}')");
            });
            Events.Add("client::hideCursor", args =>
            {
                RAGE.Ui.Cursor.Visible = false;
            });
            Events.OnPlayerReady += (() =>
            {
                RAGE.Chat.Show(false);
                activateBrowser(true);
                chatOpen = true;
                browser.MarkAsChat();
                browser.ExecuteJs("Alpine.store('playerInfo').nickname =' " + _player.Name.ToString() + "'");
            });
            

            RAGE.Input.Bind(VirtualKeys.T, false, () =>
            {
                RAGE.Ui.Cursor.Visible = true;
                browser.ExecuteJs("Alpine.store('chat').blur = false");
                browser.ExecuteJs("Alpine.store('chat').focusChat()");
            });
            RAGE.Input.Bind(VirtualKeys.Escape, false, () =>
            {
               
                browser.ExecuteJs("Alpine.store('chat').focusChat()");
            });
            RAGE.Input.Bind(VirtualKeys.F5, false, () =>
            {
                browser.Reload(false);
            });
        }
        
        public void Tick(List<Events.TickNametagData> nametags)
        {
            lastMessageTick++;
            if (lastMessageTick == 1000)
            {
                browser.ExecuteJs("Alpine.store('chat').blur = true");
            }

            if (chatOpen)
            {
                lastMessageTick = 0;
            }
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