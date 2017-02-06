using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Photext_Journey.Editor
{
    public partial class EditorGUI : Form
    {
        #region Private Variables

        private Texture2D widthGridLine, heightGridLine;
        private Texture2D[][,] layersArray;
        private Texture2D[,] layer1, layer2, layer3;
        private int TileSize;
        private int mapWidth, mapHeight; // In tiles of TileSize.px
        private StreamWriter writer;
        private StreamReader reader;

        private Texture2D blank, bush, chest, chestOpen, dirt, fenceHorizontal, fenceVertical, grass, grassTile, plank, rock, sand, sky, stone, water, wood, yellowStone, stoneBricks, highGrass, warp, store;
        private Texture2D slime, wizard, necromancer, bird, goblin;

        #endregion

        public EditorGUI(int width, int height, bool scrolling)
        {
            InitializeComponent();

            this.mapWidth = width;
            this.mapHeight = height;
            this.label_width.Text = "Width: " + width.ToString();
            this.label_height.Text = "Height: " + height.ToString();

            this.textBox_currentLayer.Text = "Layer 1";
            this.textBox_entities.Text = "FALSE";
            this.radioButton_blank.Checked = true;

            this.TileSize = 32;
            this.layer1 = new Texture2D[mapWidth, mapHeight];
            this.layer2 = new Texture2D[mapWidth, mapHeight];
            this.layer3 = new Texture2D[mapWidth, mapHeight];

            this.layersArray = new Texture2D[3][,];
            this.layersArray[0] = layer1;
            this.layersArray[1] = layer2;
            this.layersArray[2] = layer3;
        }

        #region Hide Button

        private void button_hide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion

        #region Save Button

        private void button_save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog_level.ShowDialog() == DialogResult.OK)
            {

                File.Delete(this.saveFileDialog_level.FileName);
                this.writer = new StreamWriter(this.saveFileDialog_level.FileName);

                try
                {
                    for (int a = 0; a < layersArray.Length; a++)
                    {
                        for (int i = 0; i < this.mapWidth; i++)
                        {
                            for (int j = 0; j < this.mapHeight; j++)
                            {
                                if (this.layersArray[a][i, j] == this.blank)
                                    this.writer.WriteLine("blank");
                                else if (this.layersArray[a][i, j] == this.bush)
                                    this.writer.WriteLine("bush");
                                else if (this.layersArray[a][i, j] == this.plank)
                                    this.writer.WriteLine("plank");
                                else if (this.layersArray[a][i, j] == this.dirt)
                                    this.writer.WriteLine("dirt");
                                else if (this.layersArray[a][i, j] == this.grass)
                                    this.writer.WriteLine("grass");
                                else if (this.layersArray[a][i, j] == this.grassTile)
                                    this.writer.WriteLine("grassTile");
                                else if (this.layersArray[a][i, j] == this.rock)
                                    this.writer.WriteLine("rock");
                                else if (this.layersArray[a][i, j] == this.sand)
                                    this.writer.WriteLine("sand");
                                else if (this.layersArray[a][i, j] == this.sky)
                                    this.writer.WriteLine("sky");
                                else if (this.layersArray[a][i, j] == this.stone)
                                    this.writer.WriteLine("stone");
                                else if (this.layersArray[a][i, j] == this.water)
                                    this.writer.WriteLine("water");
                                else if (this.layersArray[a][i, j] == this.wood)
                                    this.writer.WriteLine("wood");
                                else if (this.layersArray[a][i, j] == this.stoneBricks)
                                    this.writer.WriteLine("stoneBricks");
                                else if (this.layersArray[a][i, j] == this.yellowStone)
                                    this.writer.WriteLine("yellowStone");
                                else if (this.layersArray[a][i, j] == this.highGrass)
                                    this.writer.WriteLine("highGrass");
                                else if (this.layersArray[a][i, j] == this.warp)
                                    this.writer.WriteLine("warp");
                                else if (this.layersArray[a][i, j] == this.chest)
                                    this.writer.WriteLine("chest");
                                else if (this.layersArray[a][i, j] == this.chestOpen)
                                    this.writer.WriteLine("chestOpen");
                                else if (this.layersArray[a][i, j] == this.fenceHorizontal)
                                    this.writer.WriteLine("fenceHorizontal");
                                else if (this.layersArray[a][i, j] == this.fenceVertical)
                                    this.writer.WriteLine("fenceVertical");
                                else if (this.layersArray[a][i, j] == this.store)
                                    this.writer.WriteLine("store");
                                //-------------ENTITIES-----------------
                                else if (this.layersArray[a][i, j] == this.slime)
                                    this.writer.WriteLine("slime");
                                else if (this.layersArray[a][i, j] == this.wizard)
                                    this.writer.WriteLine("wizard");
                                else if (this.layersArray[a][i, j] == this.necromancer)
                                    this.writer.WriteLine("necromancer");
                                else if (this.layersArray[a][i, j] == this.bird)
                                    this.writer.WriteLine("bird");
                                else if (this.layersArray[a][i, j] == this.goblin)
                                    this.writer.WriteLine("goblin");
                            }
                        }
                    }

                    this.writer.Dispose();

                    MessageBox.Show("Map Saved Successfully!", "Success!");

                }
                catch { MessageBox.Show("Map Couldn't Be Saved!", "ERROR!"); }

                
            }
        }

        #endregion

        #region Load Button

        private void button_load_Click(object sender, EventArgs e)
        {
            string tileName;

            if (this.openFileDialog_level.ShowDialog() == DialogResult.OK)
            {
                this.reader = new StreamReader(this.openFileDialog_level.FileName);

                try
                {
                    for (int a = 0; a < layersArray.Length; a++)
                    {
                        for (int i = 0; i < mapWidth; i++)
                        {
                            for (int j = 0; j < mapHeight; j++)
                            {
                                tileName = this.reader.ReadLine();

                                switch (tileName)
                                {
                                    case "blank":
                                        layersArray[a][i, j] = blank;
                                        break;
                                    case "bush":
                                        layersArray[a][i, j] = bush;
                                        break;
                                    case "plank":
                                        layersArray[a][i, j] = plank;
                                        break;
                                    case "dirt":
                                        layersArray[a][i, j] = dirt;
                                        break;
                                    case "grass":
                                        layersArray[a][i, j] = grass;
                                        break;
                                    case "grassTile":
                                        layersArray[a][i, j] = grassTile;
                                        break;
                                    case "rock":
                                        layersArray[a][i, j] = rock;
                                        break;
                                    case "sand":
                                        layersArray[a][i, j] = sand;
                                        break;
                                    case "sky":
                                        layersArray[a][i, j] = sky;
                                        break;
                                    case "stone":
                                        layersArray[a][i, j] = stone;
                                        break;
                                    case "water":
                                        layersArray[a][i, j] = water;
                                        break;
                                    case "wood":
                                        layersArray[a][i, j] = wood;
                                        break;
                                    case "yellowStone":
                                        layersArray[a][i, j] = yellowStone;
                                        break;
                                    case "stoneBricks":
                                        layersArray[a][i, j] = stoneBricks;
                                        break;
                                    case "highGrass":
                                        layersArray[a][i, j] = highGrass;
                                        break;
                                    case "warp":
                                        layersArray[a][i, j] = warp;
                                        break;
                                    case "chest":
                                        layersArray[a][i, j] = chest;
                                        break;
                                    case "chestOpen":
                                        layersArray[a][i, j] = chestOpen;
                                        break;
                                    case "fenceHorizontal":
                                        layersArray[a][i, j] = fenceHorizontal;
                                        break;
                                    case "fenceVertical":
                                        layersArray[a][i, j] = fenceVertical;
                                        break;
                                    case "store":
                                        layersArray[a][i, j] = store;
                                        break;
                                    //---------------ENTITIES---------------
                                    case "slime":
                                        layersArray[a][i, j] = slime;
                                        break;
                                    case "wizard":
                                        layersArray[a][i, j] = wizard;
                                        break;
                                    case "necromancer":
                                        layersArray[a][i, j] = necromancer;
                                        break;
                                    case "bird":
                                        layersArray[a][i, j] = bird;
                                        break;
                                    case "goblin":
                                        layersArray[a][i, j] = goblin;
                                        break;
                                }
                            }
                        }
                    }

                    this.reader.Dispose();
                }
                catch { }
            }
        }

        #endregion

        public void LoadContent(ContentManager Content)
        {
            this.widthGridLine = Content.Load<Texture2D>("Editor/widthGridLine");
            this.heightGridLine = Content.Load<Texture2D>("Editor/heightGridLine");

            this.blank = Content.Load<Texture2D>("Tiles/blankPink");
            this.bush = Content.Load<Texture2D>("Tiles/bush");
            this.chest = Content.Load<Texture2D>("Tiles/chest");
            this.chestOpen = Content.Load<Texture2D>("Tiles/chest_open");
            this.dirt = Content.Load<Texture2D>("Tiles/dirt");
            this.fenceHorizontal = Content.Load<Texture2D>("Tiles/fence_horizontal");
            this.fenceVertical = Content.Load<Texture2D>("Tiles/fence_vertical");
            this.grass = Content.Load<Texture2D>("Tiles/grass");
            this.grassTile = Content.Load<Texture2D>("Tiles/grassTile");
            this.plank = Content.Load<Texture2D>("Tiles/plank");
            this.rock = Content.Load<Texture2D>("Tiles/rock");
            this.sand = Content.Load<Texture2D>("Tiles/sand");
            this.sky = Content.Load<Texture2D>("Tiles/sky");
            this.stone = Content.Load<Texture2D>("Tiles/stone");
            this.water = Content.Load<Texture2D>("Tiles/water");
            this.wood = Content.Load<Texture2D>("Tiles/wood");
            this.highGrass = Content.Load<Texture2D>("Tiles/highGrass");
            this.yellowStone = Content.Load<Texture2D>("Tiles/yellowStone");
            this.stoneBricks = Content.Load<Texture2D>("Tiles/stoneBricks");
            this.warp = Content.Load<Texture2D>("Tiles/warp");
            this.store = Content.Load<Texture2D>("Tiles/store");

            //-------------------------------------------------------------------------

            this.slime = Content.Load<Texture2D>("Sprites/slime");
            this.wizard = Content.Load<Texture2D>("Sprites/wizard");
            this.necromancer = Content.Load<Texture2D>("Sprites/necromancer");
            this.bird = Content.Load<Texture2D>("Sprites/bird");
            this.goblin = Content.Load<Texture2D>("Sprites/goblin");

            //-------------------------------------------------------------------------

            for (int a = 0; a < layersArray.Length; a++)
            {
                for (int i = 0; i < this.layer1.GetLength(0); i++)
                {
                    for (int j = 0; j < this.layer1.GetLength(1); j++)
                    {
                        this.layersArray[a][i, j] = blank;
                    }
                }
            }
        }

        public void UpdateInput(MouseInput mouseInput, KeyboardInput keyboardInput)
        {
            #region Left Button Held

                if (mouseInput.IsLeftHeld())
                {
                    try
                    {
                        if (this.textBox_currentLayer.Text == "Layer 1")
                            this.layer1[((int)mouseInput.Pos.X) / TileSize, ((int)mouseInput.Pos.Y) / TileSize] = this.GetTile();
                        else if (this.textBox_currentLayer.Text == "Layer 2")
                            this.layer2[((int)mouseInput.Pos.X) / TileSize, ((int)mouseInput.Pos.Y) / TileSize] = this.GetTile();
                        else if (this.textBox_currentLayer.Text == "Layer 3")
                            this.layer3[((int)mouseInput.Pos.X) / TileSize, ((int)mouseInput.Pos.Y) / TileSize] = this.GetTile();
                    }
                    catch
                    {

                    }
                }
        

            #endregion

            #region Right Button Held

            if (mouseInput.IsRightHeld())
            {
                try
                {
                    if (this.textBox_currentLayer.Text == "Layer 1")
                        this.layer1[((int)mouseInput.Pos.X) / TileSize, ((int)mouseInput.Pos.Y) / TileSize] = blank;
                    else if (this.textBox_currentLayer.Text == "Layer 2")
                        this.layer2[((int)mouseInput.Pos.X) / TileSize, ((int)mouseInput.Pos.Y) / TileSize] = blank;
                    else if (this.textBox_currentLayer.Text == "Layer 3")
                        this.layer3[((int)mouseInput.Pos.X) / TileSize, ((int)mouseInput.Pos.Y) / TileSize] = blank;
                }
                catch
                {

                }
            }

            #endregion

            #region F1 Pressed

            if (keyboardInput.Pressed(Microsoft.Xna.Framework.Input.Keys.F1))
                this.Show();

            #endregion
        }

        public void Draw(SpriteBatch sb)
        {
            #region Draw Map

                for (int i = 0; i < mapWidth; i++)
                {
                    for (int j = 0; j < mapHeight; j++)
                    {
                        sb.Draw(layer1[i, j], new Vector2(i * TileSize, j * TileSize), Microsoft.Xna.Framework.Graphics.Color.White);

                        if (layer2[i, j] != this.blank)
                            sb.Draw(layer2[i, j], new Vector2(i * TileSize, j * TileSize), Microsoft.Xna.Framework.Graphics.Color.White);
                        if (layer3[i, j] != this.blank)
                            sb.Draw(layer3[i, j], new Vector2(i * TileSize, j * TileSize), Microsoft.Xna.Framework.Graphics.Color.White);
                    }
                }

            #endregion

            #region Draw Grid

            for (int i = 0; i < 1024; i += TileSize)
            {
                sb.Draw(this.heightGridLine, new Vector2(i, 0), Microsoft.Xna.Framework.Graphics.Color.White);
            }

            for (int j = 0; j < 704; j += TileSize)
            {
                sb.Draw(this.widthGridLine, new Vector2(0, j), Microsoft.Xna.Framework.Graphics.Color.White);
            }
            
            #endregion

        }

        private Texture2D GetTile()
        {
            if (textBox_entities.Text == "FALSE")
            {
                if (radioButton_dirt.Checked)
                    return dirt;
                else if (radioButton_grass.Checked)
                    return grass;
                else if (radioButton_grassTile.Checked)
                    return grassTile;
                else if (radioButton_rock.Checked)
                    return rock;
                else if (radioButton_sand.Checked)
                    return sand;
                else if (radioButton_sky.Checked)
                    return sky;
                else if (radioButton_stone.Checked)
                    return stone;
                else if (radioButton_water.Checked)
                    return water;
                else if (radioButton_wood.Checked)
                    return wood;
                else if (radioButton_bush.Checked)
                    return bush;
                else if (radioButton_plank.Checked)
                    return plank;
                else if (radioButton_highGrass.Checked)
                    return highGrass;
                else if (radioButton_stoneBricks.Checked)
                    return stoneBricks;
                else if (radioButton_yellowStone.Checked)
                    return yellowStone;
                else if (radioButton_warp.Checked)
                    return warp;
                else if (radioButton_Chest.Checked)
                    return chest;
                else if (radioButton_Chest_Open.Checked)
                    return chestOpen;
                else if (radioButton_Fence_Horizontal.Checked)
                    return fenceHorizontal;
                else if (radioButton_Fence_Vertical.Checked)
                    return fenceVertical;
                else if (radioButton_Store.Checked)
                    return store;
                else
                    return blank;
            }
            //----------ENTITIES-----------
            else
            {
                if (radioButton_Slime.Checked)
                    return slime;
                else if (radioButton_wizard.Checked)
                    return wizard;
                else if (radioButton_necromancer.Checked)
                    return necromancer;
                else if (radioButton_Bird.Checked)
                    return bird;
                else if (radioButton_Goblin.Checked)
                    return goblin;
            }
            return blank;
        }

        #region Layers Button

        private void button_layer1_Click(object sender, EventArgs e)
        {
            textBox_currentLayer.Text = "Layer 1";
        }

        private void button_layer2_Click(object sender, EventArgs e)
        {
            textBox_currentLayer.Text = "Layer 2";
        }

        private void button_layer3_Click(object sender, EventArgs e)
        {
            textBox_currentLayer.Text = "Layer 3";
        }

        #endregion

        #region Fill Screen 

        private void button_fillScreen_Click(object sender, EventArgs e)
        {
                for (int i = 0; i < mapWidth; i++)
                {
                    for (int j = 0; j < mapHeight; j++)
                    {
                        if (this.textBox_currentLayer.Text == "Layer 1")
                            this.layer1[i, j] = this.GetTile();
                        else if (this.textBox_currentLayer.Text == "Layer 2")
                            this.layer2[i, j] = this.GetTile();
                        else if (this.textBox_currentLayer.Text == "Layer 3")
                            this.layer3[i, j] = this.GetTile();
                    }
                }
        }

        #endregion

        #region Entities Toggle

        private void button_Entities_Click(object sender, EventArgs e)
        {
            if (textBox_entities.Text == "FALSE")
                textBox_entities.Text = "TRUE";
            else
                textBox_entities.Text = "FALSE";
        }

        #endregion

    }
}
