using Photext_Journey.Templates; 
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics; 
using Microsoft.Xna.Framework.Content; 

namespace Photext_Journey.Items
{
    class GoblinChest : Item
    {
        public GoblinChest(ContentManager Content)
        {
            base.Health = 186;
            base.Mana = 88;

            base.Strength = 20;
            base.SpellPower = 35;
            base.Defense = 20;

            base.Gold = 800;

            base.Type = "Chest";
            base.ID = "Chestplate of the Goblin";
            base.Texture = Content.Load<Texture2D>("Items/GoblinGear/goblin_chest");
        }

    }

}

