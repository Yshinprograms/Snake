using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public GameObject snake;
    public GameObject segment;
    public GameObject rabbit;
    public float unitMoved = 5;
    public float speed = 7f;
    public float turnSpeed = 7f;
    public static bool alive = true;

    private int dir;
    private List<Transform> segments;

    //1-4 represents up,right,down,left respectively
    //Set 2 as default because snake faces right at first
    void Start()
    {
        dir = 2;
        RabbitScript.rabbitEaten += spawnSegment;
        //Fill segments with the transforms of new spawned segments
        segments = new List<Transform>();
    }

    //Add rotation of snake segments, follow head direction

    void Update()
    {
        if (alive)
        {
            findDir();
            move(dir);
            segmentFollowing();
        }

    }

    private void segmentFollowing()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            segments[i].position = 
                Vector3.Lerp(segments[i].position, segments[i - 1].position, speed * Time.deltaTime);
            segments[i].rotation =
                Quaternion.Slerp(segments[i].rotation, segments[i - 1].rotation, turnSpeed * Time.deltaTime);

        }
        //we need to have the conditional >0 because the snake may not have any segment yet, so no segments[0] exists
        if (segments.Count > 0)
        {
            segments[0].position = 
                Vector3.Lerp(segments[0].position, snake.transform.position, speed * Time.deltaTime);
            segments[0].rotation = 
                Quaternion.Slerp(segments[0].rotation, transform.rotation, turnSpeed * Time.deltaTime);
        }
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

    private void OnDestroy()
    {
        // Unsubscribe from the event
        RabbitScript.rabbitEaten -= spawnSegment;
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

    private void spawnSegment()
    {
        GameObject newSeg = Instantiate(segment, snake.transform.position, Quaternion.identity);
        segments.Add(newSeg.transform);
        segment.SetActive(true);
    }


}
