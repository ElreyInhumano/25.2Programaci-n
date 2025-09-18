using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._2Ejercicios
{
    class Game
    {
        public static Weapon pistol = new Pistol("range", 3);
        public static Weapon axe = new Axe("melee", 3);
        public Enemy enemyRange1 = new EnemyRange("range", "healPotion", pistol, 5);
        public Enemy enemy;

        public Enemy enemyMelee1 = new EnemyMelee("melee", "healPotion", axe, 8);
        public Enemy enemyMelee2 = new EnemyMelee("melee", "shield", axe, 10);
        private static string name;
        private static int life;
        private static int dmg;
        private static string item;
        private static Player player = new Player(name,life, dmg, item);
        Func<int, int> setPlayerLife, setPlayerDmg;
        Func<string, string> setPlayerName, playerItem;
        Func<string> playerName;
        Func<int> playerLife, playerDmg;
        private int stages, stage;
        private List<Enemy> list = new List<Enemy>();
        private List<Item> listItems = new List<Item>();
        public void StartGame()
        {
            player.SetPlayerInstance();
            SetFuncs();            
            SetGame();
        }
        public void SetGame()
        {
            Console.WriteLine("Introduzca a los enemigos");
            AddEnemiesToList();
            Console.WriteLine("Introduzca la cantidad de stages");
            stages = int.Parse(Console.ReadLine());
            stage = 1;
            CreatePlayer();
            if (playerLife() > 0)
            {
                while (stage <= stages)
                {
                    EnemyChange();
                    Fighting();
                }
            }
            if (playerLife() <= 0)
            {
                Defeat();
            }
            if (list.Count <= 0)
            {
                Victory();
            }

        }
        void Fighting()
        {
            bool action = false;
            if(playerLife() > 0)
            {
                while(enemy.life > 0 &&playerLife() > 0)
                {
                    action = false;
                    Console.WriteLine($"Stage {stage}. Te enfrentas al siguiente enemigo {ShowInfoEnemy()}");
                    while(!action && playerLife() > 0)
                    {
                        Console.WriteLine($"Es tu turno, escoge si usar un *item* o si *atacar*");
                        string option = Console.ReadLine();
                        if(option == "atacar")
                        {
                            enemy.GetDamage(playerDmg());
                            action = true;
                        }
                        if (option == "item")
                        {
                            if(listItems.Count > 0)
                            {
                                
                                action = true;
                            }
                        }
                        if(enemy.life <= 0)
                        {
                            Console.WriteLine("Enemigo eliminado");
                            list.RemoveAt(0);
                            stage++;
                        }
                    }
                }
            }
        }
        void Defeat()
        {
            Console.WriteLine("Perdiste");
            Console.ReadLine();
        }
        void Victory()
        {
            Console.WriteLine("Felicidades ganaste el juego");
            Console.ReadLine();
        }
        void AddEnemiesToList()
        {
            list.Add(enemyRange1);
            list.Add(enemyMelee1);
            list.Add(enemyMelee2);
        }
        public void EnemyChange()
        {
            switch (stage)
            {
                case 1:
                    enemy = enemyMelee1;
                    break;
                case 2:
                    enemy = enemyRange1;
                    break;
                case 3:
                    enemy = enemyMelee2;
                    break;
                default:
                    enemy = enemyMelee1;
                    break;
            }
        }
        public string ShowInfoEnemy()
        {
            switch (stage)
            {
                case 1:
                    return ShowInfoEnemy1();
                case 2:
                    return ShowInfoEnemy2();
                case 3:
                    return ShowInfoEnemy3();
                default:
                    return ShowInfoEnemy1();
            }
        }
        public string ShowInfoEnemy1()
        {
            return $"tiene {enemyMelee1.life} de vida y su hacha hace {enemyMelee1.weapon.dmg} de daño";
        }
        public string ShowInfoEnemy2()
        {
            return $"tiene {enemyRange1.life} de vida y su pistola hace {enemyRange1.weapon.dmg} de daño";
        }
        public string ShowInfoEnemy3()
        {
            return $"tiene {enemyMelee2.life} de vida y su hacha hace {enemyMelee2.weapon.dmg} de daño";
        }
        void SetFuncs()
        {
            setPlayerLife = Player.GetPlayerInstance().SetLife;
            playerLife = Player.GetPlayerInstance().GetLife;
            setPlayerDmg = Player.GetPlayerInstance().SetDmg;
            playerDmg = Player.GetPlayerInstance().GetDmg;
            setPlayerName = Player.GetPlayerInstance().SetName;
            playerName = Player.GetPlayerInstance().GetName;
            playerItem = Player.GetPlayerInstance().SetItem;
        }
        void CreatePlayer()
        {
            bool pjCreated = false;
            while (!pjCreated)
            {
                Console.WriteLine("Introduzca el nombre de su personaje");
                setPlayerName(Console.ReadLine());
                Console.WriteLine("Introduzca la vida de su personaje");
                setPlayerLife(int.Parse(Console.ReadLine()));
                Console.WriteLine("Introduzca el daño de su personaje");
                setPlayerDmg(int.Parse(Console.ReadLine()));
                if(playerLife() <= 0 || playerDmg() <= 0 || playerName() == "")
                {
                    Console.WriteLine("Las estadísticas no pueden ser menor o igual a cero y el nombre no puede estar vacío");
                }
                else
                {
                    pjCreated = true;
                }
            }
        }
    }
}
