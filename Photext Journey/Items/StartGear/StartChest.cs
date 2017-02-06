using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photext_Journey.Templates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Photext_Journey.Items
{
    class StartChest : Item
    {
        public StartChest(ContentManager Content)
        {
            base.Health = 15;
            base.Mana = 2;

            base.Strength = 3;
            base.SpellPower = 1;
            base.Defense = 2;

            base.Gold = 0;

            base.Type = "Chest";
            base.ID = "Start Chestplate";

            base.Texture = Content.Load<Texture2D>("Items/StartGear/start_chest");
        }
    }
}
