using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photext_Journey.Templates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Photext_Journey.Items
{
    class HealthPotion : Item
    {
        public HealthPotion(ContentManager Content)
        {
            base.Health = 120;
            base.Mana = 0;

            base.Strength = 0;
            base.SpellPower = 0;
            base.Defense = 0;

            base.Gold = 29;

            base.Type = "Potion";
            base.ID = "Health Potion";

            base.Texture = Content.Load<Texture2D>("Items/Potions/health_potion");
        }
    }
}
