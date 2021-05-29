using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_task
{
    class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena(6);
        }
    }


    public enum WarriorType
    {
        Bowman, Knight, Halberdier
    }
    public class CreateRandomNumber
    {
        public static Random RNG = new Random();
    }
    interface IWarriorAbility
    {
        void Attack(WarriorType defenderWarriorType);
        void Defense(WarriorType attackerWarriorType);
    }
}
