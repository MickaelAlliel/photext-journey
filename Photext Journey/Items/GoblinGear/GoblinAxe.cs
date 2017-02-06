using Photext_Journey.Templates; 
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics; 
using Microsoft.Xna.Framework.Content; 

namespace Photext_Journey.Items
{
    class GoblinAxe : Item
    {
        public GoblinAxe(ContentManager Content)
        {
            base.Health = 310;
            base.Mana = 0;

            base.Strength = 54;
            base.SpellPower = 0;
            base.Defense = 30;

            base.Gold = 1630;

            base.Type = "Weapon";
            base.ID = "Double Axe of the Goblin";
            base.Texture = Content.Load<Texture2D>("Items/GoblinGear/goblin_weapon");
        }

    }

}

