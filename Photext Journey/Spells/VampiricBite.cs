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
    class VampiricBite : Spell
    {
        public VampiricBite()
        {
            base.ID = "Vampiric Bite";

            base.lifeSteal = true;


            base.manaCost = 0;
            base.ratio = 0.35;
            base.power = 68;
            base.stealRatio = 0.10;
            base.powerPerLvl = 12;
        }

    }
}
