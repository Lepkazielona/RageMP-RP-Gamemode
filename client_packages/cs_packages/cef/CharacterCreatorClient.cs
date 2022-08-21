using System.IO.Pipes;
using RAGE;
using RAGE.Elements;
using RAGE.Game;
using Player = RAGE.Elements.Player;

namespace ClientSide.cef
{
    public class CharacterCreator : Events.Script
    {
        public Player _player = Player.LocalPlayer;

        public CharacterCreator()
        {
            Events.Add("client::startCharacterCreator", startCharacterCreator); 
            Events.Add("client::stopCharacterCreator", stopCharacterCreator);
        }
        
        public void startCharacterCreator(object[] args)
        {
            //var cam = RAGE.Game.Cam.CreateCameraWithParams(RAGE.Game.Misc.GetHashKey("DEFAULT_SCRIPTED_CAMERA"), 9f, 526f, 170f);

        }

        public void stopCharacterCreator(object[] args)
        {
            
        }
    }
}