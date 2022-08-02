using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using RAGE;
using RAGE.Elements;
using RAGE.Ui;

namespace ClientSide.cef
{
    public class CEF : Events.Script
    {
        public static readonly RAGE.Ui.HtmlWindow browser = new RAGE.Ui.HtmlWindow("package://cs_packages/cef/MainGui.html");
        private readonly Player _player = RAGE.Elements.Player.LocalPlayer;
        
        public CEF()
        {
            Events.OnPlayerReady += (() =>
            {
                RAGE.Chat.Activate(false);
                RAGE.Chat.Show(false);
                //browser.Active(true);
                browser.MarkAsChat();
                browser.ExecuteJs("Alpine.store('playerInfo').nickname =' " + _player.Name.ToString() + "'");
            });
        }
    }
}