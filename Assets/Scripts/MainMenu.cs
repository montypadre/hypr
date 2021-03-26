using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float maxRange = 20f;
    public float minRange = 10f;
    public GameObject asteroid;

    public float maxScale = 10f;
    public float minScale = 5f;

    public float spawnInterval = 5f;
    float time = 0.0f;
    private float minY;
    private float maxY;
    private float minX;
    private float maxX;

    void Start()
    {
        this.minY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -Camera.main.transform.position.z)).y;
        this.maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, -Camera.main.transform.position.z)).y;
        this.minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -Camera.main.transform.position.z)).x;
        this.maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, -Camera.main.transform.position.z)).x;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawnInterval)
        {
            time = time - spawnInterval;
            InstantiateRandomAsteroid();
        }
    }

    void InstantiateRandomAsteroid()
    {
        bool targetPending = true;

        float spawnX = 0;
        float spawnY = 0;

        while (targetPending)
        {
            spawnX = UnityEngine.Random.Range(maxX + minRange, maxX + maxRange);
            spawnY = UnityEngine.Random.Range(minY, maxY);

            Collider[] colliders = Physics.OverlapBox(new Vector3(spawnX, spawnY, 0), new Vector3(1, 1, 1));

            targetPending = colliders.Length > 0;
        }

        GameObject asteroidObject = Instantiate(asteroid, new Vector3(spawnX, spawnY, 0), Quaternion.Euler(0, 0, 0));
        float scale = UnityEngine.Random.Range(minScale, maxScale);

        asteroidObject.transform.localScale = new Vector3(scale, scale, scale);

        asteroidObject.GetComponent<Rigidbody>().AddForce(-asteroidObject.transform.right * 100f);
    }


   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
