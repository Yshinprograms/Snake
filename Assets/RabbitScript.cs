using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RabbitScript : MonoBehaviour
{
    public delegate void RabbitEaten();
    public static event RabbitEaten rabbitEaten;

    private float xBoundary = 8.5f;
    private float yBoundary = 5.5f;
    // Start is called before the first frame update
    void Start()
    {
        rabbitEaten += respawn;
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
            if (rabbitEaten != null)
            {
                rabbitEaten();
            }
     
        }
    }

    private void respawn()
    {
        Vector2 newPosition = new Vector2(
            Random.Range(-xBoundary, xBoundary),
            Random.Range(-yBoundary, yBoundary)
            );

        transform.position = newPosition;
    }
}
