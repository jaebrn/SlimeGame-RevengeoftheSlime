using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public List<GameObject> travelPoints;
    public int travelPointIndex;

    public float baseSpeed = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        //takes current position and determines a vector3 between current position
        //and currently selected patrolpoint from index it then moves there at patrol
        //speed over the course of Time.deltaTime to spread it over multiple frames
        transform.position = Vector2.MoveTowards(transform.position, travelPoints[travelPointIndex].transform.position, baseSpeed * Time.deltaTime);


    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == travelPoints[travelPointIndex])

        {
            // takes current patrolpoint from index and adds one (changing to next one)
            // function then divides by number of points (4) gets the remainder to for total count this will automatically set make a loop for patroling
            travelPointIndex = (travelPointIndex + 1) % travelPoints.Count;
        }

    }





}
