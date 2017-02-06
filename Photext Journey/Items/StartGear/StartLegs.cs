using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photext_Journey.Templates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Photext_Journey.Items
{
    class StartLegs : Item
    {
        public StartLegs(ContentManager Content)
        {
            base.Health = 6;
            base.Mana = 4;

            base.Strength = 0;
            base.SpellPower = 5;
            base.Defense = 1;

            base.Gold = 0;

            base.Type = "Legs";
            base.ID = "Start Shorts";

            base.Texture = Content.Load<Texture2D>("Items/StartGear/start_legs");
        }
    }
}
