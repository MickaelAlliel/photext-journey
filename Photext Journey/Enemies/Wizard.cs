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
    class Wizard : Entity
    {
        public Wizard(ContentManager Content)
        {
            base.CurrentHealth = 377;
            base.MaxHealth = 377;
            base.CurrentMana = 587;
            base.MaxMana = 587;


            base.AttackDamage = 27;
            base.Strength = 13;
            base.SpellPower = 40;
            base.Defense = 11;

            base.Experience = 44;
            base.Gold = 21;

            base.ID = "Wizard";
            base.Level = 3;

            base.fightTexture = Content.Load<Texture2D>("Charsets/Wizard/wizard");

            base.fightAnim = new Animation(Content.Load<Texture2D>("Charsets/Wizard/wizard_animation"), 1, 2, 50);

            base.fightPos = new Vector2(775, 325);


            base.AIChoice = "";
        }

        public override string AI()
        {
            this.rand = new Random();

            this.AIChoice = "Fireball";

            return base.AI();
        }
    }
}
