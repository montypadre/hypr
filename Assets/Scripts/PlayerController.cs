using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed;
    public float movementSpeed;
    public GameObject lazer;
    public AudioClip lazerFire;
    public float lazerVolume;
    public float cooldown = 1f;
    private float time = 0f;
    public GameController gameController;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        GetComponent<Rigidbody>().freezeRotation = true;
    }

    void OnDestroy()
    {
        gameController.StoreScore();
        gameController.PlayerDies();
    }

    void Update()
    {
        #if UNITY_STANDALONE || UNITY_WEBGL
            if (time > 0f)
            {
                time -= Time.deltaTime;
            }
            else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.RightShift))
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
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
            if (Input.touchCount > 0)
            {
                Touch touch = Input.touches[0];

                if (touch.phase == TouchPhase.Began)
                {
                    touchOrigin = touch.position;
                }
                else if
                {
                    Vector 2 touchEnd = touch.position;

                    float x = touchEnd.x - touchOrigin.x;
                    float y = touchEnd.y - touchOrigin.y;

                    touchOrigin.x = -1;

                    if (Mathf.Abs(x) > Mathf.Abs(y))
                        horizontal = x > 0 ? 1 : -1;
                    else
                        vertical = y > 0 ? 1 : -1;
                }
            }

#endif


    }
}
