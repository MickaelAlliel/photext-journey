using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Photext_Journey.Templates;
using Photext_Journey.Core;

namespace Photext_Journey.GUI
{
    class InventoryGUI
    {
        private Texture2D backgroundTransparent, backgroundInventory, inventorySlot;
        private Texture2D removeIcon;

        private Rectangle remHead, remChest, remLegs, remFeets, remWeapon;
        private int itemToRem;

        private SpriteFont hudFont, statFont;
        private Color opacity;

        private Rectangle[,] itemSlots;
        private Hero hero;

        private Fight fight;
        private bool isInFight;

        private ContentManager Content;

        public InventoryGUI(Hero hero)
        {
            this.opacity = new Color(255, 255, 255, 180);
            this.hero = hero;

            this.itemSlots = new Rectangle[5,4];

            for (int column = 0; column < this.itemSlots.GetLength(0); column++)
            {
                for (int row = 0; row < this.itemSlots.GetLength(1); row++)
                {
                    this.itemSlots[column, row] = new Rectangle(320 + (column * 57), 220 + (row * 57), 54, 54);
                }
            }

            this.isInFight = false;
        }

        public InventoryGUI(Hero hero, Fight fight)
        {
            this.opacity = new Color(255, 255, 255, 180);
            this.hero = hero;

            this.itemSlots = new Rectangle[5, 4];

            for (int column = 0; column < this.itemSlots.GetLength(0); column++)
            {
                for (int row = 0; row < this.itemSlots.GetLength(1); row++)
                {
                    this.itemSlots[column, row] = new Rectangle(320 + (column * 57), 220 + (row * 57), 54, 54);
                }
            }

            this.fight = fight;
            this.isInFight = true;
        }


        public void LoadContent(ContentManager Content)
        {
            this.Content = Content;

            this.backgroundTransparent = Content.Load<Texture2D>("Backgrounds/pause_background");
            this.backgroundInventory = Content.Load<Texture2D>("Backgrounds/inventory_background");
            this.inventorySlot = Content.Load<Texture2D>("Backgrounds/inventory_slot");

            this.removeIcon = Content.Load<Texture2D>("HUD/remove");
            this.itemToRem = -1;

            this.hudFont = Content.Load<SpriteFont>("Fonts/hudFont");
            this.statFont = Content.Load<SpriteFont>("Fonts/statFont");

            this.remHead = new Rectangle(680, 237, removeIcon.Width, removeIcon.Height);
            this.remChest = new Rectangle(680, 322, removeIcon.Width, removeIcon.Height);
            this.remLegs = new Rectangle(680, 407, removeIcon.Width, removeIcon.Height);
            this.remFeets = new Rectangle(680, 492, removeIcon.Width, removeIcon.Height);
            this.remWeapon = new Rectangle(680, 577, removeIcon.Width, removeIcon.Height);
        }

        public void Update(MouseInput mouseInput, KeyboardInput keyboardInput)
        {
            #region Use Items Slots

            for (int i = 0; i < itemSlots.GetLength(0); i++)
            {
                for (int j = 0; j < itemSlots.GetLength(1); j++)
                {
                    if (itemSlots[i, j].Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y) && mouseInput.IsLeftClicked())
                    {
                        if (isInFight)
                        {
                            if (hero.Inventory[i, j].Type == "Potion")
                            {
                                FightHelper.UseItem(hero, i, j);
                                this.fight.UsedItemPass();
                            }
                        }
                        else
                        {
                            FightHelper.UseItem(hero, i, j);
                        }
                    }
                }
            }

            #endregion

            #region Remove Equipment Button Update

            if (!isInFight)
            {
                if (remHead.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                    if (mouseInput.IsLeftClicked())
                        hero.UnEquip(0);
                    else
                        itemToRem = 0;
                else if (remChest.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                    if (mouseInput.IsLeftClicked())
                        hero.UnEquip(1);
                    else
                        itemToRem = 1;
                else if (remLegs.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                    if (mouseInput.IsLeftClicked())
                        hero.UnEquip(2);
                    else
                        itemToRem = 2;
                else if (remFeets.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                    if (mouseInput.IsLeftClicked())
                        hero.UnEquip(3);
                    else
                        itemToRem = 3;
                else if (remWeapon.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                    if (mouseInput.IsLeftClicked())
                        hero.UnEquip(4);
                    else
                        itemToRem = 4;
                else
                    itemToRem = -1;
            }

            #endregion

            #region Destroy Item

            for (int i = 0; i < itemSlots.GetLength(0); i++)
            {
                for (int j = 0; j < itemSlots.GetLength(1); j++)
                {
                    if (itemSlots[i, j].Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y) && mouseInput.IsRightClicked())
                    {
                        if (!isInFight)
                        {
                            this.hero.Inventory[i, j] = new Items.NullItem(Content);
                        }
                    }
                }
            }

            #endregion

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(backgroundTransparent, new Vector2(0, 0), this.opacity);

            #region Draw Stats and Equipment

            sb.DrawString(hudFont, "Stats:", new Vector2(50, 170), Color.White);

            sb.DrawString(hudFont, "Health: " + hero.CurrentHealth + "/" + hero.MaxHealth, new Vector2(50, 230), Color.White);
            sb.DrawString(hudFont, "Mana: " + hero.CurrentMana + "/" + hero.MaxMana, new Vector2(50, 260), Color.White);

            sb.DrawString(hudFont, "Attack Damage: " + hero.AttackDamage, new Vector2(50, 290), Color.White);
            sb.DrawString(hudFont, "Strength: " + hero.Strength, new Vector2(50, 320), Color.White);
            sb.DrawString(hudFont, "Spell Power: " + hero.SpellPower, new Vector2(50, 350), Color.White);
            sb.DrawString(hudFont, "Defense: " + hero.Defense, new Vector2(50, 380), Color.White);

            //----------------------------------

            sb.DrawString(hudFont, "Equipment:", new Vector2(700, 170), Color.White);

            if (itemToRem == 0)
                sb.Draw(removeIcon, remHead, Color.Red);
            else
                sb.Draw(removeIcon, remHead, Color.White);
            sb.DrawString(hudFont, "Head: " + hero.Equipment[0].ID, new Vector2(700, 230), Color.White);
            sb.DrawString(statFont, "HP: " + hero.Equipment[0].Health + " / Mana: " + hero.Equipment[0].Mana, new Vector2(700, 250), Color.White);
            sb.DrawString(statFont, "Str: " + hero.Equipment[0].Strength, new Vector2(700, 265), Color.White);
            sb.DrawString(statFont, "S.P: " + hero.Equipment[0].SpellPower, new Vector2(700, 280), Color.White);
            sb.DrawString(statFont, "Def: " + hero.Equipment[0].Defense, new Vector2(700, 295), Color.White);

            if (itemToRem == 1)
                sb.Draw(removeIcon, remChest, Color.Red);
            else
                sb.Draw(removeIcon, remChest, Color.White);
            sb.DrawString(hudFont, "Chest: " + hero.Equipment[1].ID, new Vector2(700, 315), Color.White);
            sb.DrawString(statFont, "HP: " + hero.Equipment[1].Health + " / Mana: " + hero.Equipment[1].Mana, new Vector2(700, 335), Color.White);
            sb.DrawString(statFont, "Str: " + hero.Equipment[1].Strength, new Vector2(700, 350), Color.White);
            sb.DrawString(statFont, "S.P: " + hero.Equipment[1].SpellPower, new Vector2(700, 365), Color.White);
            sb.DrawString(statFont, "Def: " + hero.Equipment[1].Defense, new Vector2(700, 380), Color.White);

            if (itemToRem == 2)
                sb.Draw(removeIcon, remLegs, Color.Red);
            else
                sb.Draw(removeIcon, remLegs, Color.White);
            sb.DrawString(hudFont, "Legs: " + hero.Equipment[2].ID, new Vector2(700, 400), Color.White);
            sb.DrawString(statFont, "HP: " + hero.Equipment[2].Health + " / Mana: " + hero.Equipment[2].Mana, new Vector2(700, 420), Color.White);
            sb.DrawString(statFont, "Str: " + hero.Equipment[2].Strength, new Vector2(700, 435), Color.White);
            sb.DrawString(statFont, "S.P: " + hero.Equipment[2].SpellPower, new Vector2(700, 450), Color.White);
            sb.DrawString(statFont, "Def: " + hero.Equipment[2].Defense, new Vector2(700, 465), Color.White);

            if (itemToRem == 3)
                sb.Draw(removeIcon, remFeets, Color.Red);
            else
                sb.Draw(removeIcon, remFeets, Color.White);
            sb.DrawString(hudFont, "Feets: " + hero.Equipment[3].ID, new Vector2(700, 485), Color.White);
            sb.DrawString(statFont, "HP: " + hero.Equipment[3].Health + " / Mana: " + hero.Equipment[3].Mana, new Vector2(700, 505), Color.White);
            sb.DrawString(statFont, "Str: " + hero.Equipment[3].Strength, new Vector2(700, 520), Color.White);
            sb.DrawString(statFont, "S.P: " + hero.Equipment[3].SpellPower, new Vector2(700, 535), Color.White);
            sb.DrawString(statFont, "Def: " + hero.Equipment[3].Defense, new Vector2(700, 550), Color.White);

            if (itemToRem == 4)
                sb.Draw(removeIcon, remWeapon, Color.Red);
            else
                sb.Draw(removeIcon, remWeapon, Color.White);
            sb.DrawString(hudFont, "Weapon: " + hero.Equipment[4].ID, new Vector2(700, 570), Color.White);
            sb.DrawString(statFont, "HP: " + hero.Equipment[4].Health + " / Mana: " + hero.Equipment[4].Mana, new Vector2(700, 590), Color.White);
            sb.DrawString(statFont, "Str: " + hero.Equipment[4].Strength, new Vector2(700, 605), Color.White);
            sb.DrawString(statFont, "S.P: " + hero.Equipment[4].SpellPower, new Vector2(700, 620), Color.White);
            sb.DrawString(statFont, "Def: " + hero.Equipment[4].Defense, new Vector2(700, 635), Color.White);


            #endregion

           sb.DrawString(hudFont, "Level: " + hero.Level.ToString(), new Vector2(320, 145), Color.White);
            if (hero.Level == 50)
                sb.DrawString(hudFont, "Experience: " + hero.Experience.ToString() + " / " + hero.XPTABLE[hero.Level].ToString(), new Vector2(320, 165), Color.White);
            else
                sb.DrawString(hudFont, "Experience: " + hero.Experience.ToString() + " / " + hero.XPTABLE[hero.Level + 1].ToString(), new Vector2(320, 165), Color.White);
           sb.DrawString(hudFont, "Gold: " + hero.Gold.ToString(), new Vector2(320, 185), Color.White);

           for (int column = 0; column < this.itemSlots.GetLength(0); column++) //DRAW INVENTORY SLOTS
           {
               for (int row = 0; row < this.itemSlots.GetLength(1); row++)
               {
                   sb.Draw(inventorySlot, new Vector2(320 + 57 * column, 220 + 57 * row), Color.White);
               }
           }

           for (int column = 0; column < this.itemSlots.GetLength(0); column++) // DRAW ITEMS INTO SLOTS
           {
               for (int row = 0; row < this.itemSlots.GetLength(1); row++)
               {
                   sb.Draw(hero.Inventory[column, row].Texture, itemSlots[column, row], Color.White);
                   
               }
           }

        }
    }
}
