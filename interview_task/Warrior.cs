using System;
using System.Collections.Generic;
using System.Text;

namespace interview_task
{
    abstract class Warrior : IWarriorAbility
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public WarriorType WarriorType { get; set; }
        int stamina;
        // Életerő nem lehet nagyobb mint a maximális életerő
        public int Stamina
        {
            get => stamina; set
            {
                stamina = value > MaxStamina ? MaxStamina : value;
            }
        }

        public void ExhaustedWarriorKill()
        {
            if (Stamina <= MaxStamina * 0.25 && Stamina != 0)
                Stamina = 0;
        }
        public abstract int MaxStamina { get; }

        public virtual void Attack(WarriorType defenderWarriorType)
        {
            //Támadó nem sérül
        }

        public void StaminaHalf()
        {
            Stamina /= 2;
        }

        public abstract void Defense(WarriorType attackerWarriorType);

        protected Warrior()
        {
            Id = Guid.NewGuid();
            Name = CreateRandomName();
        }

        string CreateRandomName()
        {
            string[] firstName = new string[] { "Balázs", "Ádám", "Anna", "Hanna", "Viktor", "Éva", "Panna", "Bea", "Attila", "Örs", "Erik" };
            string[] lastName = new string[] { "Kiss", "Nagy", "Papp", "Tóth", "Farkas", "Szabó", "Varga", "Kovács", "Balatoni", "Nyíri" };

            return firstName[CreateRandomNumber.RNG.Next(10)] + " " + lastName[CreateRandomNumber.RNG.Next(10)];
        }
    }
}
