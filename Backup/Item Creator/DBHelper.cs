using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBHelper
{
    public partial class DBHelper : Form
    {
        public DBHelper()
        {
            InitializeComponent();
        }

        #region Items :

        private void button_Preview_Click(object sender, EventArgs e)
        {
            textBox_Preview.Text = "";

            textBox_Preview.AppendText("using Photext_Journey.Templates; \n");
            textBox_Preview.AppendText("using Microsoft.Xna.Framework; \n");
            textBox_Preview.AppendText("using Microsoft.Xna.Framework.Graphics; \n");
            textBox_Preview.AppendText("using Microsoft.Xna.Framework.Content; \n\n");

            textBox_Preview.AppendText("namespace Photext_Journey.Items\n");
            textBox_Preview.AppendText("{\n");//Open NameSpace
            textBox_Preview.AppendText("    class " + textBox_Name.Text + " : Item\n");
            textBox_Preview.AppendText("    {\n");//Open Class
            textBox_Preview.AppendText("        public " + textBox_Name.Text + "(ContentManager Content)\n");
            textBox_Preview.AppendText("        {\n");//Open Constructeur
            textBox_Preview.AppendText("            base.Health = " + textBox_HP.Text +";\n");
            textBox_Preview.AppendText("            base.Mana = " + textBox_Mana.Text + ";\n\n");
            textBox_Preview.AppendText("            base.Strength = " + textBox_Strength.Text + ";\n");
            textBox_Preview.AppendText("            base.SpellPower = " + textBox_SpellPower.Text + ";\n");
            textBox_Preview.AppendText("            base.Defense = " + textBox_Defense.Text + ";\n\n");
            textBox_Preview.AppendText("            base.Gold = " + textBox_Gold.Text + ";\n\n");
            textBox_Preview.AppendText("            base.Type = \"" + comboBox_Type.Text + "\";\n");
            textBox_Preview.AppendText("            base.ID = \"" + textBox_ID.Text + "\";\n");
            textBox_Preview.AppendText("            base.Texture = Content.Load<Texture2D>(\"" + textBox_Texture.Text + "\");\n");
            textBox_Preview.AppendText("        }\n");//End Constructeur
            textBox_Preview.AppendText("\n");
            textBox_Preview.AppendText("    }\n");//End Classe
            textBox_Preview.AppendText("\n");
            textBox_Preview.AppendText("}\n");//End NameSpace
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            if (openFileDialog_Item.ShowDialog() == DialogResult.OK)
            {
                string directoryPath = System.IO.Path.GetDirectoryName(openFileDialog_Item.FileName);
                MessageBox.Show(directoryPath + "\\Items\\" + textBox_Name.Text + ".cs");//En suposant que tu les ajoute dans un dossier item
                System.IO.File.WriteAllLines(directoryPath + "\\Items\\" + textBox_Name.Text + ".cs", textBox_Preview.Lines);
                int line = 0;

                string[] lines = System.IO.File.ReadAllLines(openFileDialog_Item.FileName);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains("<Import Project=")) // Recupere une ligne avant la fin du projet et qui est unique
                    {
                        line = i - 1;
                    }

                }
                System.IO.TextWriter tw = new System.IO.StreamWriter(openFileDialog_Item.FileName);
                for (int i = 0; i < lines.Length; i++)
                {
                    tw.WriteLine(lines[i]);
                    if (line == i)
                    {
                        tw.WriteLine("<ItemGroup>\n");
                        tw.WriteLine("<Compile Include=\"Items\\" + textBox_Name.Text + ".cs" + "\" />");//En suposant que tu les ajoute dans un dossier item
                        tw.WriteLine("</ItemGroup>");
                        tw.WriteLine("\n");
                    }

                }
                tw.Close();
            }
        }

        #endregion

        #region Spells :

        private void button_PreviewSpells_Click(object sender, EventArgs e)
        {
            textBox_PreviewSpells.Text = "";

            textBox_PreviewSpells.AppendText("namespace Photext_Journey.Spells\n");
            textBox_PreviewSpells.AppendText("{\n");//Open NameSpace
            textBox_PreviewSpells.AppendText("    class " + textBox_NameSpells.Text + " : Spell\n");
            textBox_PreviewSpells.AppendText("    {\n");//Open Class
            textBox_PreviewSpells.AppendText("        public " + textBox_NameSpells.Text + "()\n");
            textBox_PreviewSpells.AppendText("        {\n");//Open Constructeur
            textBox_PreviewSpells.AppendText("            base.ID = " + textBox_IDSpells.Text + ";\n\n");

            if (comboBox_TypeSpells.Text == "Heal")
                textBox_PreviewSpells.AppendText("            base.isHeal = true;\n\n");
            else if (comboBox_TypeSpells.Text == "Damage")
                textBox_PreviewSpells.AppendText("            base.isDamage = true;\n\n");
            else if (comboBox_TypeSpells.Text == "Life Steal")
                textBox_PreviewSpells.AppendText("            base.lifeSteal = true;\n\n");

            textBox_PreviewSpells.AppendText("            base.manaCost = " + textBox_ManaCostSpells.Text + ";\n");
            textBox_PreviewSpells.AppendText("            base.power = " + textBox_SpellPower.Text + ";\n");
            textBox_PreviewSpells.AppendText("            base.ratio = " + textBox_RatioSpells.Text + ";\n");
            textBox_PreviewSpells.AppendText("            base.stealRatio = " + textBox_StealRatioSpells.Text + ";\n");

            textBox_PreviewSpells.AppendText("        }\n");//End Constructeur
            textBox_PreviewSpells.AppendText("\n");
            textBox_PreviewSpells.AppendText("    }\n");//End Classe
            textBox_PreviewSpells.AppendText("\n");
            textBox_PreviewSpells.AppendText("}\n");//End NameSpace
        }

        private void button_ExportSpells_Click(object sender, EventArgs e)
        {
            if (openFileDialog_Item.ShowDialog() == DialogResult.OK)
            {
                string directoryPath = System.IO.Path.GetDirectoryName(openFileDialog_Item.FileName);
                MessageBox.Show(directoryPath + "\\Spells\\" + textBox_NameSpells.Text + ".cs");//En suposant que tu les ajoute dans un dossier item
                System.IO.File.WriteAllLines(directoryPath + "\\Spells\\" + textBox_NameSpells.Text + ".cs", textBox_PreviewSpells.Lines);
                int line = 0;

                string[] lines = System.IO.File.ReadAllLines(openFileDialog_Item.FileName);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains("<Import Project=")) // Recupere une ligne avant la fin du projet et qui est unique
                    {
                        line = i - 1;
                    }

                }
                System.IO.TextWriter tw = new System.IO.StreamWriter(openFileDialog_Item.FileName);
                for (int i = 0; i < lines.Length; i++)
                {
                    tw.WriteLine(lines[i]);
                    if (line == i)
                    {
                        tw.WriteLine("<ItemGroup>\n");
                        tw.WriteLine("<Compile Include=\"Spells\\" + textBox_NameSpells.Text + ".cs" + "\" />");//En suposant que tu les ajoute dans un dossier item
                        tw.WriteLine("</ItemGroup>");
                        tw.WriteLine("\n");
                    }

                }
                tw.Close();
            }
        }

        #endregion

        #region Enemies :

        private void button_PreviewEnemies_Click(object sender, EventArgs e)
        {
            textBox_PreviewEnemies.Text = "";

            textBox_PreviewEnemies.AppendText("using System; \n");
            textBox_PreviewEnemies.AppendText("using Photext_Journey.Core; \n");
            textBox_PreviewEnemies.AppendText("using Photext_Journey.Templates; \n");
            textBox_PreviewEnemies.AppendText("using Microsoft.Xna.Framework; \n");
            textBox_PreviewEnemies.AppendText("using Microsoft.Xna.Framework.Graphics; \n");
            textBox_PreviewEnemies.AppendText("using Microsoft.Xna.Framework.Content; \n\n");

            textBox_PreviewEnemies.AppendText("namespace Photext_Journey.Enemies\n");
            textBox_PreviewEnemies.AppendText("{\n");//Open NameSpace
            textBox_PreviewEnemies.AppendText("    class " + textBox_NameEnemies.Text + " : Entity\n");
            textBox_PreviewEnemies.AppendText("    {\n");//Open Class
            textBox_PreviewEnemies.AppendText("        public " + textBox_NameEnemies.Text + "(ContentManager Content)\n");
            textBox_PreviewEnemies.AppendText("        {\n");//Open Constructeur
            textBox_PreviewEnemies.AppendText("            base.CurrentHealth = " + textBox_HPEnemies.Text + ";\n");
            textBox_PreviewEnemies.AppendText("            base.MaxHealth = " + textBox_HPEnemies.Text + ";\n");
            textBox_PreviewEnemies.AppendText("            base.CurrentMana = " + textBox_ManaEnemies.Text + ";\n");
            textBox_PreviewEnemies.AppendText("            base.MaxMana = " + textBox_ManaEnemies.Text + ";\n\n");

            textBox_PreviewEnemies.AppendText("            base.AttackDamage = " + textBox_AttackDamageEnemies.Text + ";\n");
            textBox_PreviewEnemies.AppendText("            base.Strength = " + textBox_StrengthEnemies.Text + ";\n");
            textBox_PreviewEnemies.AppendText("            base.SpellPower = " + textBox_SpellPowerEnemies.Text + ";\n");
            textBox_PreviewEnemies.AppendText("            base.Defense = " + textBox_DefenseEnemies.Text + ";\n\n");

            textBox_PreviewEnemies.AppendText("            base.Gold = " + textBox_GoldEnemies.Text + ";\n");
            textBox_PreviewEnemies.AppendText("            base.Experience = " + textBox_ExperienceEnemies.Text + ";\n\n");

            textBox_PreviewEnemies.AppendText("            base.ID = \"" + textBox_IDEnemies.Text + "\";\n");
            textBox_PreviewEnemies.AppendText("            base.Level = " + textBox_LevelEnemies.Text + ";\n\n");
            
            textBox_PreviewEnemies.AppendText("            base.fightTexture = Content.Load<Texture2D>(\"" + textBox_FightTextureEnemies.Text + "\");\n");
            textBox_PreviewEnemies.AppendText("            base.fightAnim = new Animation(Content.Load<Texture2D>(\"" + textBox_FightAnimationEnemies.Text + "\"), 1, 2, 50);\n\n");

            textBox_PreviewEnemies.AppendText("            base.fightPos = new Vector2(800, 400);\n\n");

            textBox_PreviewEnemies.AppendText("            base.AIChoice = \"\";\n");
            textBox_PreviewEnemies.AppendText("        }\n");//End Constructeur
            textBox_PreviewEnemies.AppendText("\n\n\n");

            textBox_PreviewEnemies.AppendText("         public override string AI()\n"); // Start AI
            textBox_PreviewEnemies.AppendText("         {\n");
            textBox_PreviewEnemies.AppendText("             this.rand = new Random();\n");
            textBox_PreviewEnemies.AppendText("             this.AIChoice = \"Attack\";\n");
            textBox_PreviewEnemies.AppendText("             return this.AIChoice;\n");
            textBox_PreviewEnemies.AppendText("         }\n"); // End AI
            
            textBox_PreviewEnemies.AppendText("     }\n");//End Classe
            textBox_PreviewEnemies.AppendText("\n");
            textBox_PreviewEnemies.AppendText("}\n");//End NameSpace
        }

        private void button_ExportEnemies_Click(object sender, EventArgs e)
        {
            if (openFileDialog_Item.ShowDialog() == DialogResult.OK)
            {
                string directoryPath = System.IO.Path.GetDirectoryName(openFileDialog_Item.FileName);
                MessageBox.Show(directoryPath + "\\Enemies\\" + textBox_NameEnemies.Text + ".cs");//En suposant que tu les ajoute dans un dossier item
                System.IO.File.WriteAllLines(directoryPath + "\\Enemies\\" + textBox_NameEnemies.Text + ".cs", textBox_PreviewEnemies.Lines);
                int line = 0;

                string[] lines = System.IO.File.ReadAllLines(openFileDialog_Item.FileName);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains("<Import Project=")) // Recupere une ligne avant la fin du projet et qui est unique
                    {
                        line = i - 1;
                    }

                }
                System.IO.TextWriter tw = new System.IO.StreamWriter(openFileDialog_Item.FileName);
                for (int i = 0; i < lines.Length; i++)
                {
                    tw.WriteLine(lines[i]);
                    if (line == i)
                    {
                        tw.WriteLine("<ItemGroup>\n");
                        tw.WriteLine("<Compile Include=\"Enemies\\" + textBox_NameEnemies.Text + ".cs" + "\" />");//En suposant que tu les ajoute dans un dossier item
                        tw.WriteLine("</ItemGroup>");
                        tw.WriteLine("\n");
                    }

                }
                tw.Close();
            }
        }

        #endregion

        #region Exit Buttons

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_ExitSpells_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_ExitEnemies_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        

    }
}
