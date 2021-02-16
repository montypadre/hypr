using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconPowerUp : MonoBehaviour
{
    public GameController gameController;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        //health = player.GetComponent<PlayerHealth>().GetHealth();
        //if (health < 100)
        //    if (health >= 1 && health <= 9)
        //    {
        //        health += 10 - health;
        //        gameController.UpdateHealth(health);
        //    }
        //    else
        //    {
        //        health += 10;
        //        gameController.UpdateHealth(health);
        //    }

        Destroy(gameObject);
    }
}
