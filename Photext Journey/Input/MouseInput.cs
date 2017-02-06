using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Photext_Journey
{
    public class MouseInput
    {
        private MouseState mouseState, newMouseState;
        private Vector2 pos;

        public MouseInput()
        {
            this.mouseState = new MouseState();
            this.newMouseState = new MouseState();
            this.pos = new Vector2();
            
        }

        public void Update()
        {
            this.pos.X = mouseState.X;
            this.pos.Y = mouseState.Y;

            this.mouseState = this.newMouseState;
            this.newMouseState = Mouse.GetState();
        }

        public bool IsLeftClicked()
        {
            if (this.mouseState.LeftButton == ButtonState.Released && this.newMouseState.LeftButton == ButtonState.Pressed)
                return true;
            return false;
        }

        public bool IsLeftHeld()
        {
            if (this.mouseState.LeftButton == ButtonState.Pressed)
                return true;
            return false;
        }

        public bool IsMidClicked()
        {
            if (this.mouseState.MiddleButton == ButtonState.Released && this.newMouseState.MiddleButton == ButtonState.Pressed)
                return true;
            return false;
        }

        public bool IsMidHeld()
        {
            if (this.mouseState.MiddleButton == ButtonState.Pressed)
                return true;
            return false;
        }

        public bool IsMidReleased()
        {
            if (this.mouseState.MiddleButton == ButtonState.Released)
                return true;
            return false;
        }

        public bool IsRightClicked()
        {
            if (this.mouseState.RightButton == ButtonState.Released && this.newMouseState.RightButton == ButtonState.Pressed)
                return true;
            return false;
        }

        public bool IsRightHeld()
        {
            if (this.mouseState.RightButton == ButtonState.Pressed)
                return true;
            return false;
        }

        public Vector2 Pos
        {
            get { return this.pos; }
            set { this.pos = value; }
        }
    }
}
