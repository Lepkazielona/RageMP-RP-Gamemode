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
        public readonly RAGE.Ui.HtmlWindow browser = new RAGE.Ui.HtmlWindow("package://cs_packages/cef/MainGui.html");
        public Player _player = RAGE.Elements.Player.LocalPlayer;
        public bool chatOpen = false;
        
        public CEF()
        {
            Events.Tick += Tick;
 /*
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
  */
            Events.OnPlayerReady += (() =>
            {
                RAGE.Chat.Show(true);
                //browser.Active(true);
                browser.MarkAsChat();
                browser.ExecuteJs("Alpine.store('playerInfo').nickname =' " + _player.Name.ToString() + "'");
            });
            
 
            Events.Add("client::closeChat", args =>
            {
                RAGE.Ui.Cursor.Visible = false;
                chatOpen = false;
            });
            Events.Add("client::chat::sendMessageToServer", sendMessageToServer);
            Events.Add("client::chat::sendMessageToCef", sendMessageToCef);
            RAGE.Input.Bind(VirtualKeys.Y, false, toggleChat);
        }

        
        
        
        /*
         *
         *  CHAT CHAT CHAT CHAT CHAT CHAT CHAT CHAT CHAT CHAT CHAT CHAT CHAT CHAT CHAT CHAT CHAT CHAT CHAT CHAT 
         * 
         */
        private void toggleChat()
        {
            if (!chatOpen)
            {
                chatOpen = !chatOpen;
                if (chatOpen)
                {
                    browser.ExecuteJs("Alpine.store('chat').blur = false");
                    browser.ExecuteJs("Alpine.store('chat').focusChat()");
                }
                else
                {
                    browser.ExecuteJs("Alpine.store('chat').blur = true");
                }
                RAGE.Ui.Cursor.Visible = chatOpen;
            }
        }
        private void sendMessageToServer(object[] args)
        {
            RAGE.Events.CallRemote("server::chat::sendChatMessage", args[0]);
        }

        private void sendMessageToCef(object[] args)
        {
            browser.ExecuteJs($"Alpine.store('chat').usrMsg('{args[0]}', '{args[1]}')");
        }


        // chat blur
        public void Tick(List<Events.TickNametagData> nametags)
        {
            /*
            lastMessageTick++;
            if (lastMessageTick == 1000)
            {
                browser.ExecuteJs("Alpine.store('chat').blur = true");
            }

            if (chatOpen)
            {
                lastMessageTick = 0;
            }
             */
        }
    }
}