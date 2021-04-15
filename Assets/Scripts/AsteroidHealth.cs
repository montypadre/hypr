using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat.Detectors;

public class AsteroidHealth : MonoBehaviour
{
    public ObscuredInt health = 100;
    private ObscuredInt currentHealth = 0;

    public GameObject explosion;
    private bool exploding = false;
    public AudioClip explosionClip;
    public float explosionVolume;

    public GameObject[] powerUps;
    public float percentDrop;

    private bool cheaterDetected = false;
    public ObscuredInt scoreValue = 0;
    public GameController gameController;

    void Start()
    {
        ObscuredCheatingDetector.StartDetection(OnCheaterDetected);
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        currentHealth = health;
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

    public void DealDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && !exploding)
        {
            StartCoroutine(Explode());
            if (scoreValue > 0)
            {
                gameController.IncreaseScore(scoreValue);
            }
        }
    }

    IEnumerator Explode()
    {
        float rand = UnityEngine.Random.Range(0f, 100f);
        exploding = true;
        yield return new WaitForSeconds(0.01f);
        GameObject explosionGo = Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(gameObject, 0.5f);
        Destroy(explosionGo, 1f);
        yield return 0;
        AudioSource.PlayClipAtPoint(explosionClip, 0.9f * Camera.main.transform.position + 0.1f * transform.position, 10f);
        yield return new WaitForSeconds(0.01f);
        exploding = false;

        if (rand < percentDrop)
        {
            GameObject powerUp = Instantiate(powerUps[UnityEngine.Random.Range(0, powerUps.Length)], transform.position, transform.rotation);
        }
    }
}
