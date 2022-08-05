using System.Collections.Generic;
using System.Threading.Tasks;
using RAGE;
using RAGE.Ui;

namespace ClientSide.cef
{
    public class ChatClient : Events.Script
    {
        public ChatClient()
        {
            Events.Tick += Tick;
            //Events.Add("client::chat::closeChat", closeChat);
            
            Events.Add("client::chat::sendMessageToServer", sendMessageToServer);
            Events.Add("client::chat::sendMessageToCef", sendMessageToCef);
            Events.Add("client::chat::closeChat", closeChatEvent);
            RAGE.Input.Bind(VirtualKeys.T, false, openChat);
            //RAGE.Input.Bind(192, false, closeChat);
        }
        
        
        private bool _chatOpen = false;
        private int _lastMessageTick = 0;


        private void openChat()
        {
            _chatOpen = true;
            RAGE.Ui.Cursor.Visible = true;
            CEF.browser.ExecuteJs("Alpine.store('chat').openChat()");
        }

        private void closeChat()
        {
            _chatOpen = false;
            RAGE.Ui.Cursor.Visible = false;
            CEF.browser.ExecuteJs("Alpine.store('chat').closeChat()");
        }
        private void closeChatEvent(object[] args)
        {
            closeChat();
        }
        
        private void sendMessageToServer(object[] args)
        {
            RAGE.Events.CallRemote("server::chat::sendChatMessage", args[0]);
        }

        private void sendMessageToCef(object[] args)
        {
            _lastMessageTick = 0;
            CEF.browser.ExecuteJs("Alpine.store('chat').blur = false");
            CEF.browser.ExecuteJs($"Alpine.store('chat').usrMsg('{args[0]}', '{args[1]}')");
        }


        // chat blur
        
        private void Tick(List<Events.TickNametagData> nametags)
        {
            //CEF.browser.ExecuteJs($"Alpine.store('chat').usrMsg('sss','aaa')");
            //RAGE.Game.Pad.DisableControlAction(32, 200, true);
            _lastMessageTick++;
            
            if (_lastMessageTick == 1000)
            {
                CEF.browser.ExecuteJs("Alpine.store('chat').blur = true");
            }

            if (_lastMessageTick == 3000)
            { 
                _lastMessageTick = 1000;
            }
            
            if (_chatOpen)
            {
                _lastMessageTick = 0;
            }
        }
    }
}