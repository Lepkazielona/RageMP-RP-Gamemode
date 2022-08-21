using System;
using System.Collections.Generic;
using System.Drawing;
using RAGE;
using RAGE.Game;
using RAGE.Ui;
using Player = RAGE.Elements.Player;

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
            Events.Tick += OnTick;
        }

        private void OnTick(List<Events.TickNametagData> a)
        {
            //RAGE.Game.UIText.Draw(, 0.5f, 0.005f, 0, 255,255,255,255);
            RAGE.Game.UIText.Draw($"X: {_player.Position.X} Y: {_player.Position.Y} Z: {_player.Position.Z}",new Point(700, 100), 0.5f, Color.Black, RAGE.Game.Font.ChaletLondon, true);
            //RAGE.Game.Graphics.DrawDebugText($" X: {_player.Position.X} Z: {_player.Position.X} Y: {_player.Position.X}", 0.5f, 0.005f, 0, 255,255,255,255);
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