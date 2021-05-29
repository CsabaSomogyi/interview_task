using System;
using System.Collections.Generic;
using System.Text;

namespace interview_task
{
    class Knight : Warrior
    {
        const int maxStamina = 80;
        public override int MaxStamina => maxStamina;

        public Knight() : base()
        {
            Stamina = maxStamina;
            WarriorType = WarriorType.Knight;
        }

        public override void Attack(WarriorType defenderWarriorType)
        {
            switch (defenderWarriorType)
            {
                case WarriorType.Bowman:
                    break;
                case WarriorType.Knight:
                    break;
                case WarriorType.Halberdier:
                    Stamina = 0;
                    break;
            }
        }
        public override void Defense(WarriorType attackerWarriorType)
        {
            switch (attackerWarriorType)
            {
                case WarriorType.Bowman:
                    //védekező 50%-ban meghal
                    if (CreateRandomNumber.RNG.Next(100) < 50)
                        Stamina = 0;
                    break;
                case WarriorType.Knight:
                    Stamina = 0;
                    break;
                case WarriorType.Halberdier:
                    break;
            }
        }
    }
}
