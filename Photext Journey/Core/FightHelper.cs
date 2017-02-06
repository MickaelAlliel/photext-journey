using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photext_Journey.Templates;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Photext_Journey.Core
{
    class FightHelper
    {
        static ContentManager Content;

        static int damage, power;
        static Random rand;

        static SoundEffect attack, fightStart, levelUp, potionDrink, equipArmor, shopBuy, slimeAttack;

        static SoundEffect fireball, daggerThrow, vampiricBite;
        

        public static bool IsAlive(Entity entity)
        {
            if (entity.CurrentHealth > 0)
                return true;
            return false;
        }

        public static void LoadContent(ContentManager Content)
        {
            attack = Content.Load<SoundEffect>("Sounds/Fight/attack");
            slimeAttack = Content.Load<SoundEffect>("Sounds/Fight/slimeAttack");
            fightStart = Content.Load<SoundEffect>("Sounds/Fight/fightStart");

            levelUp = Content.Load<SoundEffect>("Sounds/Misc/levelUp");
            potionDrink = Content.Load<SoundEffect>("Sounds/Misc/potionDrink");
            shopBuy = Content.Load<SoundEffect>("Sounds/Misc/shopBuy");
            equipArmor = Content.Load<SoundEffect>("Sounds/Misc/equipArmor");
            

            fireball = Content.Load<SoundEffect>("Sounds/Spells/fireball");
            daggerThrow = Content.Load<SoundEffect>("Sounds/Spells/dagger_throw");
            vampiricBite = Content.Load<SoundEffect>("Sounds/Spells/vampiric_bite");
        }

        public static string Attack(Entity attacker, Entity defender)
        {
            rand = new Random();

            try
            {
                if (defender.Defending)
                    damage = rand.Next((int)((attacker.AttackDamage + attacker.Strength / 2 - defender.Defense) * 0.3), (int)((attacker.AttackDamage + attacker.Strength / 2 - defender.Defense) * 0.6));
                else
                    damage = rand.Next((int)((attacker.AttackDamage + attacker.Strength / 2 - defender.Defense) * 0.7), attacker.AttackDamage + attacker.Strength / 2 - defender.Defense);
            }
            catch 
            {
                if (defender.Defense > attacker.AttackDamage)
                {
                    damage = (int)((attacker.AttackDamage + attacker.Strength / 2) * 0.8);
                }
            }

            defender.CurrentHealth -= damage;

            if (attacker.ID == "Mike")
                return attacker.ID + " attacked " + defender.ID + " with " + attacker.Equipment[4].ID + " for " + damage + " damage!";
            else
                return attacker.ID + " attacked " + defender.ID + " for " + damage + " damage!";
        }

        public static string Cast(Entity attacker, Entity defender, Spell spell)
        {
            rand = new Random();

            power = rand.Next((int)(((spell.power + spell.powerPerLvl * attacker.Level) + (attacker.SpellPower * spell.ratio) - (defender.Defense * spell.ratio)) * 0.7), (int)((spell.power + spell.powerPerLvl * attacker.Level) + (attacker.SpellPower * spell.ratio) - (defender.Defense * spell.ratio)));

            if (attacker.CurrentMana < spell.manaCost)
            {
                //MessageBox.Show("Not enough mana!", "Idiot!");
                return "Not enough mana!";
            }
            else if (spell.isHeal)
            {
                attacker.CurrentMana -= spell.manaCost;
                defender.CurrentHealth += power;

                return attacker.ID + " cast " + spell.ID + " for " + spell.manaCost + " mana on " + defender.ID + " and heals him " + power + " health!";
            }
            else if (spell.isDamage)
            {
                attacker.CurrentMana -= spell.manaCost;
                defender.CurrentHealth -= power;

                return attacker.ID + " cast " + spell.ID + " for " + spell.manaCost + " mana on " + defender.ID + " and deals him " + power + " damage!";
            }
            else if (spell.lifeSteal)
            {
                int lifesteal = rand.Next((int)(spell.power * spell.stealRatio) + (int)(attacker.SpellPower * spell.stealRatio * 0.7), (int)(spell.power * spell.stealRatio) + (int)(attacker.SpellPower * spell.stealRatio));

                attacker.CurrentMana -= spell.manaCost;
                defender.CurrentHealth -= power;

                attacker.CurrentHealth += lifesteal;

                return attacker.ID + " cast " + spell.ID + " for " + spell.manaCost + " mana on " + defender.ID + " and deals him " + power + " damage " + "while stealing " + lifesteal + " health!";
            }

            return "";
        }

        public static void UseItem(Hero user, int row, int column)
        {
            if (user.Inventory[row, column].Type == "Potion")
            {
                PlayEffect("potionDrink");

                user.CurrentHealth += user.Inventory[row,column].Health;
                user.CurrentMana += user.Inventory[row,column].Mana;

                user.Inventory[row, column] = new Items.NullItem(Content);
            }

            else if (user.Inventory[row, column].Type == "Weapon" || user.Inventory[row, column].Type == "Head" || user.Inventory[row, column].Type == "Chest" || user.Inventory[row, column].Type == "Legs" || user.Inventory[row, column].Type == "Feets")
            {
                PlayEffect("equipArmor");

                if (user.Inventory[row, column].Type == "Head")
                    user.UnEquip(0);
                else if (user.Inventory[row, column].Type == "Chest")
                    user.UnEquip(1);
                else if (user.Inventory[row, column].Type == "Legs")
                    user.UnEquip(2);
                else if (user.Inventory[row, column].Type == "Feets")
                    user.UnEquip(3);
                else if (user.Inventory[row, column].Type == "Weapon")
                    user.UnEquip(4);

                user.Equip(user.Inventory[row, column]);

                user.Inventory[row, column] = new Items.NullItem(Content);
            }
        }

        public static void UpdateStats(Entity entity)
        {
            if (entity.CurrentHealth < 0)
            {
                entity.CurrentHealth = 0;
                entity.isAlive = false;
            }
            else if (entity.CurrentHealth > entity.MaxHealth)
                entity.CurrentHealth = entity.MaxHealth;

            if (entity.CurrentMana < 0)
                entity.CurrentMana = 0;
            else if (entity.CurrentMana > entity.MaxMana)
                entity.CurrentMana = entity.MaxMana;
        }

        public static void PlayEffect(string effectName)
        {
            if (effectName == "attack")
                attack.Play();
            else if (effectName == "slimeAttack")
                slimeAttack.Play();
            else if (effectName == "fightStart")
                fightStart.Play();

            //--------------------------------

            else if (effectName == "levelUp")
                levelUp.Play();
            else if (effectName == "potionDrink")
                potionDrink.Play();
            else if (effectName == "shopBuy")
                shopBuy.Play();
            else if (effectName == "equipArmor")
                equipArmor.Play();

            //---------------------------------

            else if (effectName == "fireball")
                fireball.Play();
            else if (effectName == "daggerThrow")
                daggerThrow.Play();
            else if (effectName == "vampiricBite")
                vampiricBite.Play();
        }

        public static void SetContent(ContentManager ContentM)
        {
            Content = ContentM;
        }


    }
}
