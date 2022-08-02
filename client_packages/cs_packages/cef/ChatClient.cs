﻿using System.Collections.Generic;
using RAGE;
using RAGE.Ui;

namespace ClientSide.cef
{
    public class ChatClient : Events.Script
    {
        public ChatClient()
        {
            Events.Tick += Tick;
            Events.Add("client::closeChat", args =>
            {
                RAGE.Ui.Cursor.Visible = false;
                _chatOpen = false;
            });
            Events.Add("client::chat::sendMessageToServer", sendMessageToServer);
            Events.Add("client::chat::sendMessageToCef", sendMessageToCef);
            RAGE.Input.Bind(VirtualKeys.Y, false, toggleChat);
        }
        
        
        private bool _chatOpen = false;
        private int _lastMessageTick = 0;
        
        private void toggleChat()
        {
            _chatOpen = !_chatOpen;
            if (_chatOpen)
            {
                CEF.browser.ExecuteJs("Alpine.store('chat').blur = false");
                CEF.browser.ExecuteJs("Alpine.store('chat').focusChat()");
            }
            
            RAGE.Ui.Cursor.Visible = _chatOpen;
        }
        private void sendMessageToServer(object[] args)
        {
            RAGE.Events.CallRemote("server::chat::sendChatMessage", args[0]);
        }

        private void sendMessageToCef(object[] args)
        {
            CEF.browser.ExecuteJs($"Alpine.store('chat').usrMsg('{args[0]}', '{args[1]}')");
        }


        // chat blur
        private void Tick(List<Events.TickNametagData> nametags)
        {
            
            _lastMessageTick++;
            if (_lastMessageTick == 1000)
            {
                CEF.browser.ExecuteJs("Alpine.store('chat').blur = true");
            }

            if (_chatOpen)
            {
                _lastMessageTick = 0;
            }
             
        }
    }
}