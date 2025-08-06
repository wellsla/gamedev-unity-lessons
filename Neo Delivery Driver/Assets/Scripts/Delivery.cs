using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float delay = 0.5f;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasPackage && collision.CompareTag("Package"))
        {
            hasPackage = true;
            Debug.Log("Package picked up!");
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, delay);
        }
        else if (hasPackage && collision.CompareTag("Customer"))
        {
            hasPackage = false;
            Debug.Log("Package delivered!");
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject);
        }
    }
}
