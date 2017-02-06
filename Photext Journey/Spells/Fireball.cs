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
    class Fireball : Spell
    {
        public Fireball()
        {
            base.ID = "Fireball";

            //base.fire = true;
            base.isDamage = true;


            base.manaCost = 27;
            base.ratio = 0.85;
            base.power = 46;
            base.powerPerLvl = 9;
        }

    }
}
