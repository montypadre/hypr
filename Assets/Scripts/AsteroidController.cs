using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public int damage;
    public float damageCooldown = 0.5f;
    public float currentTime;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 200f);
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log("Entering Player collision");
        if (other.gameObject.tag == "Player")
        {
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
