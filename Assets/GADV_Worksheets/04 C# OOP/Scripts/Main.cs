using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // 1. Define a class

    // 1(a).
    private float speed = 1.0f;
    public void ProjectileSetup(float speed)
    {
        this.speed = speed;
    }

    public void Fire()
    {
        if (speed > 0.0f)
        {
            Debug.Log($"Firing projectile at speed {speed}");
        }
        else
        {
            // 1(c).
            AutoFire();
            // 1(b).
            Debug.Log("Cannot fire: speed too low.");
        }
    }

    // 1(c).
    public void AutoFire()
    {
        speed = 100;
        Debug.Log("Speed was zero. AutoFire set speed to 100 and launched!");
    }




    // 2(a). Encapsulation
    public class Player
    {
        private int health;
        public Player(int startingHealth)
        {
            health = startingHealth;  
        }

        public void TakeDamage (int amount)
        {
            health -= amount;
        }

        public int GetHealth()
        {
            return health;
        }

    }

    // 2(b). Encapsulation 
    public class ScoreTracker
    {
        private int score;

        public void AddScore(int points)
        {
            if (points > 0)
            {
                score += points;
            }
        }
        public void ResetScore()
        {
            score = 0;
        }
    }

    // 3(a). Inherintence and Override

    public class TreasureChest
    {
        public virtual void Unlock()
        {

        }

        // 4(a). Method Overloading
        public virtual void Unlock(bool hasToken)
        {
            if (hasToken)
            {
                Debug.Log("You get bonus treasure!");
            }

            else
            {
                Unlock();
            }
        }

        public void Shake()
        {
            Debug.Log("You hear something rattle inside the chest.");
        }

        public class AncientChest : TreasureChest
        {
            public override void Unlock()
            {
                Debug.Log("You unlock the ancient chest with an ancient key.");
            }
        }
        public class MagicChest : TreasureChest
        {
            public override void Unlock()
            {
                Debug.Log("You cast a spell to unlock the magic chest.");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }


}
