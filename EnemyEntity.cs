using System;


namespace Classes101
{
    internal class EnemiesFactory
    {
        private int EnemyQuatity;
        public List<Enemies> enemyStorage = new List<Enemies>();

        public void CreateEnemy(int quantityOfEnemy, string name)
        {
            for (int i = 0; i < quantityOfEnemy; i++)
            {
                Enemies E = new Enemies();
                E.SetEnemy(name, 100);
                enemyStorage.Add(E);
                EnemyQuatity++;
            }

        }
        public void takeEnemies()
        {
            for (int i = 0; i < enemyStorage.Count; i++)
            {   
                Thread.Sleep(800);
                Console.WriteLine($"{i+1}.) "+ enemyStorage[i].ShowName() + " " +
                    enemyStorage[i].ShowHealth().ToString() + " Hp");
            }
        }
        public int EnemiesCount()
        {
            return enemyStorage.Count();
            //Console.WriteLine(EnemyQuatity);
        }
    }


    internal class Enemies
    {
        
        private string name { get; set; }
        private int healthPoint { get; set; }
        public void SetEnemy(string EnemyName, int hp)
        {
            this.name = EnemyName;
            this.healthPoint = hp;
        }

        public int ShowHealth()
        {
            return healthPoint;
        }
        public string ShowName()
        {
            return name;
        }

        public void DamageHealth(int DamageInflict)
        {
            healthPoint -= DamageInflict;
            if (healthPoint == 0)
            {
                this.name = "Dead " + name;
            }
        }
    }
}
