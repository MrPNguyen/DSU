using System.Numerics;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders.Classes
{
    public class Actor : Entity
    {
        //Tilesheet source for player/Enemy: https://kenney.nl/assets/simple-space
        //Creative Commons CC0
        public float speed;
        protected bool moving;
        public int direction;
        public bool isPlayer;
       
        protected Actor() : base("tileset")
        {
            //TODO: Move everything needed from entity to Actor
        }
    }
}