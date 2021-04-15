using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat.Detectors;


public class AsteroidController : MonoBehaviour
{
    public ObscuredInt damage;
    public GameObject sparks;
    public AudioClip impact;
    public float damageCooldown = 0.5f;
    public float currentTime;
    private bool cheaterDetected = false;

    void Start()
    {
        ObscuredCheatingDetector.StartDetection(OnCheaterDetected);
        GetComponent<Rigidbody>().AddForce(transform.forward * 700f);
    }

    private void OnCheaterDetected()
    {
        cheaterDetected = true;
    }

    void Update()
    {
        if (cheaterDetected)
        {
            Debug.Log("'I would prefer even to fail with honor than win by cheating' - Sophocles");
            Application.Quit();
        }
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

                PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    AudioSource.PlayClipAtPoint(impact, 0.9f * Camera.main.transform.position + 0.1f * transform.position, 10f);
                    GameObject sparksGo = Instantiate(sparks, other.transform.position, other.transform.rotation);
                    Destroy(sparksGo, 0.1f);
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
