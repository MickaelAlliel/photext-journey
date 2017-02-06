using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photext_Journey.Templates;

namespace Photext_Journey.Spells
{
    class ArcaneShock : Spell
    {
        public ArcaneShock()
        {
            base.ID = "Arcane Shock";

            base.isDamage = true;


            base.manaCost = 35;
            base.ratio = 0.63;
            base.power = 72;
            base.powerPerLvl = 11;
        }
    }
}
