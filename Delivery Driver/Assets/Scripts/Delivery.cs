using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(0, 1, 0, 1); // Greenish color
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1); // White color

    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasPackage && other.tag == "Package")
        {
            Debug.Log("Package picked!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        if (hasPackage && other.tag == "Costumer")
        {
            Debug.Log("Package delivered!");
            hasPackage = false;          
            spriteRenderer.color = noPackageColor;
        }
    }
}
