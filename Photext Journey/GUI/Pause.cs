using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Photext_Journey.GUI
{
    class Pause : Game
    {
        private Texture2D background, PAUSE;
        private Color opacity;

        private MenuChoice menuChoice;
        private Rectangle resumeRect, saveRect, loadRect, menuRect;

        private Texture2D button_Resume, button_Save, button_Load, button_Menu;
        private Texture2D button_Highlight_Resume, button_Highlight_Save, button_Highlight_Load, button_Highlight_Menu;

        public Pause()
        {
            this.menuChoice = MenuChoice.Blank;
        }

        public void LoadContent(ContentManager Content)
        {
            this.PAUSE = Content.Load<Texture2D>("Backgrounds/PAUSE");
            this.background = Content.Load<Texture2D>("Backgrounds/pause_background");
            this.opacity = new Color(255, 255, 255, 180);

            this.button_Resume = Content.Load<Texture2D>("Buttons/Menus/button_Resume");
            this.button_Save = Content.Load<Texture2D>("Buttons/Menus/button_Save");
            this.button_Load = Content.Load<Texture2D>("Buttons/Menus/button_Load");
            this.button_Menu = Content.Load<Texture2D>("Buttons/Menus/button_Menu");

            this.button_Highlight_Resume = Content.Load<Texture2D>("Buttons/Menus/button_Highlight_ResumeT");
            this.button_Highlight_Save = Content.Load<Texture2D>("Buttons/Menus/button_Highlight_SaveT");
            this.button_Highlight_Load = Content.Load<Texture2D>("Buttons/Menus/button_Highlight_LoadT");
            this.button_Highlight_Menu = Content.Load<Texture2D>("Buttons/Menus/button_Highlight_MenuT");

            this.resumeRect.X = (1024 / 2) - (this.button_Resume.Width / 2);
            this.resumeRect.Y = 200;
            this.resumeRect.Width = this.button_Resume.Width;
            this.resumeRect.Height = this.button_Resume.Height;

            this.saveRect.X = (1024 / 2) - (this.button_Save.Width / 2);
            this.saveRect.Y = 270;
            this.saveRect.Width = this.button_Save.Width;
            this.saveRect.Height = this.button_Save.Height;

            this.loadRect.X = (1024 / 2) - (this.button_Load.Width / 2);
            this.loadRect.Y = 340;
            this.loadRect.Width = this.button_Load.Width;
            this.loadRect.Height = this.button_Load.Height;

            this.menuRect.X = (1024 / 2) - (this.button_Menu.Width / 2);
            this.menuRect.Y = 410;
            this.menuRect.Width = this.button_Menu.Width;
            this.menuRect.Height = this.button_Menu.Height;
        }

        public void Update(MouseInput mouseInput)
        {
            if (resumeRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                menuChoice = MenuChoice.Resume;
            else if (saveRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                menuChoice = MenuChoice.Save;
            else if (loadRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                menuChoice = MenuChoice.Load;
            else if (menuRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                menuChoice = MenuChoice.Menu;
            else
                menuChoice = MenuChoice.Blank;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(this.background, new Vector2(0, 0), opacity);
            sb.Draw(this.PAUSE, new Vector2(270, 50), Color.White);

            if (menuChoice == MenuChoice.Resume)
                sb.Draw(this.button_Highlight_Resume, this.resumeRect, Color.White);
            else
                sb.Draw(this.button_Resume, this.resumeRect, Color.White);

            if (menuChoice == MenuChoice.Save)
                sb.Draw(this.button_Highlight_Save, this.saveRect, Color.White);
            else
                sb.Draw(this.button_Save, this.saveRect, Color.White);

            if (menuChoice == MenuChoice.Load)
                sb.Draw(this.button_Highlight_Load, this.loadRect, Color.White);
            else
                sb.Draw(this.button_Load, this.loadRect, Color.White);

            if (menuChoice == MenuChoice.Menu)
                sb.Draw(this.button_Highlight_Menu, this.menuRect, Color.White);
            else
                sb.Draw(this.button_Menu, this.menuRect, Color.White);
        }

        public MenuChoice GetChoice()
        {
            return this.menuChoice;
        }

    }
}
