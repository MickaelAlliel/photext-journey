using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photext_Journey.Templates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Photext_Journey.Core;

namespace Photext_Journey.Enemies
{
    class Necromancer : Entity
    {
        public Necromancer(ContentManager Content)
        {
            base.CurrentHealth = 612;
            base.MaxHealth = 612;
            base.CurrentMana = 0;
            base.MaxMana = 0;


            base.AttackDamage = 33;
            base.Strength = 17;
            base.SpellPower = 76;
            base.Defense = 18;

            base.Experience = 56;
            base.Gold = 45;

            base.ID = "Necromancer";
            base.Level = 5;

            base.fightTexture = Content.Load<Texture2D>("Charsets/Necromancer/necromancer");

            base.fightAnim = new Animation(Content.Load<Texture2D>("Charsets/Necromancer/necromancer_animation"), 1, 2, 50);

            base.fightPos = new Vector2(775, 325);

            base.AIChoice = "";
        }

        public override string AI()
        {
            this.rand = new Random();

            this.AIChoice = "Vampiric Bite";

            return base.AI();
        }
    }
}
