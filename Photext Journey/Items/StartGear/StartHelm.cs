using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photext_Journey.Templates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Photext_Journey.Items
{
    class StartHelm : Item
    {
        public StartHelm(ContentManager Content)
        {
            base.Health = 10;
            base.Mana = 3;

            base.Strength = 1;
            base.SpellPower = 1;
            base.Defense = 3;

            base.Gold = 0;

            base.Type = "Head";
            base.ID = "Start Helm";

            base.Texture = Content.Load<Texture2D>("Items/StartGear/start_head");
        }
    }
}
