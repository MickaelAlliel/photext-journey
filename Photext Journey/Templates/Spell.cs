using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Photext_Journey.Templates
{
    class Spell
    {
        public int power;
        public int powerPerLvl;
        public double stealRatio;
        public int manaCost;
        public double ratio;
        public bool isHeal, isDamage, lifeSteal;//These are to determine how to use the spell
        public string ID;

        public Spell()
        {
            isHeal = false;
            isDamage = false;
            lifeSteal = false;

            power = 0;
            manaCost = 0;
            ratio = 0.0;
            stealRatio = 0.0;
            powerPerLvl = 0;

            ID = "";
        }
    }
}
