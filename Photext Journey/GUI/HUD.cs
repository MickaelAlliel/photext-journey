using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Photext_Journey.Templates;
using Photext_Journey.Enemies;
using Photext_Journey.GUI;

namespace Photext_Journey.Core
{
    class HUD
    {
        #region Private Variables

        public enum ChoiceHUD
        {
            Attack,
            Defend,
            Spells,
            Inventory,
            Next,
            Previous,
            Blank
        }

        public enum MenuHUD
        {
            Main,
            Spells,
            Spells2,
            Spells3,
            Inventory
        }

        public enum SpellChoice
        {
            ArcaneShock,
            SelfCure,
            Blank
        }

        private Texture2D background;

        private Vector2 topLeftFrame, topRightFrame, bottomLeftFrame, bottomRightFrame;

        private SpriteFont hudFont;

        private List<string> combatLog;
        private Vector2 logPos;

        private Rectangle heroHp, heroMana;
        private int heroHpPercentage, heroManaPercentage;
        private Rectangle enemyHp, enemyMana;
        private int enemyHpPercentage, enemyManaPercentage;
        private Texture2D bar;

        private Hero hero;
        private Entity enemy;

        private bool enemyHit, heroHit;
        private int enemyHitDelay, heroHitDelay;

        private InventoryGUI heroInventory;

        #region Buttons

        private Texture2D button_Attack, button_Defend, button_Spells, button_Inventory;
        private Texture2D button_Highlight_Attack, button_Highlight_Defend, button_Highlight_Spells, button_Highlight_Inventory;

        private Rectangle attackRect, defendRect, spellsRect, inventoryRect;

        private Texture2D button_ArcaneShock, button_SelfCure;
        private Texture2D button_Highlight_ArcaneShock, button_Highlight_SelfCure;

        private Rectangle arcaneShockRect, selfCureRect;

        private Texture2D button_Next, button_Previous;
        private Texture2D button_Highlight_Next, button_Highlight_Previous;

        private Rectangle nextRect, prevRect;

        private Vector2 button1, button2, button3, button4, buttonN, buttonP;

        #endregion

        private ChoiceHUD choiceHUD;
        private MenuHUD menuHUD;
        private SpellChoice spellChoice;

        #endregion

        public HUD(Hero hero, Entity enemy, Fight fight)
        {
            this.topLeftFrame = new Vector2(45, 35);
            this.topRightFrame = new Vector2(445, 35);
            this.bottomLeftFrame = new Vector2(25, 555);
            this.bottomRightFrame = new Vector2(735, 555);

            this.hero = hero;
            this.enemy = enemy;

            this.enemyHit = false;
            this.heroHit = false;

            enemyHitDelay = 0;
            heroHitDelay = 0;

            this.heroInventory = new InventoryGUI(this.hero, fight);

            this.combatLog = new List<string>();
            this.logPos = new Vector2(this.topRightFrame.X + 15, this.topRightFrame.Y + 10);

            #region Initialize HP/Mana Bars

            this.heroHpPercentage = (int)((float)this.hero.CurrentHealth / (float)this.hero.MaxHealth * 100.0);

            this.heroHp.Width = this.heroHpPercentage * 2;
            this.heroHp.Height = 25;
            this.heroHp.X = Convert.ToInt32(bottomLeftFrame.X + 15);
            this.heroHp.Y = Convert.ToInt32(bottomLeftFrame.Y + 55);

            this.heroManaPercentage = (int)((float)this.hero.CurrentMana / (float)this.hero.MaxMana * 100.0);

            this.heroMana.Width = this.heroManaPercentage * 2;
            this.heroMana.Height = 25;
            this.heroMana.X = Convert.ToInt32(bottomLeftFrame.X + 15);
            this.heroMana.Y = Convert.ToInt32(bottomLeftFrame.Y + 85);

            this.enemyHpPercentage = (int)((float)this.enemy.CurrentHealth / (float)this.enemy.MaxHealth * 100.0);

            this.enemyHp.Width = this.enemyHpPercentage * 2;
            this.enemyHp.Height = 25;
            this.enemyHp.X = Convert.ToInt32(bottomRightFrame.X + 15);
            this.enemyHp.Y = Convert.ToInt32(bottomRightFrame.Y + 55);

            this.enemyManaPercentage = (int)((float)this.enemy.CurrentMana / (float)this.enemy.MaxMana * 100.0);

            this.enemyMana.Width = this.enemyManaPercentage * 2;
            this.enemyMana.Height = 25;
            this.enemyMana.X = Convert.ToInt32(bottomRightFrame.X + 15);
            this.enemyMana.Y = Convert.ToInt32(bottomRightFrame.Y + 85);

            #endregion

            choiceHUD = ChoiceHUD.Blank;
            menuHUD = MenuHUD.Main;
            spellChoice = SpellChoice.Blank;

            #region Initialize Button Position

            this.button1 = new Vector2(topLeftFrame.X + 15, topLeftFrame.Y + 80);
            this.button2 = new Vector2(topLeftFrame.X + 210, topLeftFrame.Y + 80);
            this.button3 = new Vector2(topLeftFrame.X + 15, topLeftFrame.Y + 125);
            this.button4 = new Vector2(topLeftFrame.X + 210, topLeftFrame.Y + 125);

            this.buttonN = new Vector2(this.topLeftFrame.X + 190, this.topLeftFrame.Y + 15);
            this.buttonP = new Vector2(this.topLeftFrame.X + 115, this.topLeftFrame.Y + 15);

            #endregion

        }

        public void LoadContent(ContentManager Content)
        {
            this.hudFont = Content.Load<SpriteFont>("Fonts/hudFont");

            this.background = Content.Load<Texture2D>("Backgrounds/fight_background");

            this.bar = Content.Load<Texture2D>("HUD/bar");

            #region Load [ MAIN ] Buttons Textures

            this.button_Attack = Content.Load<Texture2D>("Buttons/Fight/button_Attack");
            this.button_Defend = Content.Load<Texture2D>("Buttons/Fight/button_Defend");
            this.button_Spells = Content.Load<Texture2D>("Buttons/Fight/button_Spells");
            this.button_Inventory = Content.Load<Texture2D>("Buttons/Fight/button_Inventory");

            this.button_Highlight_Attack = Content.Load<Texture2D>("Buttons/Fight/button_Highlight_Attack");
            this.button_Highlight_Defend = Content.Load<Texture2D>("Buttons/Fight/button_Highlight_Defend");
            this.button_Highlight_Spells = Content.Load<Texture2D>("Buttons/Fight/button_Highlight_Spells");
            this.button_Highlight_Inventory = Content.Load<Texture2D>("Buttons/Fight/button_Highlight_Inventory");

            this.button_Next = Content.Load<Texture2D>("Buttons/Fight/button_Next");
            this.button_Previous = Content.Load<Texture2D>("Buttons/Fight/button_Previous");

            this.button_Highlight_Next = Content.Load<Texture2D>("Buttons/Fight/button_Highlight_Next");
            this.button_Highlight_Previous = Content.Load<Texture2D>("Buttons/Fight/button_Highlight_Previous");

            #endregion

            #region Load [ SPELLS ] Buttons Textures

            this.button_ArcaneShock = Content.Load<Texture2D>("Buttons/Fight/Spells/button_ArcaneShock");
            this.button_SelfCure = Content.Load<Texture2D>("Buttons/Fight/Spells/button_SelfCure");

            this.button_Highlight_ArcaneShock = Content.Load<Texture2D>("Buttons/Fight/Spells/button_Highlight_ArcaneShock");
            this.button_Highlight_SelfCure = Content.Load<Texture2D>("Buttons/Fight/Spells/button_Highlight_SelfCure");

            #endregion

            #region Initialize Rectangle's Buttons [ MAIN ]

            this.attackRect = new Rectangle((int)this.button1.X, (int)this.button1.Y, this.button_Attack.Width, this.button_Attack.Height);
            this.defendRect = new Rectangle((int)this.button2.X, (int)this.button2.Y, this.button_Defend.Width, this.button_Defend.Height);
            this.spellsRect = new Rectangle((int)this.button3.X, (int)this.button3.Y, this.button_Spells.Width, this.button_Spells.Height);
            this.inventoryRect = new Rectangle((int)this.button4.X, (int)this.button4.Y, this.button_Inventory.Width, this.button_Inventory.Height);

            this.nextRect = new Rectangle((int)this.buttonN.X, (int)this.buttonN.Y, this.button_Next.Width, this.button_Next.Height);
            this.prevRect = new Rectangle((int)this.buttonP.X, (int)this.buttonP.Y, this.button_Previous.Width, this.button_Previous.Height);

            #endregion

            #region Initialize Rectangle's Buttons [ SPELLS ]

            this.arcaneShockRect = new Rectangle((int)this.button1.X, (int)this.button1.Y, this.button_ArcaneShock.Width, this.button_ArcaneShock.Height);
            this.selfCureRect = new Rectangle((int)this.button2.X, (int)this.button2.Y, this.button_SelfCure.Width, this.button_SelfCure.Height);

            #endregion

            this.heroInventory.LoadContent(Content);
        }

        public void Update(MouseInput mouseInput, KeyboardInput keyboardInput)
        {
            #region Update HP/Mana Bars

            this.heroHpPercentage = (int)((float)this.hero.CurrentHealth / (float)this.hero.MaxHealth * 100.0);
            this.heroManaPercentage = (int)((float)this.hero.CurrentMana / (float)this.hero.MaxMana * 100.0);
            this.enemyHpPercentage = (int)((float)this.enemy.CurrentHealth / (float)this.enemy.MaxHealth * 100.0);
            this.enemyManaPercentage = (int)((float)this.enemy.CurrentMana / (float)this.enemy.MaxMana * 100.0);

            this.heroHp.Width = this.heroHpPercentage * 2;
            this.heroMana.Width = this.heroManaPercentage * 2;
            this.enemyHp.Width = this.enemyHpPercentage * 2;
            this.enemyMana.Width = this.enemyManaPercentage * 2;

            #endregion

            #region Update HUD Choice

            if (menuHUD == MenuHUD.Main)
            {
                if (attackRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                    choiceHUD = ChoiceHUD.Attack;
                else if (defendRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                    choiceHUD = ChoiceHUD.Defend;
                else if (spellsRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                    choiceHUD = ChoiceHUD.Spells;
                else if (inventoryRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                    choiceHUD = ChoiceHUD.Inventory;
                else
                    choiceHUD = ChoiceHUD.Blank;
            }
            else if (menuHUD == MenuHUD.Spells)
            {
                if (nextRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                    choiceHUD = ChoiceHUD.Next;
                else if (prevRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                    choiceHUD = ChoiceHUD.Previous;
                else if (arcaneShockRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                    spellChoice = SpellChoice.ArcaneShock;
                else if (selfCureRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                    spellChoice = SpellChoice.SelfCure;
                else
                {
                    spellChoice = SpellChoice.Blank;
                    choiceHUD = ChoiceHUD.Blank;
                }

                if (mouseInput.IsRightClicked())
                    menuHUD = MenuHUD.Main;
            }

            else if (menuHUD == MenuHUD.Inventory)
            {
                

                if (mouseInput.IsRightClicked())
                    menuHUD = MenuHUD.Main;
            }

            #endregion

            #region Hit Animation Timer

            if (this.enemyHit)
            {
                enemyHitDelay++;

                if (enemyHitDelay > 20)
                {
                    this.enemyHitDelay = 0;
                    this.enemyHit = false;
                }
            }

            if (this.heroHit)
            {
                heroHitDelay++;

                if (heroHitDelay > 20)
                {
                    this.heroHitDelay = 0;
                    this.heroHit = false;
                }
            }

            #endregion

            this.heroInventory.Update(mouseInput, keyboardInput);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(background, new Vector2(0, 0), Color.White); // Draw Background

            #region Draw Top Left Buttons [ MAIN ]

            if (menuHUD == MenuHUD.Main)
            {
                if (choiceHUD == ChoiceHUD.Next)
                    sb.Draw(button_Highlight_Next, buttonN, Color.White);
                else
                    sb.Draw(button_Next, buttonN, Color.White);

                if (choiceHUD == ChoiceHUD.Previous)
                    sb.Draw(button_Highlight_Previous, buttonP, Color.White);
                else
                    sb.Draw(button_Previous, buttonP, Color.White);

                //-----------------------------------------------------------

                if (choiceHUD == ChoiceHUD.Attack)
                    sb.Draw(button_Highlight_Attack, button1, Color.White);
                else
                    sb.Draw(button_Attack, button1, Color.White);

                if (choiceHUD == ChoiceHUD.Defend)
                    sb.Draw(button_Highlight_Defend, button2, Color.White);
                else
                    sb.Draw(button_Defend, button2, Color.White);

                if (choiceHUD == ChoiceHUD.Spells)
                    sb.Draw(button_Highlight_Spells, button3, Color.White);
                else
                    sb.Draw(button_Spells, button3, Color.White);

                if (choiceHUD == ChoiceHUD.Inventory)
                    sb.Draw(button_Highlight_Inventory, button4, Color.White);
                else
                    sb.Draw(button_Inventory, button4, Color.White);
            }

            #endregion

            #region Draw Top Left Buttons [ SPELLS ]

            if (menuHUD == MenuHUD.Spells)
            {
                if (choiceHUD == ChoiceHUD.Next)
                    sb.Draw(button_Highlight_Next, buttonN, Color.White);
                else
                    sb.Draw(button_Next, buttonN, Color.White);

                if (choiceHUD == ChoiceHUD.Previous)
                    sb.Draw(button_Highlight_Previous, buttonP, Color.White);
                else
                    sb.Draw(button_Previous, buttonP, Color.White);

                //-----------------------------------------------------------

                if (spellChoice == SpellChoice.ArcaneShock)
                    sb.Draw(button_Highlight_ArcaneShock, button1, Color.White);
                else
                    sb.Draw(button_ArcaneShock, button1, Color.White);

                if (spellChoice == SpellChoice.SelfCure)
                    sb.Draw(button_Highlight_SelfCure, button2, Color.White);
                else
                    sb.Draw(button_SelfCure, button2, Color.White);
            }

            #endregion

            #region Draw Hero and Enemy Portrait

            if (this.heroHit)
                this.hero.fightAnim.Draw(sb, this.hero.fightPos); // Draw Hero Char Anim
            else
                sb.Draw(this.hero.fightTexture, this.hero.fightPos, Color.White);

            if (this.enemyHit)
                this.enemy.fightAnim.Draw(sb, this.enemy.fightPos); // Draw Enemy Char Anim
            else
                sb.Draw(this.enemy.fightTexture, this.enemy.fightPos, Color.White);
        
            #endregion

            #region Draw Hero and Enemy HP/Mana Bars

            sb.Draw(bar, this.heroHp, Color.Red);
            sb.Draw(bar, this.heroMana, Color.RoyalBlue);

            sb.Draw(bar, this.enemyHp, Color.Red);
            sb.Draw(bar, this.enemyMana, Color.RoyalBlue);

            sb.DrawString(hudFont, this.hero.ID + "    -- Level: " + this.hero.Level.ToString(), new Vector2(40, 575), Color.Black);

            sb.DrawString(hudFont, this.enemy.ID + "    -- Level: " + this.enemy.Level.ToString(), new Vector2(750, 575), Color.Black);

            sb.DrawString(hudFont, this.hero.CurrentHealth.ToString() + "/" + this.hero.MaxHealth.ToString(), new Vector2(this.heroHp.X + this.heroHp.Width / 3, this.heroHp.Y), Color.Black);
            sb.DrawString(hudFont, this.hero.CurrentMana.ToString() + "/" + this.hero.MaxMana.ToString(), new Vector2(this.heroMana.X + this.heroMana.Width / 3, this.heroMana.Y), Color.Black);

            sb.DrawString(hudFont, this.enemy.CurrentHealth.ToString() + "/" + this.enemy.MaxHealth.ToString(), new Vector2(this.enemyHp.X + this.enemyHp.Width / 3, this.enemyHp.Y), Color.Black);
            sb.DrawString(hudFont, this.enemy.CurrentMana.ToString() + "/" + this.enemy.MaxMana.ToString(), new Vector2(this.enemyMana.X + this.enemyMana.Width / 3, this.enemyMana.Y), Color.Black);

            #endregion

            #region Draw Inventory

            if (menuHUD == MenuHUD.Inventory)
            {
                this.heroInventory.Draw(sb);
            }

            #endregion

            DrawLog(sb); // Draw Combat Log
        }

        public ChoiceHUD CHOICEHUD
        {
            get { return this.choiceHUD; }
            set { this.choiceHUD = value; }
        }

        public MenuHUD MENUHUD
        {
            get { return this.menuHUD; }
            set { this.menuHUD = value; }
        }

        public SpellChoice SPELLCHOICE
        {
            get { return this.spellChoice; }
            set { this.spellChoice = value; }
        }

        public void AddLog(string text)
        {   
            if (this.combatLog.Count() > 5)
            {
                if (text.Length > 50)
                    this.combatLog.RemoveRange(0, 2);
                else
                    this.combatLog.RemoveAt(0);
            }

            if (text.Length > 50)
            {
                this.combatLog.Add(text.Substring(0, text.Length / 2));
                this.combatLog.Add(text.Substring(text.Length / 2));
            }
            else
                this.combatLog.Add(text);
        }

        private void DrawLog(SpriteBatch sb)
        {
            for (int i = 0; i < combatLog.Count; i++)
            {
                sb.DrawString(hudFont, combatLog.ElementAt(i), new Vector2(logPos.X, logPos.Y + (i * 25)), Color.Black);
            }
        }

        public void HitAnim(string entity)
        {
            if (entity == "hero")
                heroHit = true;
            else if (entity == "enemy")
                enemyHit = true;
        }
    }
}
