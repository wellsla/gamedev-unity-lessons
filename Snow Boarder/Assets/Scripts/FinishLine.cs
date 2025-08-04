using UnityEngine;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {           
            Debug.Log("Player has crossed the finish line!");           
        }      
    }
}
