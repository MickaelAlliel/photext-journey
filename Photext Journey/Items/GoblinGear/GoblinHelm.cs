using Photext_Journey.Templates; 
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics; 
using Microsoft.Xna.Framework.Content; 

namespace Photext_Journey.Items
{
    class GoblinHelm : Item
    {
        public GoblinHelm(ContentManager Content)
        {
            base.Health = 114;
            base.Mana = 62;

            base.Strength = 18;
            base.SpellPower = 14;
            base.Defense = 11;

            base.Gold = 550;

            base.Type = "Head";
            base.ID = "Helm of the Goblin";
            base.Texture = Content.Load<Texture2D>("Items/GoblinGear/goblin_head");
        }

    }

}

