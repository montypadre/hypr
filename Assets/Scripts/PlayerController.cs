using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.Detectors;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed;
    public float movementSpeed;
    public GameObject lazer;
    public AudioClip lazerFire;
    public float lazerVolume;
    public float cooldown = 1f;
    private float time = 0f;
    private bool cheaterDetected = false;
    public GameController gameController;

    void Start()
    {
        ObscuredCheatingDetector.StartDetection(OnCheaterDetected);
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        GetComponent<Rigidbody>().freezeRotation = true;
    }

    private void OnCheaterDetected()
    {
        cheaterDetected = true;
    }

    void OnDestroy()
    {
        gameController.StoreScore();
        gameController.PlayerDies();
    }

    void Update()
    {
        if (cheaterDetected)
        {
            Debug.Log("'I would prefer even to fail with honor than win by cheating' - Sophocles");
            Application.Quit();
        }

        if (time > 0f)
        {
            time -= Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(lazer, transform.TransformPoint(Vector3.forward * 2), transform.rotation);
            AudioSource.PlayClipAtPoint(lazerFire, 0.9f * Camera.main.transform.position + 0.1f * transform.position, lazerVolume);
            time = cooldown;
        }

        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * -movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
           
        if (Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * -movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
