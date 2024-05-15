using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    public delegate void BorderCollision();
    public static event BorderCollision borderCollision;

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
            if (borderCollision != null)
            {
                borderCollision();
            }
        }
        Debug.Log("Collided with border");
    }
}
