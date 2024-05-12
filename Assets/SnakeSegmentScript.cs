using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//if i have a snakesegment script for my snake game where i want to spawn a segment
//whenever i collide with a rabbit, but the function for ontriggerenter2d is in
//another RabbitScript, how may i use the same trigger for my snakesegment script?

public class SnakeSegmentScript : MonoBehaviour
{
    //public RabbitScript rabbit;
    public GameObject rabbit;
    public GameObject segment;
    // Start is called before the first frame update
    void Start()
    {
        //rabbit = GameObject.FindGameObjectWithTag("Logic").GetComponent<RabbitScript>();
        segment.SetActive(false);
    }

    // Update is called once per frame
    //spawn a new segment whenever rabbit triggers
    void Update()
    {
        if ()
    }

    void spawn()
    {

    }
}
