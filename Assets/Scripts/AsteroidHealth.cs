using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHealth : MonoBehaviour
{
    public int health = 100;
    private int currentHealth = 0;

    public GameObject explosion;
    private bool exploding = false;
    public AudioClip explosionClip;
    public float explosionVolume;

    public int scoreValue = 0;
    public GameController gameController;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        currentHealth = health;
    }

    void Update()
    {
        
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Asteroid Health " + currentHealth);

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
        exploding = true;
        yield return new WaitForSeconds(0.1f);
        GameObject explosionGo = Instantiate(explosion, transform.position, Quaternion.Euler(0, 0, 0));
        Destroy(gameObject, 0.5f);
        Destroy(explosionGo, 1f);
        yield return 0;
        AudioSource.PlayClipAtPoint(explosionClip, 0.9f * Camera.main.transform.position + 0.1f * transform.position, 10f);
        yield return new WaitForSeconds(0.1f);
        exploding = false;
    }
}
