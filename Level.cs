using System;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Classes101;

namespace Classes101
{
    internal class Level
    {
        //public string[] commandsList = new string[] {"ATTACK", "EXIT", "IDLE", "DESCRIPTION"};
        public int _level;
        string reward = "sword";
        public Player player;
        public EnemiesFactory enemies;
        public Level(Player WhoIsPlayer) { 
            this.player = WhoIsPlayer;
        }
        public void CreateLevel(int level,int EnemiesCount) {
            this._level = level;
            Console.WriteLine(
                $"Level {level}\t" +
                $"{player.playerName}[{player.ShowHealth()}]\n");
            Console.WriteLine("Hit Enter to Start");
            Console.ReadLine();

            EnemiesFactory EnemyOrchSpawner = new EnemiesFactory(); // instantiate 
            EnemyOrchSpawner.CreateEnemy(EnemiesCount, "Orch");

            Console.WriteLine(
                $"{EnemyOrchSpawner.EnemiesCount().ToString()} " +
                $"unknown enemies approaching!");
            CountDown(3);
            EnemyOrchSpawner.takeEnemies();
            this.enemies=EnemyOrchSpawner;

            PlayerTurn(player,this.enemies);
            

        }
        static void result(EnemiesFactory enemies, Player player
            )
        {
            if (enemies.EnemiesCount() <= 0)
            {
                Console.WriteLine("New Level");
            }
            else
            {   
                Console.Clear();
                Console.WriteLine("Commands : (A)ttack (E)xit (I)dle) (D)escription\n");
                Console.WriteLine();
                enemies.takeEnemies();
                PlayerTurn(player,enemies);

            }

        }

        public static char PlayerTurn(Player player,EnemiesFactory enemies) {            
            string? userDecision;
            string[] UserAttackTarget;
            string commands;
            int[] targets = new int[] {};
            while (true)
            {
                Console.Write("\nYour Turn:");
                userDecision = Console.ReadLine();
                UserAttackTarget = userDecision.Split(" ");
                if (UserAttackTarget.Length == 1)
                {
                    if (UserAttackTarget.GetValue(0).ToString().ToUpper() == "D")
                    {
                        Console.WriteLine("Description");
                    }
                    else
                    {
                        Console.Clear();
                        enemies.takeEnemies();
                        continue;
                    }
                }
                else
                {
                    commands = UserAttackTarget.GetValue(0).ToString();
                    targets.Append(int.Parse(UserAttackTarget[1]));

                    if (UserAttackTarget.GetValue(0).ToString().ToUpper()[0].ToString() == "A")
                    {
                        player.Attack(enemies, int.Parse(UserAttackTarget[1]) - 1);
                        result(enemies,player);
                        break;

                    }
                    else
                    {
                        Console.Clear();
                        enemies.takeEnemies();
                        continue;
                    }
                }
            }
            return userDecision[0];
        }


        static void CountDown(int howLongToWait)
        {
            for (int i = 0; i < howLongToWait; i++)
            {
                Console.Write(". ");
                Thread.Sleep(800);
            }
            Console.WriteLine();
        }
    }
}
