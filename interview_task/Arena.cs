using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace interview_task
{
    class Arena
    {
        List<Warrior> warriors = new List<Warrior>();

        /// <summary>
        /// Véletlenszerű harcosokkal feltölti a csatateret
        /// </summary>
        /// <param name="numberOfWarriors">Hány darab harcos legyen</param>
        public Arena(int numberOfWarriors)
        {
            if (numberOfWarriors < 2) throw new Exception("Legalább 2 harcosnak kell lennie");
            for (int i = 0; i < numberOfWarriors; i++)
            {
                int randomNumber = CreateRandomNumber.RNG.Next(3);
                if (randomNumber == 0)
                    warriors.Add(new Bowman());
                else if (randomNumber == 1)
                    warriors.Add(new Knight());
                else
                    warriors.Add(new Halberdier());
            }
            Battle();
        }

        void Battle()
        {
            int battleRound = 1;
            do
            {
                int attacker = CreateRandomNumber.RNG.Next(warriors.Count);
                int defender;
                do
                {
                    defender = CreateRandomNumber.RNG.Next(warriors.Count);
                } while (attacker == defender);

                foreach (var warior in warriors)
                {
                    Console.WriteLine("Az {3}. körben lévő harcosok {0} : {1} : {2} : {4}", warior.Id, warior.Stamina, warior.Name, battleRound, warior.WarriorType);
                }

                Console.WriteLine("{4}. Körben {0} : {1} : {5} megtámadja {2} : {3} : {6} védőt", warriors[attacker].Name, warriors[attacker].Stamina, warriors[defender].Name, warriors[defender].Stamina, battleRound, warriors[attacker].WarriorType, warriors[defender].WarriorType);

                Attack(warriors[attacker], warriors[defender].WarriorType);
                Defense(warriors[defender], warriors[attacker].WarriorType);

                Console.WriteLine("{4}. köben harcoló felek állapota támadó {0} : {1} védő {2} : {3}", warriors[attacker].Name, warriors[attacker].Stamina, warriors[defender].Name, warriors[defender].Stamina, battleRound);


                warriors.Where(x => x.Id != warriors[attacker].Id && x.Id != warriors[defender].Id).Select(a => a.Stamina += 20);

                warriors.RemoveAll(x => x.Stamina == 0);

                Console.WriteLine("------------ {0} kör vége ----------", battleRound);
                battleRound++;

            } while (warriors.Count > 1);

            if (warriors.Count() == 1)
                Console.WriteLine("Győztes {0}", warriors[0].Name);
            else
                Console.WriteLine("Nincs győztes!");
        }

        void Attack(Warrior warrior, WarriorType warriorType)
        {
            warrior.StaminaHalf();
            warrior.Attack(warriorType);
            warrior.ExhaustedWarriorKill();
        }
        void Defense(Warrior warrior, WarriorType warriorType)
        {
            warrior.StaminaHalf();
            warrior.Defense(warriorType);
            warrior.ExhaustedWarriorKill();
        }

    }
}
