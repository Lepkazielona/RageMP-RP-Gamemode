using System.Collections.Generic;
using RAGE;
using RAGE.Elements;
using RAGE.Ui;

namespace ClientSide.uitl
{
    public class Fly : Events.Script
    {
        private bool isFly = false;
        private double speed = 0.5;
        private Player _player = RAGE.Elements.Player.LocalPlayer;
        
        public Fly()
        {
            Events.Tick += render;
            RAGE.Events.Add("toggle_fly", args =>
            {
                isFly = !isFly;
                _player.FreezePosition(isFly);
            });
        }
        
        private void render(List<Events.TickNametagData> TickNametags)
        {
            if (isFly)
            {
                if (RAGE.Input.IsDown(VirtualKeys.LeftShift))
                {
                    speed = 2;
                } 
                else if (RAGE.Input.IsDown(VirtualKeys.LeftControl))
                {
                    speed = 0.2;
                }
                else speed = 0.5;

                if (RAGE.Input.IsDown(VirtualKeys.W))
                {
                    _player.SetCoordsNoOffset(_player.Position.X, _player.Position.Y + (float) speed, _player.Position.Z, true,true,true);
                }
                if (RAGE.Input.IsDown(VirtualKeys.S))
                {
                    _player.SetCoordsNoOffset(_player.Position.X, _player.Position.Y - (float) speed, _player.Position.Z, true,true,true);
                }
                if (RAGE.Input.IsDown(VirtualKeys.A))
                {
                    _player.SetCoordsNoOffset(_player.Position.X - (float) speed, _player.Position.Y, _player.Position.Z, true,true,true);
                }
                if (RAGE.Input.IsDown(VirtualKeys.D))
                {
                    _player.SetCoordsNoOffset(_player.Position.X + (float) speed, _player.Position.Y, _player.Position.Z, true,true,true);
                }
                if (RAGE.Input.IsDown(VirtualKeys.E))
                {
                    _player.SetCoordsNoOffset(_player.Position.X, _player.Position.Y, _player.Position.Z + (float) speed, true,true,true);
                }
                if (RAGE.Input.IsDown(VirtualKeys.Q))
                {
                    _player.SetCoordsNoOffset(_player.Position.X, _player.Position.Y, _player.Position.Z - (float) speed, true,true,true);
                }
            }    
        }
    }
}