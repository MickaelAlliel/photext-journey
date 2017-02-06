using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Photext_Journey.Templates
{
    class Item
    {
        public int Health, Mana;
        public int Strength, SpellPower, Defense;
        public int Gold;

        public string Type;
        public string ID;

        public Texture2D Texture;

        public Item()
        {

        }
    }
}
