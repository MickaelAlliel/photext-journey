using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photext_Journey.Templates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Photext_Journey.Items
{
    class BothPotion : Item
    {
        public BothPotion(ContentManager Content)
        {
            base.Health = 150;
            base.Mana = 100;

            base.Strength = 0;
            base.SpellPower = 0;
            base.Defense = 0;

            base.Gold = 46;

            base.Type = "Potion";
            base.ID = "Potion of Both";

            base.Texture = Content.Load<Texture2D>("Items/Potions/both_potion");
        }
    }
}
