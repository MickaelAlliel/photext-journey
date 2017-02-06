using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photext_Journey.Templates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Photext_Journey.Core;

namespace Photext_Journey.Enemies
{
    class NullEnemy : Entity
    {
        public NullEnemy(ContentManager Content)
        {
            base.ID = "";
        }

        public override string AI()
        {
            this.rand = new Random();

            this.AIChoice = "";

            return base.AI();
        }
    }
}
