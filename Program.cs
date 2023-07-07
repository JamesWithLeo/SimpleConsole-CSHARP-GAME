using System;
using Classes101;

namespace Classes101
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("james");

            EnemiesFactory EnemyWitchSpawner = new EnemiesFactory(); // instantiate 

            EnemiesFactory EnemyOrchSpawner = new EnemiesFactory(); // instantiate 
            EnemyOrchSpawner.CreateEnemy(3, "Orch");


            Console.WriteLine(
                $"{p1.playerName.ToString()}" +
                $" has {p1.ShowHealth()} health points.");

            // Quantity of Enemy .
            Console.WriteLine(
                $"{EnemyOrchSpawner.EnemiesCount().ToString()} " +
                $"unknown enemies approaching!");
            Console.ReadLine();

            EnemyOrchSpawner.takeEnemies();

            List<int> EnemiesToKill = new List<int>() { 1, 1, 1, 0 };
            p1.Attack(EnemyOrchSpawner, 1);
            p1.SlashAttack(EnemyOrchSpawner, EnemiesToKill);
            Console.WriteLine("Type (Attack) to fight");
            string userType;
            userType = Console.ReadLine();
            if (userType.ToUpper() == "ATTACK")
            {
                Console.Clear();
                EnemyOrchSpawner.takeEnemies();


                p1.HealHealth(12);
                Console.WriteLine(
                    $"{p1.playerName} regenerate some health ({p1.ShowHealth()}HP)");
                Console.WriteLine("Remaining orchs fled!?");
            }
            else
            {
                p1.TakeDamage(100);
                Console.WriteLine($"Player Dead, ({p1.ShowHealth()}Hp)");
            }

        }
    }

    internal class Player
    {
        public string playerName;
        private int AttackAttribute = 25;
        private int playerHealth = 50;
        private int MAX_PLAYER_HEALTH = 100;

        public Player(string name)
        {
            this.playerName = name;
        }
        public string ShowHealth()
        {
            return playerHealth.ToString();
        }
        

        public void Attack(EnemiesFactory targetHorde,int preciseTarget)
        {
            targetHorde.enemyStorage[preciseTarget].DamageHealth(AttackAttribute);
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
