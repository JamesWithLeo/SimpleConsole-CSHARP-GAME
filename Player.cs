using System;


namespace Classes101
{
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
