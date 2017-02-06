using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photext_Journey.Templates;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Photext_Journey.Items
{
    class NullItem : Item
    {
        public NullItem(ContentManager Content)
        {
            base.Health = 0;
            base.Mana = 0;

            base.Strength = 0;
            base.SpellPower = 0;
            base.Defense = 0;

            base.Gold = 0;

            base.Type = "";
            base.ID = "";

            base.Texture = Content.Load<Texture2D>("Items/null");
        }
    }
}
