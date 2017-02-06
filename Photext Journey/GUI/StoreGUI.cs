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
    class StoreGUI
    {
        private ContentManager Content;

        private Texture2D backgroundTransparent, backgroundTexture;
        private Rectangle backgroundRectangle;

        private Texture2D buttonUp, buttonDown, buttonUpHighlight, buttonDownHighlight;
        private Rectangle rectUp, rectDown;

        private string buttonHover;

        private SpriteFont storeFont;
        private Color opacity;
        private int page;

        private List<Item> storeList;
        private Rectangle[] itemPlace;
        private Hero hero;


        public StoreGUI(Hero hero)
        {
            this.page = 1;
            this.buttonHover = "";

            this.opacity = new Color(255, 255, 255, 180);
            this.hero = hero;

            this.storeList = new List<Item>();
            this.itemPlace = new Rectangle[5];

            for (int i = 0; i < itemPlace.Length; i++)
                itemPlace[i] = new Rectangle(300, 200 + i * 50, 50, 50);
             
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = Content;

            this.buttonUp = Content.Load<Texture2D>("Buttons/Store/button_Up");
            this.buttonDown = Content.Load<Texture2D>("Buttons/Store/button_Down");
            this.buttonUpHighlight = Content.Load<Texture2D>("Buttons/Store/button_Highlight_Up");
            this.buttonDownHighlight = Content.Load<Texture2D>("Buttons/Store/button_Highlight_Down");

            this.rectUp = new Rectangle(650, 250, buttonUp.Width, buttonUp.Height);
            this.rectDown = new Rectangle(650, 330, buttonDown.Width, buttonDown.Height);

            this.backgroundTransparent = Content.Load<Texture2D>("Backgrounds/pause_background");
            this.backgroundTexture = Content.Load<Texture2D>("HUD/bar");
            this.backgroundRectangle = new Rectangle(200, 200, 400, 400);

            this.storeFont = Content.Load<SpriteFont>("Fonts/hudFont");

            
                this.storeList.Add(new Items.BothPotion(Content));
                this.storeList.Add(new Items.HealthPotion(Content));
                this.storeList.Add(new Items.ManaPotion(Content));


                this.storeList.Add(new Items.GoblinAxe(Content));
                this.storeList.Add(new Items.GoblinHelm(Content));
                this.storeList.Add(new Items.GoblinChest(Content));
                this.storeList.Add(new Items.GoblinLegs(Content));
                this.storeList.Add(new Items.GoblinFeets(Content));

                for (int i = 8; i <= 15; i++)
                {
                    this.storeList.Add(new Items.NullItem(Content));
                }
            
        }

        public void Update(MouseInput mouseInput, KeyboardInput keyboardInput)
        {
            if (rectUp.Contains((int)(mouseInput.Pos.X), (int)(mouseInput.Pos.Y)))
            {
                buttonHover = "up";

                if (mouseInput.IsLeftClicked())
                    page--;
            }
            else if (rectDown.Contains((int)(mouseInput.Pos.X), (int)(mouseInput.Pos.Y)))
            {
                buttonHover = "down";

                if (mouseInput.IsLeftClicked())
                    page++;
            }
            else
                buttonHover = "";



            for (int i = 1; i <= itemPlace.Length; i++)
            {
                if (itemPlace[i - 1].Contains((int)(mouseInput.Pos.X), (int)(mouseInput.Pos.Y)) && mouseInput.IsLeftClicked())
                {
                    if (page == 1)
                        hero.BuyItem(storeList.ElementAt(i));
                    else if (page == 2)
                        hero.BuyItem(storeList.ElementAt(5 + i));
                    else if (page == 3)
                        hero.BuyItem(storeList.ElementAt(10 + i));
                }
            }

            if (page < 1)
                page = 1;
            else if (page > 3)
                page = 3;

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(backgroundTransparent, new Vector2(0, 0), this.opacity);


            #region Buttons

            if (buttonHover == "up")
                sb.Draw(buttonUpHighlight, rectUp, Color.White);
            else
                sb.Draw(buttonUp, rectUp, Color.White);
            if (buttonHover == "down")
                sb.Draw(buttonDownHighlight, rectDown, Color.White);
            else
                sb.Draw(buttonDown, rectDown, Color.White);

            #endregion

            #region Items

            for (int i = 1; i <= itemPlace.Length; i++)
            {
                if (page == 1)
                {
                    sb.Draw(storeList.ElementAt(i).Texture, itemPlace[i-1], Color.White);
                    sb.DrawString(storeFont, storeList.ElementAt(i).ID, new Vector2(itemPlace[i-1].X + 110, itemPlace[i-1].Y + 15), Color.White);
                    sb.DrawString(storeFont, storeList.ElementAt(i).Gold.ToString(), new Vector2(itemPlace[i-1].X + 60, itemPlace[i-1].Y + 15), Color.Yellow);
                }
                else if (page == 2)
                {
                    sb.Draw(storeList.ElementAt(5 + i).Texture, itemPlace[i-1], Color.White);
                    sb.DrawString(storeFont, storeList.ElementAt(5 + i).ID, new Vector2(itemPlace[i - 1].X + 110, itemPlace[i - 1].Y + 15), Color.White);
                    sb.DrawString(storeFont, storeList.ElementAt(5 + i).Gold.ToString(), new Vector2(itemPlace[i - 1].X + 60, itemPlace[i - 1].Y + 15), Color.Yellow);
                }
                else if (page == 3)
                {
                    sb.Draw(storeList.ElementAt(10 + i).Texture, itemPlace[i - 1], Color.White);
                    sb.DrawString(storeFont, storeList.ElementAt(10 + i).ID, new Vector2(itemPlace[i - 1].X + 110, itemPlace[i - 1].Y + 15), Color.White);
                    sb.DrawString(storeFont, storeList.ElementAt(10 + i).Gold.ToString(), new Vector2(itemPlace[i - 1].X + 60, itemPlace[i - 1].Y + 15), Color.Yellow);
                }
            }

            #endregion


            sb.DrawString(storeFont, "Gold: " + hero.Gold, new Vector2(300, 170), Color.White);
        }

    }
}
