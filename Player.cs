using System;


namespace Classes101
{
    internal class Player
    {
        public string playerName;
        private int AttackAttribute = 25;
        private int playerHealth = 50;
        private int playerArmor = 0;
        private int MAX_PLAYER_HEALTH = 100;
        private int MAX_PLAYER_ARMOR = 100;


        public Player(string name)
        {
            this.playerName = name;
        }
        public void ShowName() {
            Console.WriteLine("Player: {0}", playerName.ToUpper());
        }
        public void ShowHealth() {
            int[] byTen = {5,10,15,20,25,30,35,40,45,50,55,60,65,70,75,80,85,90,95,100};
            Console.Write("Health: ");
            for (int i = 1;i <= playerHealth;i++) {
                if (byTen.Contains(i))
                {
                    Console.Write("|");
                }
            }
            for (int i = playerHealth; i <= MAX_PLAYER_HEALTH; i++) {
                if (byTen.Contains(i))  {
                    if (i == MAX_PLAYER_HEALTH) {
                        Console.Write("]");
                    }
                    else {
                    Console.Write("_");
                    }
                }
            }
            Console.Write(" ({0}/{1})", playerHealth, MAX_PLAYER_HEALTH);
            Console.WriteLine();
        }
        public void ShowArmor()
        {
            int[] byFive = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };
            Console.Write("Armor:  ");
            for (int i = 1; i <= playerArmor; i++)
            {
                if (byFive.Contains(i))
                {
                    Console.Write("|");
                }
            }
            for (int i = playerArmor; i <= MAX_PLAYER_ARMOR; i++)
            {
                if (byFive.Contains(i)) {
                    if (i == MAX_PLAYER_HEALTH)
                    {
                        Console.Write("]");
                    }
                    else {
                        Console.Write("_");
                    }
                }
            }
            Console.Write(" ({0}/{1})", playerArmor, MAX_PLAYER_ARMOR);
            Console.WriteLine();
        }


        public void Attack(EnemiesFactory targetHorde, int preciseTarget)
        {
            targetHorde.enemyStorage[preciseTarget].DamageHealth(AttackAttribute);
            if (targetHorde.enemyStorage[preciseTarget].ShowHealth() <= 0)
            {
                targetHorde.enemyStorage.RemoveAt(preciseTarget);
            }
        }
        public void SlashAttack(EnemiesFactory targetHorde, List<int> manyTarget)
        {
            foreach (int target in manyTarget)
            {
                targetHorde.enemyStorage[target].DamageHealth(AttackAttribute);

            }
        }
        public void HealHealth(int HealthRegen)
        {
            int healthLeftToMax;
            healthLeftToMax = MAX_PLAYER_HEALTH - playerHealth;
            if (HealthRegen > 0)
            {
                if (playerHealth + HealthRegen >= MAX_PLAYER_HEALTH)
                {
                    this.playerHealth = MAX_PLAYER_HEALTH;
                }
                else
                {
                    this.playerHealth = playerHealth + HealthRegen;
                }
            }
        }
        public void TakeDamage(int Damage)
        {
            if (playerHealth - Damage <= 0)
            {
                this.playerHealth = 0;
            }
            else
            {
                this.playerHealth -= Damage;
            }
        }
    }
}
