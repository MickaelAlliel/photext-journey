using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Photext_Journey.Core;

namespace Photext_Journey.Templates
{
    class Entity
    {
        public string AIChoice;
        public Random rand;

        public int CurrentHealth, MaxHealth;
        public int CurrentMana, MaxMana;
        public int Strength, SpellPower;
        public int Defense, AttackDamage;
        public bool Defending;
        public int Experience, Gold;
        public int Level;

        public Item[,] Inventory;
        public Item[] Equipment;

        public string ID;
        public bool isAlive;

        public Texture2D texture;
        public Texture2D fightTexture;

        public Animation fightAnim;
        public Animation leftAnim, rightAnim, topAnim, downAnim;
        public string direction;

        public Vector2 pos;
        public Vector2 fightPos;

        public Rectangle collisionRect;
        public bool canMove;

        public Entity()
        {
            
        }

        public virtual string AI()
        {
            return AIChoice;
        }
    }
}
