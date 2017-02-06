using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.IO;
using Photext_Journey.Templates;

namespace Photext_Journey
{
    class Level
    {
        #region Private Variables

        private SpriteFont mapFont;
        private string levelPath;

        private StreamReader reader;
        private Texture2D[][,] layersArray;
        private Texture2D[,] layer1, layer2, layer3;
        private int TileSize;
        private int mapWidth, mapHeight;
        private string tileName;
        private string mapName;
        private Texture2D blank, bush, chest, chestOpen, dirt, fenceHorizontal, fenceVertical, grass, grassTile, plank, rock, sand, sky, stone, water, wood, highGrass, yellowStone, stoneBricks, warp, store;
        private Texture2D slime, wizard, necromancer, bird, goblin;

        private Texture2D bar;
        private Color opacity;

        private Rectangle[,] collisionRects;

        #endregion

        public Level(string levelPath, string mapName)
        {
            this.tileName = "";
            this.mapName = mapName;
            this.levelPath = levelPath;
            this.TileSize = 32;
            this.mapWidth = 32;
            this.mapHeight = 22;
            this.layer1 = new Texture2D[mapWidth,mapHeight];
            this.layer2 = new Texture2D[mapWidth,mapHeight];
            this.layer3 = new Texture2D[mapWidth,mapHeight];

            this.layersArray = new Texture2D[3][,];

            this.layersArray[0] = layer1;
            this.layersArray[1] = layer2;
            this.layersArray[2] = layer3;

            this.collisionRects = new Rectangle[mapWidth, mapHeight];

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    this.collisionRects[i, j] = new Rectangle(i * TileSize, j * TileSize, TileSize, TileSize);
                }
            }

            this.opacity = new Color(255, 255, 255, 180);
        }

        public void LoadLevel()
        {
            try
            {
                this.reader = new StreamReader(levelPath);

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
            catch
            {

            }
        }

        public void LoadContent(ContentManager Content)
        {
            this.mapFont = Content.Load<SpriteFont>("Fonts/mapNameFont");
            this.bar = Content.Load<Texture2D>("HUD/bar");

            //----------------TILES--------------------------------------------

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

            //----------------ENTITIES------------------------------------------

            this.slime = Content.Load<Texture2D>("Sprites/slime");
            this.wizard = Content.Load<Texture2D>("Sprites/wizard");
            this.necromancer = Content.Load<Texture2D>("Sprites/necromancer");
            this.bird = Content.Load<Texture2D>("Sprites/bird");
            this.goblin = Content.Load<Texture2D>("Sprites/goblin");

            //------------------------------------------------------------------

        }

        public void Draw(SpriteBatch sb, Templates.Hero hero)
        {
            #region Draw Map

            for (int i = 0; i < mapWidth; i++)
                {
                    for (int j = 0; j < mapHeight; j++)
                    {
                        try
                        {
                            sb.Draw(layer1[i, j], new Vector2(i * TileSize, j * TileSize), Microsoft.Xna.Framework.Graphics.Color.White);
                            if (layer2[i, j] != this.blank)
                                sb.Draw(layer2[i, j], new Vector2(i * TileSize, j * TileSize), Microsoft.Xna.Framework.Graphics.Color.White);


                            if (hero.direction == "stopped")
                                sb.Draw(hero.texture, hero.pos, Color.White);
                            else if (hero.direction == "top")
                                hero.topAnim.Draw(sb, hero.pos);
                            else if (hero.direction == "down")
                                hero.downAnim.Draw(sb, hero.pos);
                            else if (hero.direction == "right")
                                hero.rightAnim.Draw(sb, hero.pos);
                            else if (hero.direction == "left")
                                hero.leftAnim.Draw(sb, hero.pos);
                        }
                        catch { }
                    }
                }

            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    try
                    {
                        if (layer3[i, j] != this.blank)
                            sb.Draw(layer3[i, j], new Vector2(i * TileSize, j * TileSize), Microsoft.Xna.Framework.Graphics.Color.White);
                    }
                    catch { }
                }
            }

            #endregion

            #region Draw Map Name LEFT CORNER

            sb.Draw(this.bar, new Rectangle(3, 3, 100, 25), opacity);
            sb.DrawString(mapFont, this.mapName, new Vector2(5, 5), Color.Black);

            #endregion

        }

        public Rectangle[,] COLLISIONRECTS
        {
            get { return this.collisionRects; }
        }

        public bool Collide(Rectangle rect)
        {
            if (rect.Intersects(this.collisionRects[rect.X / 32, rect.Y / 32]))
            {
                for (int a = 0; a < layersArray.Length; a++)
                {
                    if (this.layersArray[a][rect.X / 32, rect.Y / 32] == wood)
                        return true;
                    if (this.layersArray[a][rect.X / 32, rect.Y / 32] == rock)
                        return true;
                    if (this.layersArray[a][rect.X / 32, rect.Y / 32] == water)
                        return true;
                    if (this.layersArray[a][rect.X / 32, rect.Y / 32] == fenceHorizontal)
                        return true;
                    if (this.layersArray[a][rect.X / 32, rect.Y / 32] == fenceVertical)
                        return true;
                    if (this.layersArray[a][rect.X / 32, rect.Y / 32] == chest)
                        return true;
                    if (this.layersArray[a][rect.X / 32, rect.Y / 32] == chestOpen)
                        return true;
                    if (this.layersArray[a][rect.X / 32, rect.Y / 32] == store)
                        return true;
                }
            }

            if (rect.Intersects(this.collisionRects[rect.X / 32, rect.Y / 32 + (rect.Height / 32)]))
            {
                for (int a = 0; a < layersArray.Length; a++)
                {
                    if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == wood)
                        return true;
                    if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == rock)
                        return true;
                    if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == water)
                        return true;
                    if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == fenceHorizontal)
                        return true;
                    if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == fenceVertical)
                        return true;
                    if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == chest)
                        return true;
                    if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == chestOpen)
                        return true;
                    if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == store)
                        return true;
                }
            }

            if (rect.Intersects(this.collisionRects[rect.X / 32 + (rect.Width / 32), rect.Y / 32]))
            {
                for (int a = 0; a < layersArray.Length; a++)
                {
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == wood)
                        return true;
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == rock)
                        return true;
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == water)
                        return true;
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == fenceHorizontal)
                        return true;
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == fenceVertical)
                        return true;
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == chest)
                        return true;
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == chestOpen)
                        return true;
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == store)
                        return true;
                }

            }

            if (rect.Intersects(this.collisionRects[rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)]))
            {
                for (int a = 0; a < layersArray.Length; a++)
                {
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == wood)
                        return true;
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == rock)
                        return true;
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == water)
                        return true;
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == fenceHorizontal)
                        return true;
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == fenceVertical)
                        return true;
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == chest)
                        return true;
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == chestOpen)
                        return true;
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == store)
                        return true;
                }
            }
            

            return false;
        }

        public string CollideWith(Rectangle rect)
        {
            try
            {
                if (rect.Intersects(this.collisionRects[rect.X / 32, rect.Y / 32]))
                {
                    for (int a = 0; a < layersArray.Length; a++)
                    {
                        if (this.layersArray[a][rect.X / 32, rect.Y / 32] == chest) // Check for Chest
                        {
                            this.layersArray[a][rect.X / 32, rect.Y / 32] = chestOpen;
                            return "chest";
                        }

                        else if (this.layersArray[a][rect.X / 32, rect.Y / 32] == store) // Check for store
                        {
                            return "store";
                        }

                        else if (this.layersArray[a][rect.X / 32, rect.Y / 32] == slime) // Check for Slime
                        {
                            return "slime";
                        }

                        else if (this.layersArray[a][rect.X / 32, rect.Y / 32] == wizard) // Check for Wizard
                        {
                            return "wizard";
                        }

                        else if (this.layersArray[a][rect.X / 32, rect.Y / 32] == necromancer) // Check for Necromancer
                        {
                            return "necromancer";
                        }

                        else if (this.layersArray[a][rect.X / 32, rect.Y / 32] == bird) // Check for bird
                        {
                            return "bird";
                        }

                        else if (this.layersArray[a][rect.X / 32, rect.Y / 32] == goblin) // Check for goblin
                        {
                            return "goblin";
                        }
                    }
                }

                if (rect.Intersects(this.collisionRects[rect.X / 32, rect.Y / 32 + (rect.Height / 32)]))
                {
                    for (int a = 0; a < layersArray.Length; a++)
                    {
                        if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == chest) // Check for Chest
                        {
                            this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] = chestOpen;
                            return "chest";
                        }

                        else if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == store) // Check for store
                        {
                            return "store";
                        }

                        else if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == slime) // Check for Slime
                        {
                            return "slime";
                        }

                        else if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == wizard) // Check for Wizard
                        {
                            return "wizard";
                        }

                        else if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == necromancer) // Check for Necromancer
                        {
                            return "necromancer";
                        }

                        else if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == bird) // Check for bird
                        {
                            return "bird";
                        }

                        else if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == goblin) // Check for goblin
                        {
                            return "goblin";
                        }
                    }
                }

                if (rect.Intersects(this.collisionRects[rect.X / 32 + (rect.Width / 32), rect.Y / 32]))
                {
                    for (int a = 0; a < layersArray.Length; a++)
                    {
                        if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == chest) // Check for Chest
                        {
                            this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] = chestOpen;
                            return "chest";
                        }

                        else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == store) // Check for store
                        {
                            return "store";
                        }

                        else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == slime) // Check for Slime
                        {
                            return "slime";
                        }

                        else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == wizard) // Check for Wizard
                        {
                            return "wizard";
                        }

                        else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == necromancer) // Check for Necromancer
                        {
                            return "necromancer";
                        }

                        else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == bird) // Check for bird
                        {
                            return "bird";
                        }

                        else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == goblin) // Check for goblin
                        {
                            return "goblin";
                        }
                    }
                }

                if (rect.Intersects(this.collisionRects[rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)]))
                {
                    for (int a = 0; a < layersArray.Length; a++)
                    {
                        if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == chest) // Check for Chest
                        {
                            this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] = chestOpen;
                            return "chest";
                        }

                        else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == store) // Check for store
                        {
                            return "store";
                        }

                        else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == slime) // Check for Slime
                        {
                            return "slime";
                        }

                        else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == wizard) // Check for Wizard
                        {
                            return "wizard";
                        }

                        else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == necromancer) // Check for Necromancer
                        {
                            return "necromancer";
                        }

                        else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == bird) // Check for bird
                        {
                            return "bird";
                        }

                        else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == goblin) // Check for goblin
                        {
                            return "goblin";
                        }
                    }
                }
            }

            catch { }


            return "";
        }

        public void EntityToBlank(Rectangle rect)
        {
            if (rect.Intersects(this.collisionRects[rect.X / 32, rect.Y / 32]))
            {
                for (int a = 0; a < layersArray.Length; a++)
                {

                    if (this.layersArray[a][rect.X / 32, rect.Y / 32] == slime) // Check for Slime
                    {
                        this.layersArray[a][rect.X / 32, rect.Y / 32] = blank;
                    }

                    else if (this.layersArray[a][rect.X / 32, rect.Y / 32] == wizard) // Check for Wizard
                    {
                        this.layersArray[a][rect.X / 32, rect.Y / 32] = blank;
                    }

                    else if (this.layersArray[a][rect.X / 32, rect.Y / 32] == necromancer) // Check for Necromancer
                    {
                        this.layersArray[a][rect.X / 32, rect.Y / 32] = blank;
                    }

                    else if (this.layersArray[a][rect.X / 32, rect.Y / 32] == bird) // Check for Bird
                    {
                        this.layersArray[a][rect.X / 32, rect.Y / 32] = blank;
                    }

                    else if (this.layersArray[a][rect.X / 32, rect.Y / 32] == goblin) // Check for Goblin
                    {
                        this.layersArray[a][rect.X / 32, rect.Y / 32] = blank;
                    }
                }
            }

            if (rect.Intersects(this.collisionRects[rect.X / 32, rect.Y / 32 + (rect.Height / 32)]))
            {
                for (int a = 0; a < layersArray.Length; a++)
                {

                    if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == slime) // Check for Slime
                    {
                        this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] = blank;
                    }

                    else if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == wizard) // Check for Wizard
                    {
                        this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] = blank;
                    }

                    else if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == necromancer) // Check for Necromancer
                    {
                        this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] = blank;
                    }

                    else if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == bird) // Check for bird
                    {
                        this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] = blank;
                    }

                    else if (this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] == goblin) // Check for goblin
                    {
                        this.layersArray[a][rect.X / 32, rect.Y / 32 + (rect.Height / 32)] = blank;
                    }
                }
            }

            if (rect.Intersects(this.collisionRects[rect.X / 32 + (rect.Width / 32), rect.Y / 32]))
            {
                for (int a = 0; a < layersArray.Length; a++)
                {
                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == slime) // Check for Slime
                    {
                        this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] = blank;
                    }

                    else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == wizard) // Check for Wizard
                    {
                        this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] = blank;
                    }

                    else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == necromancer) // Check for Necromancer
                    {
                        this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] = blank;
                    }

                    else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == bird) // Check for bird
                    {
                        this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] = blank;
                    }

                    else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] == goblin) // Check for goblin
                    {
                        this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32] = blank;
                    }
                }
            }

            if (rect.Intersects(this.collisionRects[rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)]))
            {
                for (int a = 0; a < layersArray.Length; a++)
                {

                    if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == slime) // Check for Slime
                    {
                        this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] = blank;
                    }

                    else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == wizard) // Check for Wizard
                    {
                        this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] = blank;
                    }

                    else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == necromancer) // Check for Necromancer
                    {
                        this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] = blank;
                    }

                    else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == bird) // Check for bird
                    {
                        this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] = blank;
                    }

                    else if (this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] == goblin) // Check for goblin
                    {
                        this.layersArray[a][rect.X / 32 + (rect.Width / 32), rect.Y / 32 + (rect.Height / 32)] = blank;
                    }
                }
            }

        }

    }
}
