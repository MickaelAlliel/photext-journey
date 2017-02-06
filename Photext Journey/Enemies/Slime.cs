using Photext_Journey.Templates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Photext_Journey.Core;
using System;

namespace Photext_Journey.Enemies
{
    class Slime : Entity
    {
        public Slime(ContentManager Content)
        {
            base.CurrentHealth = 177;
            base.MaxHealth = 177;
            base.CurrentMana = 0;
            base.MaxMana = 0;


            base.AttackDamage = 41;
            base.Strength = 19;
            base.SpellPower = 0;
            base.Defense = 13;

            base.Experience = 24;
            base.Gold = 11;

            base.ID = "Slime";
            base.Level = 1;

            base.fightTexture = Content.Load<Texture2D>("Charsets/Slime/slime");
            base.fightAnim = new Animation(Content.Load<Texture2D>("Charsets/Slime/slime_animation"), 1, 2, 50);

            base.fightPos = new Vector2(800, 400);


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
