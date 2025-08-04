using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Player has crashed!");        
            }
        }
}
