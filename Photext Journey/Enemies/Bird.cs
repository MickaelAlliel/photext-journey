using System; 
using Photext_Journey.Core; 
using Photext_Journey.Templates; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics; 
using Microsoft.Xna.Framework.Content; 

namespace Photext_Journey.Enemies
{
    class Bird : Entity
    {
        public Bird(ContentManager Content)
        {
            base.CurrentHealth = 933;
            base.MaxHealth = 933;
            base.CurrentMana = 0;
            base.MaxMana = 0;

            base.AttackDamage = 70;
            base.Strength = 44;
            base.SpellPower = 0;
            base.Defense = 38;

            base.Gold = 60;
            base.Experience = 74;

            base.ID = "Bird";
            base.Level = 8;

            base.fightTexture = Content.Load<Texture2D>("Charsets/Bird/bird");
            base.fightAnim = new Animation(Content.Load<Texture2D>("Charsets/Bird/bird_animation"), 1, 2, 50);

            base.fightPos = new Vector2(800, 300);

            base.AIChoice = "";
        }



         public override string AI()
         {
             this.rand = new Random();
             this.AIChoice = "Attack";
             return this.AIChoice;
         }
     }

}

