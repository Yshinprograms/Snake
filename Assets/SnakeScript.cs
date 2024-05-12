using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public GameObject snake;
    public float unitMoved = 0.1f;

    //1-4 represents up,right,down,left respectively
    //Set 1 as default because snake faces up at first
    private int dir;

    // Start is called before the first frame update
    void Start()
    {
        dir = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currPos = transform.position;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = 2;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = 3;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = 4;
        }


        //constantly move every iteration
        move(dir);
    }


    //Vector3 is a unit vector pointing to up,right,down,left
    public void move(int dir)
    {
        if (dir == 1)
        {
            transform.position += Vector3.up * unitMoved * Time.deltaTime;
        }
        if (dir == 2)
        {
            transform.position += Vector3.right * unitMoved * Time.deltaTime;
        }
        if (dir == 3)
        {
            transform.position += Vector3.down * unitMoved * Time.deltaTime;
        }
        if (dir == 4)
        {
            transform.position += Vector3.left * unitMoved * Time.deltaTime;
        }
    }
}
