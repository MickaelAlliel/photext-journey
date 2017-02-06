using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photext_Journey.Templates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Photext_Journey.Items
{
    class StartSword : Item
    {
        public StartSword(ContentManager Content)
        {
            base.Health = 25;
            base.Mana = 15;

            base.Strength = 8;
            base.SpellPower = 0;
            base.Defense = 1;

            base.Gold = 320;

            base.Type = "Weapon";
            base.ID = "Start Sword";

            base.Texture = Content.Load<Texture2D>("Items/StartGear/start_sword");
        }
    }
}
