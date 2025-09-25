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
        private static Player player = new Player(name,life,dmg,item);
        Func<int, int> setPlayerLife, setPlayerDmg;
        Func<string, string> setPlayerName, playerItem;
        Func<string> playerName;
        Func<int> playerLife, playerDmg;
        Action<int> playerReceiveDmg;
        private int stages, stage;
        private int enemyType, enemyLife, enemyWeapon;
        private string itemEnemy;
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
            Console.WriteLine("Introduzca la cantidad de stages");
            stages = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca a los enemigos");
            for(int i = 1; i <= stages; i++)
            {
                Console.WriteLine($"Enemigo {i}");
                Console.WriteLine("Introduzca su tipo");
                enemyType = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduzca su item");
                itemEnemy = Console.ReadLine();
                Console.WriteLine("Introduzca su vida");
                enemyLife = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduzca su arma");
                enemyWeapon = int.Parse(Console.ReadLine());
                switch (enemyType)
                {
                    case 1:
                        switch (enemyWeapon)
                        {
                            case 1:
                                AddEnemiesToList(itemEnemy, axe, enemyLife);
                                Console.WriteLine($"Enemigo añadido");
                                break;
                        }
                        break;
                    case 2:
                        switch (enemyWeapon)
                        {
                            case 1:
                                AddEnemiesToList(itemEnemy, pistol, enemyLife);
                                Console.WriteLine($"Enemigo añadido");
                                break;
                        }
                        break;
                }
                
            }
            
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
                            enemy.ReceiveDamage(playerDmg());
                            Console.WriteLine($"Has hecho {playerDmg()} de daño");
                            Console.WriteLine($"Enemigo tiene {enemy.life} de vida");
                            action = true;
                        }
                        if (option == "item")
                        {
                            if(listItems.Count > 0)
                            {
                                Console.WriteLine($"Has usado un item");
                                action = true;
                            }
                        }                        
                    }
                    if (enemy.life <= 0)
                    {
                        Console.WriteLine("Enemigo eliminado");
                        list.RemoveAt(0);
                        stage++;
                    }
                    else
                    {
                        Console.WriteLine($"Es el turno del enemigo y este te ataca");
                        playerReceiveDmg(enemy.weapon.dmg);
                        Console.WriteLine($"Te queda {playerLife()} de vida");
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
        void AddEnemiesToList(string item, Weapon weapon, int life)
        {
            string enemyType;
            switch (this.enemyType)
            {
                case 1:
                    enemyType = "melee";
                    Enemy enemyMelee = new EnemyMelee(enemyType, item, weapon, life);
                    list.Add(enemyMelee);
                    break;
                case 2:
                    enemyType = "range";
                    Enemy enemyRange = new EnemyRange(enemyType, item, weapon, life);
                    list.Add(enemyRange);
                    break;
            }
        }
        public void EnemyChange()
        {
            enemy = list[0];
            Console.WriteLine(enemy.type);
            Console.WriteLine(enemy.life);

            /*switch (stage)
            {
                case 1:
                    enemy = enemyMelee1;
                    Console.WriteLine(enemy);
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
            }*/
        }
        public string ShowInfoEnemy()
        {
            return ShowInfoEnemies();
            /*switch (stage)
            {
                case 1:
                    return ShowInfoEnemy1();
                case 2:
                    return ShowInfoEnemy2();
                case 3:
                    return ShowInfoEnemy3();
                default:
                    return ShowInfoEnemy1();
            }*/
        }
        public string ShowInfoEnemies()
        {
            return $"tiene {enemy.life} de vida y su arma hace {enemy.weapon.dmg} de daño";
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
            playerReceiveDmg = Player.GetPlayerInstance().ReceiveDamage;
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
                    //player = new Player(playerName(), playerLife(), playerDmg(), item);
                    pjCreated = true;
                }
            }
        }
    }
}
