using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoPowerUp : MonoBehaviour
{
    public GameObject pickupEffect;
    public AudioClip slowmoPowerUpClip;
    private bool powerupActive;
    //public static bool SloMoEnabled = false;
    //public float SloMoTimeDivision = 3.0f;
    //private float defaultPhysStep = 0;
    public TimeManager timeManager;
    public GameController gameController;

    void Start()
    {
        //defaultPhysStep = Time.fixedDeltaTime;
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        Debug.Log(Time.fixedDeltaTime);
        if (!powerupActive)
        {
            StartCoroutine(PowerUp(10f));
        }
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
        AudioSource.PlayClipAtPoint(slowmoPowerUpClip, 0.9f * Camera.main.transform.position + 0.1f * transform.position, 10f);
        pickupEffect = Instantiate(pickupEffect, transform.position, transform.rotation);

        timeManager.SlowMotion();
        //StartCoroutine(Speedup());
        //Time.timeScale = 1.0f / SloMoTimeDivision;
        //Time.fixedDeltaTime = defaultPhysStep / SloMoTimeDivision;

        Destroy(gameObject);
    }

    IEnumerator PowerUp(float duration)
    {
        powerupActive = true;
        yield return new WaitForSeconds(duration);
        powerupActive = false;
        Destroy(gameObject);
    }

    //IEnumerator Speedup()
    //{
    //    yield return new WaitForSeconds(10f);
    //    Time.timeScale = 1.0f;
    //    Time.fixedDeltaTime = defaultPhysStep;
    //}
}
