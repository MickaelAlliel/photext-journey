using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Photext_Journey.Enemies;
using Photext_Journey.Templates;
using Microsoft.Xna.Framework.Audio;
using Photext_Journey.Spells;

namespace Photext_Journey.Core
{
    class Fight
    {
        #region Private Variables

        private ContentManager Content;
        private HUD fightHUD;

        private Hero hero;
        private Entity enemy;
        private int AIDelay;

        private string turn;

        #endregion

        public Fight(Hero hero, Entity enemy)
        {
            this.turn = "hero";

            this.hero = hero; // Reference Hero.
            this.enemy = enemy; // Reference Enemy.

            AIDelay = 0;

            this.fightHUD = new HUD(this.hero, this.enemy, this); // Create HUD
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = Content; // Create a reference to the game's Content Manager
            FightHelper.SetContent(Content);

            FightHelper.LoadContent(Content);
            this.fightHUD.LoadContent(this.Content); // Loads HUD Content

        }

        public void Update(GameTime gameTime, MouseInput mouseInput, KeyboardInput keyboardInput)
        {
            #region Hero Turn

            if (this.turn == "hero")
            {
                this.HeroNavigateHUD(mouseInput);
            }

            #endregion

            #region AI Turn Timer

            else if (this.turn == "enemy")
            {
                if (this.AIDelay > 75)
                {
                    this.AIDelay = 0;
                    this.EnemyNavigateAI();
                }
                else
                    this.AIDelay++;
            }

            #endregion

            FightHelper.UpdateStats(enemy);
            FightHelper.UpdateStats(hero);

            this.enemy.fightAnim.Update(gameTime); // Update Enemy Animation
            this.hero.fightAnim.Update(gameTime); // Update Hero Animation
            
            this.fightHUD.Update(mouseInput, keyboardInput); // Update HUD
        }

        public void Draw(SpriteBatch sb)
        {
            this.fightHUD.Draw(sb); // Draw HUD
        }

        public void ResetFight(Hero hero, Entity enemy)
        {
            this.turn = "hero";

            this.hero = hero; // Reference Hero.
            this.enemy = enemy; // Reference Enemy.

            AIDelay = 0;

            this.fightHUD = new HUD(this.hero, this.enemy, this); // Create HUD
            this.fightHUD.LoadContent(Content);

            FightHelper.PlayEffect("fightStart");
        }

        public bool CheckFinished()
        {
            if (!FightHelper.IsAlive(enemy))
            {
                this.hero.Experience += enemy.Experience;
                this.hero.Gold += enemy.Gold;

                return true;
            }
            else if (!FightHelper.IsAlive(hero))
            {
                return true;
            }
            else
                return false;
        }

        //-------------- COMBAT --------------\\

        private void HeroNavigateHUD(MouseInput mouseInput)
        {
            if (this.fightHUD.CHOICEHUD == HUD.ChoiceHUD.Attack && mouseInput.IsLeftClicked())
                {
                    fightHUD.HitAnim("enemy");
                    FightHelper.PlayEffect("attack");
                    this.fightHUD.AddLog(FightHelper.Attack(hero, enemy));
                    this.turn = "enemy";
                }
            else if (this.fightHUD.CHOICEHUD == HUD.ChoiceHUD.Spells && mouseInput.IsLeftClicked())
                {
                    this.fightHUD.MENUHUD = HUD.MenuHUD.Spells;
                }
            else if (this.fightHUD.CHOICEHUD == HUD.ChoiceHUD.Defend && mouseInput.IsLeftClicked())
            {
                this.hero.Defending = true;
                this.turn = "enemy";
            }
            else if (this.fightHUD.CHOICEHUD == HUD.ChoiceHUD.Inventory && mouseInput.IsLeftClicked())
            {
                this.fightHUD.MENUHUD = HUD.MenuHUD.Inventory;
            }

            if (this.fightHUD.MENUHUD == HUD.MenuHUD.Spells && this.fightHUD.SPELLCHOICE == HUD.SpellChoice.ArcaneShock && mouseInput.IsLeftClicked())
            {
                this.fightHUD.AddLog(FightHelper.Cast(hero, enemy, new Spells.ArcaneShock()));
                this.turn = "enemy";
            }
            else if (this.fightHUD.MENUHUD == HUD.MenuHUD.Spells && this.fightHUD.SPELLCHOICE == HUD.SpellChoice.SelfCure && mouseInput.IsLeftClicked())
            {
                this.fightHUD.AddLog(FightHelper.Cast(hero, hero, new Spells.SelfCure()));
                this.turn = "enemy";
            }    
        }

        private void EnemyNavigateAI()
        {
            if (this.enemy.AI() == "Attack")
            {
                this.fightHUD.AddLog(FightHelper.Attack(enemy, hero));

                if (this.enemy.ID == "Slime")
                    FightHelper.PlayEffect("slimeAttack");
                else
                    FightHelper.PlayEffect("Attack");
            }
            else if (this.enemy.AI() == "Fireball")
            {
                this.fightHUD.AddLog(FightHelper.Cast(enemy, hero, new Fireball()));
                FightHelper.PlayEffect("fireball");
            }
            else if (this.enemy.AI() == "Vampiric Bite")
            {
                this.fightHUD.AddLog(FightHelper.Cast(enemy, hero, new VampiricBite()));
                FightHelper.PlayEffect("vampiricBite");
            }
            else if (this.enemy.AI() == "Dagger Throw")
            {
                this.fightHUD.AddLog(FightHelper.Cast(enemy, hero, new DaggerThrow()));
                FightHelper.PlayEffect("daggerThrow");
            }

            

            fightHUD.HitAnim("hero");

            if (this.hero.Defending)
                this.hero.Defending = false;

            this.turn = "hero";
        }

        public void UsedItemPass()
        {
            if (turn == "hero")
                turn = "enemy";

            this.fightHUD.MENUHUD = HUD.MenuHUD.Main;
        }

    }
}
