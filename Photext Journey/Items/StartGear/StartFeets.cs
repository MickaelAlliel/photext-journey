using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photext_Journey.Templates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Photext_Journey.Items
{
    class StartFeets : Item
    {
        public StartFeets(ContentManager Content)
        {
            base.Health = 7;
            base.Mana = 3;

            base.Strength = 2;
            base.SpellPower = 4;
            base.Defense = 1;

            base.Gold = 0;

            base.Type = "Feets";
            base.ID = "Start Boots";

            base.Texture = Content.Load<Texture2D>("Items/StartGear/start_feets");
        }
    }
}
