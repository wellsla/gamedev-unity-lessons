using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{
    [SerializeField] float currentSpeed = 10f;
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] float regularSpeed = 10f;
    [SerializeField] TMP_Text boostText;

    void Start()
    {
        boostText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            currentSpeed = boostSpeed;
            boostText.gameObject.SetActive(true);
            Debug.Log("Boost activated!");
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        currentSpeed = regularSpeed;
        Debug.Log("Collision with obstacle, speed reset.");
        boostText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f; // Move forward
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1f; // Move backward
        }

        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f; // Steer left
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f; // Steer right
        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);

        float steerAmount = steer * steerSpeed * Time.deltaTime;
        transform.Rotate(0, 0, steerAmount);
    }
}
