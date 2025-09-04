using UnityEngine;

public class FlyAtPlayer : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] Transform player;
    Vector3 playerPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
        DestroyWhenReached();
    }

    void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime * speed);   
    }

    void DestroyWhenReached()
    {
        if (transform.position == playerPosition)
        {        
            Destroy(gameObject);
        }
    }
}
