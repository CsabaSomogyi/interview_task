using System;
using System.Collections.Generic;
using System.Text;

namespace interview_task
{
    class Halberdier : Warrior
    {
        const int maxStamina = 90;
        public override int MaxStamina => maxStamina;

        public Halberdier() : base()
        {
            Stamina = maxStamina;
            WarriorType = WarriorType.Halberdier;
        }

        public override void Defense(WarriorType attackerWarriorType)
        {
            switch (attackerWarriorType)
            {
                case WarriorType.Bowman:
                    Stamina = 0;
                    break;
                case WarriorType.Knight:
                    break;
                case WarriorType.Halberdier:
                    Stamina = 0;
                    break;
            }
        }
    }

}
