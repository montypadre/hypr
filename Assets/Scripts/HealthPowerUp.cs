using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public GameObject pickupEffect;
    public AudioClip healthPowerUpClip;
    private int health;
    private bool powerupActive;
    public GameController gameController;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if (!powerupActive)
        {
            StartCoroutine(PowerUp(10f));
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    { 
        AudioSource.PlayClipAtPoint(healthPowerUpClip, 0.9f * Camera.main.transform.position + 0.1f * transform.position, 10f);
        pickupEffect = Instantiate(pickupEffect, transform.position, transform.rotation);

        health = player.GetComponent<PlayerHealth>().GetHealth();
        if (health < 100)
            if (health >= 1 && health <= 9)
            {
                health += 10 - health;
                gameController.UpdateHealth(health);
            } else 
            {
                health += 10;
                gameController.UpdateHealth(health);
            }

        Destroy(gameObject);
        Destroy(pickupEffect, .15f);
    }

    IEnumerator PowerUp(float duration)
    {
        powerupActive = true;
        yield return new WaitForSeconds(duration);
        powerupActive = false;
        Destroy(gameObject);
    }
}
