 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Photext_Journey.Templates;
using System.Windows.Forms;
using Photext_Journey.Items;
using Microsoft.Xna.Framework.Content;

namespace Photext_Journey.Core
{
    class SaveLoad
    {
        private StreamWriter saver;
        private StreamReader loader;

        private Hero hero;
        private int xMap, yMap;

        public SaveLoad(Hero hero, int xMap, int yMap)
        {
            this.hero = hero;
            this.xMap = xMap;
            this.yMap = yMap;
        }

        public void SaveGame()
        {
            try
            {
                File.Delete("Content/Saves/mainSave.txt");
                this.saver = new StreamWriter("Content/Saves/mainSave.txt"); // Reload StreamWriter

                saver.WriteLine(xMap);
                saver.WriteLine(yMap);

                saver.WriteLine(hero.CurrentHealth);
                saver.WriteLine(hero.MaxHealth);
                saver.WriteLine(hero.CurrentMana);
                saver.WriteLine(hero.MaxMana);

                saver.WriteLine(hero.AttackDamage);
                saver.WriteLine(hero.Strength);
                saver.WriteLine(hero.SpellPower);
                saver.WriteLine(hero.Defense);

                saver.WriteLine(hero.Experience);
                saver.WriteLine(hero.Gold);

                for (int i = 0; i < hero.Inventory.GetLength(0); i++)
                    for (int j = 0; j < hero.Inventory.GetLength(1); j++)
                        saver.WriteLine(hero.Inventory[i, j].ID);

                if (hero.isAlive)
                    saver.WriteLine("alive");
                else
                    saver.WriteLine("dead");

                saver.WriteLine(hero.Level);

                for (int i =0; i < hero.leveledTable.Length; i++)
                {
                    if (hero.leveledTable[i])
                        saver.WriteLine("true");
                    else
                        saver.WriteLine("false");
                }

                saver.WriteLine(hero.pos.X);
                saver.WriteLine(hero.pos.Y);

                this.saver.Dispose();

                MessageBox.Show("Saved Successfully!", "Success!");
            }
            catch { MessageBox.Show("Game Couldn't Be Saved!", "ERROR!"); }
        }

        public void LoadGame(Hero hero, Game game, ContentManager Content)
        {
            try
            {
                this.loader = new StreamReader("Content/Saves/mainSave.txt"); // Reload StreamReader
                string item = "";

                game.XMAP = Convert.ToInt32(loader.ReadLine());
                game.YMAP = Convert.ToInt32(loader.ReadLine());

                hero.CurrentHealth = Convert.ToInt32(loader.ReadLine());
                hero.MaxHealth = Convert.ToInt32(loader.ReadLine());
                hero.CurrentMana = Convert.ToInt32(loader.ReadLine());
                hero.MaxMana = Convert.ToInt32(loader.ReadLine());

                hero.AttackDamage = Convert.ToInt32(loader.ReadLine());
                hero.Strength = Convert.ToInt32(loader.ReadLine());
                hero.SpellPower = Convert.ToInt32(loader.ReadLine());
                hero.Defense = Convert.ToInt32(loader.ReadLine());

                hero.Experience = Convert.ToInt32(loader.ReadLine());
                hero.Gold = Convert.ToInt32(loader.ReadLine());

                for (int i = 0; i < hero.Inventory.GetLength(0); i++)
                    for (int j = 0; j < hero.Inventory.GetLength(1); j++)
                    {
                        item = loader.ReadLine();

                        if (item == "")
                            hero.Inventory[i, j] = new NullItem(Content);
                        else if (item == "Health Potion")
                            hero.Inventory[i, j] = new HealthPotion(Content);
                        else if (item == "Mana Potion")
                            hero.Inventory[i, j] = new ManaPotion(Content);
                        else if (item == "Sword")
                            hero.Inventory[i,j] = new StartSword(Content);
                    }

                if (loader.ReadLine() == "alive")
                    hero.isAlive = true;
                else
                    hero.isAlive = false;

                hero.Level = Convert.ToInt32(loader.ReadLine());

                for (int i = 0; i < hero.leveledTable.Length; i++)
                {
                    if (loader.ReadLine() == "true")
                        hero.leveledTable[i] = true;
                    else
                        hero.leveledTable[i] = false;
                }

                hero.pos.X = Convert.ToInt32(loader.ReadLine());
                hero.pos.Y = Convert.ToInt32(loader.ReadLine());

                this.loader.Dispose();

                MessageBox.Show("Loaded Successfully!", "Success!");
            }
            catch { MessageBox.Show("Game Couldn't Be Loaded!", "ERROR!"); }
        }
    }
}
