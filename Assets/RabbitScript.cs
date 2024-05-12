using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called when a collider enters the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            respawn();
            Debug.Log("Collided");
        }
    }

    private void respawn()
    {
        Vector2 newPosition = new Vector2(
            Random.Range(-9, 9),
            Random.Range(-5, 5)
            );

        transform.position = newPosition;
    }
}
