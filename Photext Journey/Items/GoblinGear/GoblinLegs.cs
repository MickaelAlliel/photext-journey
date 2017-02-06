using Photext_Journey.Templates; 
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics; 
using Microsoft.Xna.Framework.Content; 

namespace Photext_Journey.Items
{
    class GoblinLegs : Item
    {
        public GoblinLegs(ContentManager Content)
        {
            base.Health = 160;
            base.Mana = 120;

            base.Strength = 6;
            base.SpellPower = 87;
            base.Defense = 16;

            base.Gold = 725;

            base.Type = "Legs";
            base.ID = "Pants of the Goblin";
            base.Texture = Content.Load<Texture2D>("Items/GoblinGear/goblin_legs");
        }

    }

}

