using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Photext_Journey.Templates;

namespace Photext_Journey.Spells
{
    class SelfCure : Spell
    {
        public SelfCure()
        {
            base.ID = "Self Cure";

            base.isHeal = true;

            base.power = 84;
            base.ratio = 0.7;
            base.manaCost = 29;
            base.powerPerLvl = 22;
        }
    }
}
