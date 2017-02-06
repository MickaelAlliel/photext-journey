using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photext_Journey.Templates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Photext_Journey.Items
{
    class ManaPotion : Item
    {
        public ManaPotion(ContentManager Content)
        {
            base.Health = 0;
            base.Mana = 80;

            base.Strength = 0;
            base.SpellPower = 0;
            base.Defense = 0;

            base.Gold = 25;

            base.Type = "Potion";
            base.ID = "Mana Potion";

            base.Texture = Content.Load<Texture2D>("Items/Potions/mana_potion");
        }
    }
}
