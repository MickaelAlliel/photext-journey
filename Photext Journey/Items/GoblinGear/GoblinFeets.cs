using Photext_Journey.Templates; 
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics; 
using Microsoft.Xna.Framework.Content; 

namespace Photext_Journey.Items
{
    class GoblinFeets : Item
    {
        public GoblinFeets(ContentManager Content)
        {
            base.Health = 67;
            base.Mana = 54;

            base.Strength = 13;
            base.SpellPower = 22;
            base.Defense = 10;

            base.Gold = 550;

            base.Type = "Feets";
            base.ID = "Boots of the Goblin";
            base.Texture = Content.Load<Texture2D>("Items/GoblinGear/goblin_feets");
        }

    }

}

