using System;
using RAGE;
using RAGE.Elements;
using RAGE.Ui;

namespace ClientSide
{
    public class MainClient : Events.Script
    {
        public bool cursor = false;
        public Player _player = RAGE.Elements.Player.LocalPlayer;
        public int tilde = 192;
        
        public MainClient()
        {
            Events.OnPlayerReady += OnPlayerReady;
        }
        
        private void OnPlayerReady()
        {
            /*
             * Key binds
             */
            RAGE.Input.Bind(tilde, true, () =>
            {
                _player.FreezePosition(false);
                cursor = !cursor;
                RAGE.Ui.Cursor.Visible = cursor;
            });
            RAGE.Input.Bind(VirtualKeys.K, true, () =>
            {
                _player.Vehicle.SetEngineOn(!_player.Vehicle.GetIsEngineRunning(), false, false);

            });
            RAGE.Input.Bind(VirtualKeys.N, true, () =>
            {
                _player.Vehicle.SetJetEngineOn(false);
            });

        }
    }
}