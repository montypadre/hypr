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
        GetComponent<Rigidbody>().AddForce(transform.forward * 100f);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (currentTime < damageCooldown)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                currentTime = 0f;

                HealthController healthController = other.gameObject.GetComponent<HealthController>();

                if (healthController != null)
                {
                    healthController.DealDamage(damage);
                }
            }
        }
    }
}
