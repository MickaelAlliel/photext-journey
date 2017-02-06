using System; 
using Photext_Journey.Core; 
using Photext_Journey.Templates; 
using Microsoft.Xna.Framework.Graphics; 
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework; 

namespace Photext_Journey.Enemies
{
    class Goblin : Entity
    {
        public Goblin(ContentManager Content)
        {
            base.CurrentHealth = 1125;
            base.MaxHealth = 1125;
            base.CurrentMana = 484;
            base.MaxMana = 484;

            base.AttackDamage = 101;
            base.Strength = 68;
            base.SpellPower = 80;
            base.Defense = 37;

            base.Gold = 97;
            base.Experience = 102;

            base.ID = "Goblin";
            base.Level = 10;

            base.fightTexture = Content.Load<Texture2D>("Charsets/Goblin/goblin");
            base.fightAnim = new Animation(Content.Load<Texture2D>("Charsets/Goblin/goblin_animation"), 1, 2, 50);

            base.fightPos = new Vector2(800, 400);

            base.AIChoice = "";
        }



         public override string AI()
         {
             this.rand = new Random();

             if (this.CurrentMana >= 75)
                 this.AIChoice = "Dagger Throw";
             else
                this.AIChoice = "Attack";

             return this.AIChoice;
         }
     }

}

