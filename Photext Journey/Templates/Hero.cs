using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Photext_Journey.Core;
using Photext_Journey.Items;
using System.Windows.Forms;

namespace Photext_Journey.Templates
{
    class Hero : Entity
    {
        private Random random;
        private ContentManager Content;
        private const int hpPerLvl = 76, manaPerLvl = 47;
        private const int attackDamagePerLvl = 6, strengthPerLvl = 4, spellPowerPerLvl = 12, defensePerLvl = 2;
        private const int maxLvl = 50;
        private int[] xpTable = {-1, 0, 83, 174, 276, 388, 512, 650,
                                    801, 969, 1154, 1358,
                                    1584, 1883, 2107, 2411,
                                2746, 3115, 3523, 3973, 4470,
                                5018, 5624, 6291, 7028, 7842,
                                8740, 9730, 10824, 12031, 13363,
                                14833, 16456, 18247, 20224, 22406,
                                24815, 27473, 30408, 33648, 37224,
                                41171, 45529, 50339, 55649, 61512,
                                67983, 75127, 83014, 91721, 101333}; // FROM: RuneScape XP Table { value -1 = lvl 0, value 0 = lvl 1 , UP TO LVL 50}

        public int[] XPTABLE { get { return xpTable; } }

        public bool[] leveledTable { get; set; }


        public Hero(ContentManager Content)
        {
            this.random = new Random();

            base.CurrentHealth = 423;
            base.MaxHealth = 423;
            base.CurrentMana = 174;
            base.MaxMana = 174;


            base.AttackDamage = 56;
            base.Strength = 44;
            base.SpellPower = 0;
            base.Defense = 24;
            base.Defending = false;

            base.Experience = 0;
            base.Gold = 0;

            base.Equipment = new Item[5];

            for (int i = 0; i < base.Equipment.Length; i++)
                    base.Equipment[i] = new NullItem(Content);

            // 0 = Helm | 1 = Chest | 2 Legs | 3 Feets | 4 Weapon
            this.Equip(new StartHelm(Content));
            this.Equip(new StartChest(Content));
            this.Equip(new StartLegs(Content));
            this.Equip(new StartFeets(Content));
            this.Equip(new StartSword(Content));
            

            base.Inventory = new Item[5,4];

            for (int i = 0; i < base.Inventory.GetLength(0); i++)
                for(int j = 0; j < base.Inventory.GetLength(1); j++)
                    base.Inventory[i,j] = new NullItem(Content);

            base.Inventory[0, 0] = new HealthPotion(Content);
            

            base.ID = "Mike";
            base.isAlive = true;
            base.Level = 1;

            base.texture = Content.Load<Texture2D>("Sprites/Mike/mike");
            base.fightTexture = Content.Load<Texture2D>("Charsets/Mike/mike");

            base.fightPos = new Vector2(30, 240);
            base.pos = new Vector2(130, 608);

            base.fightAnim = new Animation(Content.Load<Texture2D>("Charsets/Mike/mike_animation"), 1, 2, 50);

            base.leftAnim = new Animation(Content.Load<Texture2D>("Sprites/Mike/mike_left"), 1, 3, 100);
            base.rightAnim = new Animation(Content.Load<Texture2D>("Sprites/Mike/mike_right"), 1, 3, 100);
            base.topAnim = new Animation(Content.Load<Texture2D>("Sprites/Mike/mike_top"), 1, 3, 100);
            base.downAnim = new Animation(Content.Load<Texture2D>("Sprites/Mike/mike_down"), 1, 3, 100);

            base.direction = "down";

            base.collisionRect = new Rectangle((int)base.pos.X, (int)base.pos.Y + (base.texture.Height - 32), base.texture.Width, 32);
            base.canMove = true;

            this.Content = Content;

            leveledTable = new bool[51];

            for (int i = 0; i < leveledTable.Length; i++)
            {
                if (i == 0)
                    leveledTable[i] = true;
                else if (i == 1)
                    leveledTable[i] = true;
                else
                    leveledTable[i] = false;
            }
        }

        public void Update(MouseInput mouseInput, KeyboardInput keyboardInput, Level level,SaveLoad saveLoad, GameTime gameTime)
        {
            this.collisionRect.X = (int)this.pos.X;
            this.collisionRect.Y = (int)this.pos.Y + (this.texture.Height - 32);

            #region Update Position -- Keys

                    try
                    {
                        if (canMove)
                        {
                            if (keyboardInput.IsHeld(Microsoft.Xna.Framework.Input.Keys.Right))
                            {
                                this.direction = "right";
                                this.rightAnim.Update(gameTime);
                                this.pos.X += 4;

                                if (level.Collide(this.collisionRect))
                                {
                                    this.canMove = false;
                                    this.pos.X = level.COLLISIONRECTS[(int)this.pos.X / 32, (int)this.pos.Y / 32].X - (texture.Width - 32);
                                }
                            }

                            if (keyboardInput.IsHeld(Microsoft.Xna.Framework.Input.Keys.Left))
                            {
                                this.direction = "left";
                                this.leftAnim.Update(gameTime);
                                this.pos.X -= 4;

                                if (level.Collide(this.collisionRect))
                                {
                                    this.canMove = false;
                                    this.pos.X = level.COLLISIONRECTS[(int)this.pos.X / 32, (int)this.pos.Y / 32].X + 32;
                                }
                            }

                            if (keyboardInput.IsHeld(Microsoft.Xna.Framework.Input.Keys.Up))
                            {
                                this.direction = "top";
                                this.topAnim.Update(gameTime);
                                this.pos.Y -= 4;

                                if (level.Collide(this.collisionRect))
                                {
                                    this.canMove = false;
                                    this.pos.Y = level.COLLISIONRECTS[(int)this.pos.X / 32, (int)this.pos.Y / 32].Y + (texture.Height - 24);
                                }
                            }

                            if (keyboardInput.IsHeld(Microsoft.Xna.Framework.Input.Keys.Down))
                            {
                                this.direction = "down";
                                this.downAnim.Update(gameTime);
                                this.pos.Y += 4;

                                if (level.Collide(this.collisionRect))
                                {
                                    this.canMove = false;
                                    this.pos.Y = level.COLLISIONRECTS[(int)this.pos.X / 32, (int)this.pos.Y / 32].Y - 2;
                                }
                            }
                        }
                    }
                    catch { }

                    if (keyboardInput.Released(Microsoft.Xna.Framework.Input.Keys.Right) && keyboardInput.Released(Microsoft.Xna.Framework.Input.Keys.Left) && keyboardInput.Released(Microsoft.Xna.Framework.Input.Keys.Up) && keyboardInput.Released(Microsoft.Xna.Framework.Input.Keys.Down))
                    {
                        this.canMove = true;
                    }

                #endregion

                    if (level.CollideWith(collisionRect) == "chest")
                    {
                        AddItem(new BothPotion(Content));
                        this.Gold += random.Next(1, 101);
                    }

                    this.LevelUp(saveLoad);
        }

        public void UpdateStats()
        {
            if (this.CurrentHealth < 0)
            {
                this.CurrentHealth = 0;
                this.isAlive = false;
            }
            else if (this.CurrentHealth > this.MaxHealth)
                this.CurrentHealth = this.MaxHealth;

            if (this.CurrentMana < 0)
                this.CurrentMana = 0;
            else if (this.CurrentMana > this.MaxMana)
                this.CurrentMana = this.MaxMana;
        }

        private void LevelUp(SaveLoad saveLoad)
        {
            for (int i = 2; i < xpTable.Length; i++)
            {
                if (leveledTable[i] == false)
                    if (this.Experience >= xpTable[i])
                    {
                        FightHelper.PlayEffect("levelUp");

                        this.MaxHealth += hpPerLvl;
                        this.CurrentHealth = this.MaxHealth;
                        this.MaxMana += manaPerLvl;
                        this.CurrentMana = this.MaxMana;

                        this.AttackDamage += attackDamagePerLvl;
                        this.Strength += strengthPerLvl;
                        this.SpellPower += spellPowerPerLvl;
                        this.Defense += defensePerLvl;

                        this.Level = i;
                        leveledTable[i] = true;

                        saveLoad.SaveGame();
                    }
            }
        }

        public void AddItem(Item item)
        {
            bool added = false;

            try
            {
                for (int i = 0; (i < this.Inventory.GetLength(0) && added == false); i++)
                {
                    for (int j = 0; (j < this.Inventory.GetLength(1) && added == false); j++)
                    {
                        if (Inventory[i, j].ID == "")
                        {
                            Inventory[i, j] = item;
                            added = true;
                        }
                    }
                }
            }
            catch
            {
                
            }
        }

        private bool IsInventoryFull()
        {
            try
            {
                for (int i = 0; (i < this.Inventory.GetLength(0)); i++)
                {
                    for (int j = 0; (j < this.Inventory.GetLength(1)); j++)
                    {
                        if (Inventory[i, j].ID == "")
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            catch { return false;  }
        }

        public void BuyItem(Item item)
        {
            if (item.Gold > this.Gold)
                MessageBox.Show("Not enough gold!", "!!!!!");
            else if (IsInventoryFull())
                MessageBox.Show("Not enough space!", "!!!!!");
            else
            {
                if (item.ID != "")
                {
                    FightHelper.PlayEffect("shopBuy");

                    this.Gold -= item.Gold;
                    AddItem(item);
                }
            }
        }

        public void Equip(Item item)
        {// 0 = Helm | 1 = Chest | 2 Legs | 3 Feets | 4 Weapon

            try
            {
                if (item.Type == "Head" || item.Type == "Chest" || item.Type == "Legs" || item.Type == "Feets" || item.Type == "Weapon")
                {
                    if (item.Type == "Head")
                    {
                        if (!IsInventoryFull())
                        {
                            //this.UnEquip(0);
                            this.Equipment[0] = item;
                        }
                        else
                            MessageBox.Show("Inventory Full!", "!!!!!");
                    }
                    else if (item.Type == "Chest")
                    {
                        if (!IsInventoryFull())
                        {
                            //this.UnEquip(1);
                            this.Equipment[1] = item;
                        }
                        else
                            MessageBox.Show("Inventory Full!", "!!!!!");
                    }
                    else if (item.Type == "Legs")
                    {
                        if (!IsInventoryFull())
                        {
                            //this.UnEquip(2);
                            this.Equipment[2] = item;
                        }
                        else
                            MessageBox.Show("Inventory Full!", "!!!!!");
                    }
                    else if (item.Type == "Feets")
                    {
                        if (!IsInventoryFull())
                        {
                            //this.UnEquip(3);
                            this.Equipment[3] = item;
                        }
                        else
                            MessageBox.Show("Inventory Full!", "!!!!!");
                    }
                    else if (item.Type == "Weapon")
                    {
                        if (!IsInventoryFull())
                        {
                            //this.UnEquip(4);
                            this.Equipment[4] = item;
                        }
                        else
                            MessageBox.Show("Inventory Full!", "!!!!!");
                    }

                    // APPLY STATS

                    this.Strength += item.Strength;
                    this.SpellPower += item.SpellPower;
                    this.Defense += item.Defense;

                    this.MaxHealth += item.Health;
                    this.CurrentHealth += item.Health;

                    this.MaxMana += item.Mana;
                    this.CurrentMana += item.Mana;
                }
            }

            catch { }

            }

        public void UnEquip(int slot)
        {// 0 = Helm | 1 = Chest | 2 Legs | 3 Feets | 4 Weapon

            // UNAPPLY STATS

            if (!IsInventoryFull())
            {
                this.Strength -= this.Equipment[slot].Strength;
                this.SpellPower -= this.Equipment[slot].SpellPower;
                this.Defense -= this.Equipment[slot].Defense;

                this.MaxHealth -= this.Equipment[slot].Health;
                this.CurrentHealth -= this.Equipment[slot].Health;

                this.MaxMana -= this.Equipment[slot].Mana;
                this.CurrentMana -= this.Equipment[slot].Mana;


                this.AddItem(this.Equipment[slot]);
                this.Equipment[slot] = new NullItem(Content);
            }
            else
            {
                MessageBox.Show("Inventory Full!", "!!!!!");
            }

        }

        public string Warping()
        {
            if (this.pos.X < -5)
                return "left";

            if (this.pos.X > 1024 - this.texture.Width + 5)
                return "right";

            if (this.pos.Y < -5)
                return "up";

            if (this.pos.Y > 704 - this.texture.Height + 5)
                return "down";

            return "";
        }

    }
}