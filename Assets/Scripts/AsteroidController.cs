﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public int damage;
    public AudioClip impact;
    public float damageCooldown = 0.5f;
    public float currentTime;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 700f);
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log("Entering Player collision");
        if (other.gameObject.tag == "Player")
        {
            // Play sound
            AudioSource.PlayClipAtPoint(impact, 0.9f * Camera.main.transform.position + 0.1f * transform.position, 10f);

            if (currentTime < damageCooldown)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                currentTime = 0f;

                PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    playerHealth.DealDamage(damage);
                }
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
