using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Photext_Journey
{
    public class KeyboardInput
    {
        private KeyboardState kbState, newKbState;

        public KeyboardInput()
        {
            this.kbState = new KeyboardState();
            this.newKbState = new KeyboardState();
        }

        public void Update()
        {
            this.kbState = this.newKbState;
            this.newKbState = Keyboard.GetState();
        }

        public bool Pressed(Keys key)
        {
            if (kbState.IsKeyDown(key) == true && newKbState.IsKeyUp(key) == true)
                return true;
            return false;
        }

        public bool PressedOnce(Keys key)
        {
            if (kbState.IsKeyUp(key) == true && newKbState.IsKeyDown(key) == true)
                return true;
            return false;
        }

        public bool IsHeld(Keys key)
        {
            if (kbState.IsKeyDown(key) == true)
                return true;
            return false;
        }

        public bool Released(Keys key)
        {
            if (kbState.IsKeyUp(key) == true)
                return true;
            return false;
        }

    }
}
