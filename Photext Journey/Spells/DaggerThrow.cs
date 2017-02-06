using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photext_Journey.Templates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Photext_Journey.Spells
{
    class DaggerThrow : Spell
    {
        public DaggerThrow()
        {
            base.ID = "Dagger Throw";
            base.isDamage = true;

            base.manaCost = 75;
            base.ratio = 0.25;
            base.power = 162;
            base.powerPerLvl = 13;
        }

    }
}
