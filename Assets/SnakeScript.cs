using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public GameObject snake;
    public float unitMoved = 0.1f;

    private int dir;

    //1-4 represents up,right,down,left respectively
    //Set 2 as default because snake faces right at first
    void Start()
    {
        dir = 2;
    }

    void Update()
    {

        findDir();
        move(dir);
    }

    private void findDir()
    {
        //the camera is pointing directly down on the xy axis, so we are at the arrow of the z-axis
        //so we should rotate around the z-axis
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Head faces 90 degrees by default
            dir = 1;
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = 2;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = 3;
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = 4;
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
    }

    private void move(int dir)
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
