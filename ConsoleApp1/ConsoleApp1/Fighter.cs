using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Class of the fighter
    public class Fighter
    {
        // Properties of the fighter
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int health;
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        private int attack;
        public int Attack
        {
            get { return attack; }
            set {attack = value; }
        }

        private int speed;
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        // Constructor of the fighter
        public Fighter(string name, int health, int attack, int speed, int x, int y)
        {
            this.name = name;
            this.health = health;
            this.attack = attack;
            this.speed = speed;
            this.x = x;
            this.y = y;
        }

        // Move the player up
        public void moveUp()
        {
            if (y == 0)
            {
                Console.WriteLine("\"You hit a wall! Be carefull next time!\"");
            }
            else
            {
                 y -= speed;
            }
        }

        // Move the player down
        public void moveDown()
        {
            if (y == 10)
            {
                Console.WriteLine("\"You hit a wall! Be carefull next time!\"");
            }
            else
            {
                y += speed;
            }
        }

        // Move the player left
        public void moveLeft()
        {
            if (x == 0)
            {
                Console.WriteLine("\"You hit a wall! Be carefull next time!\"");
            }
            else
            {
                x -= speed;
            }
        }

        // Move the player right
        public void moveRight()
        {
            if (x == 10)
            {
                Console.WriteLine("\"You hit a wall! Be carefull next time!\"");
            }
            else
            {
                x += speed;
            }
        }

        // Attack the opposit player
        public void attackPlayer(Fighter oppositFighter)
        {
            // if the distance between the two players is less than the square root of 2, the attack is successful
            if (rangeBetweenPlayers(this, oppositFighter) <= Math.Sqrt(2))
            {
                Console.WriteLine("\"{0} attacks {1}\"", name, oppositFighter.name);
                oppositFighter.health -= attack;
                Console.WriteLine("\"{0} has {1} health left\"", oppositFighter.name, oppositFighter.health);
            }
            else
            {
                // if the distance between the two players is greater than the square root of 2, the attack is not successful
                Console.WriteLine("\"You are too far away to attack\"");
            }
        }

        // Heal the player
        public void healPlayer()
        {
            health += 1;
        }

        // Increase the attack of the player
        public void increaseAttack()
        {
            attack += 1;
        }

        // Increase the speed of the player
        public void increaseSpeed()
        {
            speed += 1;
        }

        // Calculate the distance between two players
        public double rangeBetweenPlayers(Fighter player1, Fighter player2)
        {
            int a = player1.x - player2.x;
            int b = player1.y - player2.y;
            return Math.Sqrt(a * a + b * b);
        }
    }
}
