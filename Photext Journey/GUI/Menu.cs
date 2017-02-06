using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Photext_Journey
{
    class Menu : Game
    {
        private Texture2D background;

        private MenuChoice menuChoice;
        private Rectangle playRect, loadRect, helpRect, editorRect, exitRect;

        private Texture2D button_Play, button_Load, button_Help, button_Editor, button_Exit;
        private Texture2D button_Highlight_Play, button_Highlight_Load, button_Highlight_Help, button_Highlight_Editor, button_Highlight_Exit;

        public Menu()
        {
            this.menuChoice = MenuChoice.Blank;
        }

        public void LoadContent(ContentManager Content)
        {
            this.background = Content.Load<Texture2D>("Backgrounds/menu_background");


            this.button_Play = Content.Load<Texture2D>("Buttons/Menus/button_Play");
            this.button_Load = Content.Load<Texture2D>("Buttons/Menus/button_Load");
            this.button_Help = Content.Load<Texture2D>("Buttons/Menus/button_Help");
            this.button_Editor = Content.Load<Texture2D>("Buttons/Menus/button_Editor");
            this.button_Exit = Content.Load<Texture2D>("Buttons/Menus/button_Exit");

            this.button_Highlight_Play = Content.Load<Texture2D>("Buttons/Menus/button_Highlight_PlayT");
            this.button_Highlight_Load = Content.Load<Texture2D>("Buttons/Menus/button_Highlight_LoadT");
            this.button_Highlight_Help = Content.Load<Texture2D>("Buttons/Menus/button_Highlight_HelpT");
            this.button_Highlight_Editor = Content.Load<Texture2D>("Buttons/Menus/button_Highlight_EditorT");
            this.button_Highlight_Exit = Content.Load<Texture2D>("Buttons/Menus/button_Highlight_ExitT");

            this.playRect.X = (1024 / 2) - (this.button_Play.Width / 2);
            this.playRect.Y = 200;
            this.playRect.Width = this.button_Play.Width;
            this.playRect.Height = this.button_Play.Height;

            this.loadRect.X = (1024 / 2) - (this.button_Load.Width / 2);
            this.loadRect.Y = 270;
            this.loadRect.Width = this.button_Load.Width;
            this.loadRect.Height = this.button_Load.Height;

            this.helpRect.X = (1024 / 2) - (this.button_Help.Width / 2);
            this.helpRect.Y = 340;
            this.helpRect.Width = this.button_Help.Width;
            this.helpRect.Height = this.button_Help.Height;

            this.editorRect.X = (1024 / 2) - (this.button_Editor.Width / 2);
            this.editorRect.Y = 410;
            this.editorRect.Width = this.button_Editor.Width;
            this.editorRect.Height = this.button_Editor.Height;

            this.exitRect.X = (1024 / 2) - (this.button_Exit.Width / 2);
            this.exitRect.Y = 480;
            this.exitRect.Width = this.button_Exit.Width;
            this.exitRect.Height = this.button_Exit.Height;
        }

        public void Update(MouseInput mouseInput)
        {
            if (playRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                menuChoice = MenuChoice.Play;
            else if (loadRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                menuChoice = MenuChoice.Load;
            else if (helpRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                menuChoice = MenuChoice.Help;
            else if (editorRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                menuChoice = MenuChoice.Editor;
            else if (exitRect.Contains((int)mouseInput.Pos.X, (int)mouseInput.Pos.Y))
                menuChoice = MenuChoice.Exit;
            else
                menuChoice = MenuChoice.Blank;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(this.background, new Vector2(0, 0), Color.White);

            if (menuChoice == MenuChoice.Play)
                sb.Draw(this.button_Highlight_Play, this.playRect, Color.White);
            else
                sb.Draw(this.button_Play, this.playRect, Color.White);

            if (menuChoice == MenuChoice.Load)
                sb.Draw(this.button_Highlight_Load, this.loadRect, Color.White);
            else
                sb.Draw(this.button_Load, this.loadRect, Color.White);

            if (menuChoice == MenuChoice.Help)
                sb.Draw(this.button_Highlight_Help, this.helpRect, Color.White);
            else
                sb.Draw(this.button_Help, this.helpRect, Color.White);

            if (menuChoice == MenuChoice.Editor)
                sb.Draw(this.button_Highlight_Editor, this.editorRect, Color.White);
            else
                sb.Draw(this.button_Editor, this.editorRect, Color.White);

            if (menuChoice == MenuChoice.Exit)
                sb.Draw(this.button_Highlight_Exit, this.exitRect, Color.White);
            else
                sb.Draw(this.button_Exit, this.exitRect, Color.White);
        }

        public MenuChoice GetChoice()
        {
            return this.menuChoice;
        }

    }
}
