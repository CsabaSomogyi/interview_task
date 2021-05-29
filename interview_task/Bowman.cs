using System;
using System.Collections.Generic;
using System.Text;

namespace interview_task
{
    class Bowman : Warrior
    {
        const int maxStamina = 100;

        public override int MaxStamina => maxStamina;

        public override void Defense(WarriorType attackerWarriorType)
        {
            //Védekező meghall
            Stamina = 0;
        }



        public Bowman() : base()
        {
            Stamina = maxStamina;
            WarriorType = WarriorType.Bowman;
        }

    }
}
