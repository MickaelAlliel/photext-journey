using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using Photext_Journey.Core;
using Photext_Journey.Templates;
using Photext_Journey.Editor;
using Photext_Journey.GUI;
using Photext_Journey.Enemies;

namespace Photext_Journey
{
    public class Game : Microsoft.Xna.Framework.Game
    {

        #region Private Variables

        public enum MenuChoice
        {
            // ------- MAIN MENU ------- \\
            Play,
            Help,
            Editor,
            Exit,
            // ------- PAUSE MENU ------- \\
            Resume,
            Save,
            Load,
            Menu,
            // ------- BLANK MENU ------- \\
            Blank
        }

        public enum GameState
        {
            Menu,
            Pause,
            Playing,
            Inventory,
            Store,
            Fight,
            Dead,
            Help,
            Editor
        }

        public int XMAP
        {
            get { return this.xMap; }
            set { this.xMap = value; }
        }

        public int YMAP
        {
            get { return this.yMap; }
            set { this.yMap = value; }
        }

        // Core

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private MouseInput mouseInput;
        private KeyboardInput keyboardInput;

        private SaveLoad saveLoad;

        private GameTime gameTime;

        //END Core

        private EditorGUI editorGUI;
        private GameState gState;
        private Menu menu;
        private Pause pause;
        private SpriteFont basicFont, gameOverFont;
        private Level[,] levels;
        private int xMap, yMap, xMapBound, yMapBound;
        private Hero hero;
        private InventoryGUI heroInventory;
        private StoreGUI storeGUI;
        private Fight fight;


        private Texture2D bar;
        private Color opacity;

        #endregion

        public Game()
        {
            graphics = new GraphicsDeviceManager(this); // Creates the graphics manager
            graphics.PreferredBackBufferWidth = 1024; // Set screen WIDTH.
            graphics.PreferredBackBufferHeight = 704; // Set screen HEIGHT.
            graphics.IsFullScreen = false; // Set FullScreen YES/*NO*
            graphics.ApplyChanges(); // Apply graphics changes.
            
            this.IsMouseVisible = true; // Set mouse cursor to VISIBLE.

            //Current Version : 1.0
            Window.Title = "Photext Journey - v1.0";
            Window.AllowUserResizing = false;
            Content.RootDirectory = "Content"; // Set content main directory.
            TargetElapsedTime = new TimeSpan(0, 0, 0, 0, 16); // Sets the Game to constant 60 FPS.

        }

        protected override void Initialize()
        {
            #region Initialize Input and States

            this.mouseInput = new MouseInput(); // Initialize Mouse Input Constructor
            this.keyboardInput = new KeyboardInput(); // Initialize Keyboard Input Constructor
            this.gState = GameState.Menu; // Initialize first Game State.

            #endregion

            this.menu = new Menu(); // Create Main Menu.
            this.pause = new Pause(); // Create Pause Menu.

            this.opacity = new Color(255, 255, 255, 180);

            #region Initialize Levels

            this.levels = new Level[5,2];
            this.xMap = 0;
            this.xMapBound = this.levels.GetLength(0) - 1;
            this.yMap = 0;
            this.yMapBound = this.levels.GetLength(1) - 1;
            
            this.levels[0, 0] = new Level("Content/Levels/00.txt", "Loc : [0, 0]");
            this.levels[1, 0] = new Level("Content/Levels/10.txt", "Loc : [1, 0]");
            this.levels[2, 0] = new Level("Content/Levels/20.txt", "Loc : [2, 0]");
            this.levels[3, 0] = new Level("Content/Levels/30.txt", "Loc : [3, 0]");
            this.levels[4, 0] = new Level("Content/Levels/40.txt", "Loc : [4, 0]");

            this.levels[0, 1] = new Level("Content/Levels/01.txt", "Loc : [0, 1]");
            this.levels[1, 1] = new Level("Content/Levels/11.txt", "Loc : [1, 1]");
            this.levels[2, 1] = new Level("Content/Levels/21.txt", "Loc : [2, 1]");
            this.levels[3, 1] = new Level("Content/Levels/31.txt", "Loc : [3, 1]");
            this.levels[4, 1] = new Level("Content/Levels/41.txt", "Loc : [4, 1]");
            
            #endregion

            #region Initialize Hero

            this.hero = new Hero(Content);
            this.heroInventory = new InventoryGUI(this.hero);

            #endregion

            this.fight = new Fight(hero, new NullEnemy(Content));

            this.saveLoad = new SaveLoad(hero, xMap, yMap);

            base.Initialize(); // General Core Initialization

            Mouse.WindowHandle = Window.Handle; // Make Mouse position relative to game window
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.basicFont = Content.Load<SpriteFont>("Fonts/basicFont");
            this.gameOverFont = Content.Load<SpriteFont>("Fonts/gameOverFont");
            this.bar = Content.Load<Texture2D>("HUD/bar");

            this.heroInventory.LoadContent(Content);

            this.menu.LoadContent(Content);
            this.pause.LoadContent(Content);
            
            this.fight.LoadContent(Content);

            this.LoadLevels(Content);

            this.storeGUI = new StoreGUI(hero);
            this.storeGUI.LoadContent(Content);

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            this.gameTime = gameTime;

            this.gStateUpdate(); // Updates Game State / Menus
            this.mouseInput.Update(); // Update Mouse Location / Clicks
            this.keyboardInput.Update(); // Updates Keyboard Input
            base.Update(gameTime); // Update General Game Timer
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke); // Set General Background Color

            spriteBatch.Begin(SpriteBlendMode.AlphaBlend); // Call the spriteBatch

            // Draw States

            #region Draw Menus

            if (this.gState == GameState.Menu) // Main Menu
            {
                this.menu.Draw(spriteBatch);
            }

            else if (this.gState == GameState.Pause) // Pause Menu
            {
                this.levels[xMap, yMap].Draw(spriteBatch, hero); // Draw Levels
                this.pause.Draw(spriteBatch);
            }

            #endregion

            #region Draw Help

            else if (gState == GameState.Help)
            {
                spriteBatch.DrawString(gameOverFont, "H E L P", new Vector2(400, 50), Color.Black);

                spriteBatch.DrawString(basicFont, "You can load a game from the main menu or the pause menu in-game", new Vector2(25, 130), Color.Black);
                spriteBatch.DrawString(basicFont, "To exit the store press [ Escape ]", new Vector2(25, 160), Color.Black);
                spriteBatch.DrawString(basicFont, "To open the inventory press [ i ]", new Vector2(25, 190), Color.Black);
                spriteBatch.DrawString(basicFont, "To go back in a menu click [ Right Mouse Button ]", new Vector2(25, 220), Color.Black);
                spriteBatch.DrawString(basicFont, "To move Mike use the arrow keys", new Vector2(25, 250), Color.Black);
                spriteBatch.DrawString(basicFont, "Don't forget to restore Mike's health and mana using potions!", new Vector2(25, 310), Color.Black);
                spriteBatch.DrawString(basicFont, "When Mike's levels up, his health and mana fills up,", new Vector2(25, 340), Color.Black);
                spriteBatch.DrawString(basicFont, "And the game is saved automatically.", new Vector2(25, 370), Color.Black);

                spriteBatch.DrawString(basicFont, "  _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _", new Vector2(25, 540), Color.Black);

                spriteBatch.DrawString(basicFont, "| Programming : Michael Alliel                     |", new Vector2(25, 570), Color.Black);
                spriteBatch.DrawString(basicFont, "| Graphics : Internal / Internet Resources      |", new Vector2(25, 600), Color.Black);
                spriteBatch.DrawString(basicFont, "| Musics : Internet Resources                         |", new Vector2(25, 630), Color.Black);
                spriteBatch.DrawString(basicFont, "| Sound Effects : Internet Resources              |", new Vector2(25, 660), Color.Black);

                spriteBatch.DrawString(basicFont, "Return to main menu - [ Escape ]", new Vector2(710, 660), Color.Black);
            }

            #endregion

            #region Draw Playable

            else if (this.gState == GameState.Playing) // Playable
            {
                // Draw Levels
                this.levels[xMap, yMap].Draw(spriteBatch, hero);

                // Draw Hero's status bars
                spriteBatch.Draw(this.bar, new Rectangle(5, 35, 200, 23), opacity);
                //-------------------------------------------------------------
                spriteBatch.Draw(this.bar, new Rectangle(5, 35, (int)((float)this.hero.CurrentHealth / (float)this.hero.MaxHealth * 100.0) * 2, 10), Color.Red);
                spriteBatch.Draw(this.bar, new Rectangle(5, 45, 200, 3), Color.Black);
                spriteBatch.Draw(this.bar, new Rectangle(5, 48, (int)((float)this.hero.CurrentMana / (float)this.hero.MaxMana * 100.0) * 2, 10), Color.RoyalBlue);
            }

            #endregion

            #region Draw Inventory

            if (gState == GameState.Inventory)
            {
                // Draw Levels
                this.levels[xMap, yMap].Draw(spriteBatch, hero);

                // Draw Hero's status bars
                spriteBatch.Draw(this.bar, new Rectangle(5, 35, 200, 23), opacity);
                //-------------------------------------------------------------
                spriteBatch.Draw(this.bar, new Rectangle(5, 35, (int)((float)this.hero.CurrentHealth / (float)this.hero.MaxHealth * 100.0) * 2, 10), Color.Red);
                spriteBatch.Draw(this.bar, new Rectangle(5, 45, 200, 3), Color.Black);
                spriteBatch.Draw(this.bar, new Rectangle(5, 48, (int)((float)this.hero.CurrentMana / (float)this.hero.MaxMana * 100.0) * 2, 10), Color.RoyalBlue);

                //Draw Inventory
                this.heroInventory.Draw(spriteBatch);
            }

            #endregion

            #region Draw Store

            else if (gState == GameState.Store)
            {
                // Draw Levels
                this.levels[xMap, yMap].Draw(spriteBatch, hero);

                // Draw Hero's status bars
                spriteBatch.Draw(this.bar, new Rectangle(5, 35, 200, 23), opacity);
                //-------------------------------------------------------------
                spriteBatch.Draw(this.bar, new Rectangle(5, 35, (int)((float)this.hero.CurrentHealth / (float)this.hero.MaxHealth * 100.0) * 2, 10), Color.Red);
                spriteBatch.Draw(this.bar, new Rectangle(5, 45, 200, 3), Color.Black);
                spriteBatch.Draw(this.bar, new Rectangle(5, 48, (int)((float)this.hero.CurrentMana / (float)this.hero.MaxMana * 100.0) * 2, 10), Color.RoyalBlue);

                //Draw Store
                this.storeGUI.Draw(spriteBatch);
            }

            #endregion

            #region Draw Editor

            else if (this.gState == GameState.Editor) // Editor
            {
                this.editorGUI.Draw(spriteBatch);
            }

            #endregion

            #region Draw Fight

            else if (this.gState == GameState.Fight) // Fight
            {
                GraphicsDevice.Clear(Color.WhiteSmoke);
                this.fight.Draw(spriteBatch);
            }

            #endregion

            #region Draw Dead

            if (gState == GameState.Dead)
            {
                GraphicsDevice.Clear(Color.Black);
                spriteBatch.DrawString(gameOverFont, "G A M E       O V E R", new Vector2(210, 300), Color.Red);
                spriteBatch.DrawString(basicFont, "Press <escape> to return to the menu", new Vector2(340, 380), Color.Red);
            }

            #endregion

            // End Draw States
            
            spriteBatch.End(); // Release the spriteBatch

            base.Draw(gameTime);
        }

        private void gStateUpdate()
        {
            #region Menu State

            if (this.gState == GameState.Menu)
            {
                this.menu.Update(mouseInput); // Update Main Menu Option Highlight *IF* user is currently in MENU.


                if (menu.GetChoice() == MenuChoice.Play && mouseInput.IsLeftClicked() == true)
                {
                    gState = GameState.Playing;
                }
                else if (menu.GetChoice() == MenuChoice.Help && mouseInput.IsLeftClicked() == true)
                    gState = GameState.Help;
                else if (menu.GetChoice() == MenuChoice.Editor && mouseInput.IsLeftClicked() == true)
                {
                    this.editorGUI = new Editor.EditorGUI(32, 22, false);
                    this.editorGUI.LoadContent(Content);
                    gState = GameState.Editor;
                    this.editorGUI.Show();
                }
                else if (menu.GetChoice() == MenuChoice.Exit && mouseInput.IsLeftClicked() == true)
                    this.Exit();

                else if (menu.GetChoice() == MenuChoice.Load && mouseInput.IsLeftClicked() == true)
                {
                    this.saveLoad = new SaveLoad(hero, xMap, yMap);

                    this.saveLoad.LoadGame(this.hero, this, this.Content);
                }
            }

            #endregion

            #region Help State

            else if (gState == GameState.Help)
            {
                if (keyboardInput.Pressed(Keys.Escape))
                    gState = GameState.Menu;
            }
            #endregion

            #region Editor State

            else if (gState == GameState.Editor)
            {
                if (keyboardInput.Pressed(Keys.Escape))
                {
                    this.editorGUI.Close();
                    gState = GameState.Menu;
                }

                this.editorGUI.UpdateInput(mouseInput, keyboardInput);
            }

            #endregion

            #region Playing State

            else if (gState == GameState.Playing)
            {
                this.hero.Update(mouseInput, keyboardInput, levels[xMap, yMap], saveLoad, gameTime);
                this.hero.UpdateStats();
                this.Warp(this.hero);

                if (this.hero.isAlive == false)
                {
                    ReinitializeGame();
                    this.gState = GameState.Dead;
                }


                if (keyboardInput.Pressed(Keys.Escape))
                    gState = GameState.Pause;

                if (this.levels[xMap, yMap].CollideWith(this.hero.collisionRect) == "slime")
                {
                    this.fight.ResetFight(hero, new Slime(Content));
                    this.gState = GameState.Fight;
                }

                if (this.levels[xMap, yMap].CollideWith(this.hero.collisionRect) == "wizard")
                {
                    this.fight.ResetFight(hero, new Wizard(Content));
                    this.gState = GameState.Fight;
                }

                if (this.levels[xMap, yMap].CollideWith(this.hero.collisionRect) == "necromancer")
                {
                    this.fight.ResetFight(hero, new Necromancer(Content));
                    this.gState = GameState.Fight;
                }

                if (this.levels[xMap, yMap].CollideWith(this.hero.collisionRect) == "bird")
                {
                    this.fight.ResetFight(hero, new Bird(Content));
                    this.gState = GameState.Fight;
                }

                if (this.levels[xMap, yMap].CollideWith(this.hero.collisionRect) == "goblin")
                {
                    this.fight.ResetFight(hero, new Goblin(Content));
                    this.gState = GameState.Fight;
                }

                if (this.levels[xMap, yMap].CollideWith(this.hero.collisionRect) == "store")
                {
                    this.gState = GameState.Store;
                }

                if (keyboardInput.Pressed(Keys.I))
                {
                    gState = GameState.Inventory;
                }
            }

            #endregion

            #region Inventory State

            else if (gState == GameState.Inventory)
            {
                if (keyboardInput.Pressed(Keys.I))
                {
                    gState = GameState.Playing;
                }

                this.heroInventory.Update(mouseInput, keyboardInput);
                this.hero.UpdateStats();
            }

            #endregion

            #region Store State

            else if (gState == GameState.Store)
            {
                if (keyboardInput.Pressed(Keys.Escape))
                    gState = GameState.Playing;

                this.hero.UpdateStats();
                this.storeGUI.Update(mouseInput, keyboardInput);
            }

            #endregion

            #region Pause State

            else if (gState == GameState.Pause)
            {
                this.pause.Update(mouseInput); // Update Pause Menu Option Highlight *IF* user is currently in MENU.


                if (pause.GetChoice() == MenuChoice.Resume && mouseInput.IsLeftClicked() == true)
                    gState = GameState.Playing;
                else if (keyboardInput.Pressed(Keys.Escape))
                    gState = GameState.Playing;
                else if (pause.GetChoice() == MenuChoice.Save && mouseInput.IsLeftClicked() == true)
                {
                    this.saveLoad = new SaveLoad(hero, xMap, yMap);

                    this.saveLoad.SaveGame();
                }
                else if (pause.GetChoice() == MenuChoice.Load && mouseInput.IsLeftClicked() == true)
                {
                    this.saveLoad = new SaveLoad(hero, xMap, yMap);

                    this.saveLoad.LoadGame(this.hero, this, this.Content);
                }
                else if (pause.GetChoice() == MenuChoice.Menu && mouseInput.IsLeftClicked() == true)
                    gState = GameState.Menu;
            }

            #endregion

            #region Dead State

            else if (gState == GameState.Dead)
            {
                if (keyboardInput.Pressed(Keys.Escape))
                {
                    gState = GameState.Menu;
                }
            }

            #endregion

            #region Fight State

            else if (gState == GameState.Fight)
            {
                this.fight.Update(gameTime, mouseInput, keyboardInput);

                if (this.fight.CheckFinished() == true)
                {
                    this.levels[xMap, yMap].EntityToBlank(hero.collisionRect);

                    this.gState = GameState.Playing;
                }
            }

            #endregion
        }

        private void Warp(Hero hero)
        {
            if (hero.Warping() == "up")
            {
                if (yMap >= 1 && yMap <= yMapBound)
                {
                    yMap--;
                    hero.pos.Y = graphics.PreferredBackBufferHeight - hero.texture.Height;

                    //-----RELOAD LEVEL-----
                    this.levels[xMap, yMap].LoadLevel();
                }

                if (yMap == 0 && hero.Warping() == "up")
                {
                    hero.canMove = false;
                    hero.pos.Y = 0;
                }
            }
            else if (hero.Warping() == "down")
            {
                if (yMap >= 0 && yMap < yMapBound)
                {
                    yMap++;
                    hero.pos.Y = 0;

                    //-----RELOAD LEVEL-----
                    this.levels[xMap, yMap].LoadLevel();
                }

                if (yMap == yMapBound && hero.Warping() == "down")
                {
                    hero.canMove = false;
                    hero.pos.Y = graphics.PreferredBackBufferHeight - hero.texture.Height;
                }
            }
            else if (hero.Warping() == "left")
            {
                if (xMap >= 1 && xMap <= xMapBound)
                {
                    xMap--;
                    hero.pos.X = graphics.PreferredBackBufferWidth - hero.texture.Width;

                    //-----RELOAD LEVEL-----
                    this.levels[xMap, yMap].LoadLevel();
                }

                if (xMap == 0 && hero.Warping() == "left")
                {
                    hero.canMove = false;
                    hero.pos.X = 0;
                }
            }
            else if (hero.Warping() == "right")
            {
                if (xMap >= 0 && xMap < xMapBound)
                {
                    xMap++;
                    hero.pos.X = 0;

                    //-----RELOAD LEVEL-----
                    this.levels[xMap, yMap].LoadLevel();
                }

                if (xMap == xMapBound && hero.Warping() == "right")
                {
                    hero.canMove = false;
                    hero.pos.X = graphics.PreferredBackBufferWidth - hero.texture.Width;
                }
            }            
        }

        private void LoadLevels(ContentManager Content)
        {
            
            this.levels[0, 0].LoadContent(Content);
            this.levels[0, 0].LoadLevel();
            
            this.levels[1, 0].LoadContent(Content);
            this.levels[1, 0].LoadLevel();
            
            this.levels[2, 0].LoadContent(Content);
            this.levels[2, 0].LoadLevel();

            this.levels[3, 0].LoadContent(Content);
            this.levels[3, 0].LoadLevel();
            
            this.levels[4, 0].LoadContent(Content);
            this.levels[4, 0].LoadLevel();
            //----------------------------------------
            this.levels[0, 1].LoadContent(Content);
            this.levels[0, 1].LoadLevel();

            this.levels[1, 1].LoadContent(Content);
            this.levels[1, 1].LoadLevel();
            
            this.levels[2, 1].LoadContent(Content);
            this.levels[2, 1].LoadLevel();

            this.levels[3, 1].LoadContent(Content);
            this.levels[3, 1].LoadLevel();

            this.levels[4, 1].LoadContent(Content);
            this.levels[4, 1].LoadLevel();
           

        }

        private void ReinitializeGame()
        {
            this.hero = new Hero(Content);
            this.heroInventory = new InventoryGUI(this.hero);

            this.xMap = 0;
            this.yMap = 0;
        }
    }
}
