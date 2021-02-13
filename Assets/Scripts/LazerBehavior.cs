using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBehavior : MonoBehaviour
{
    public float speed;
    public int damage = 40;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entering collision");

        HealthController healthController = other.gameObject.GetComponent<HealthController>();

        if (healthController != null)
        {
            healthController.DealDamage(damage);
        }

        GameObject.Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
