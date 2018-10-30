using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRobot : MonoBehaviour {

    [SerializeField] GameObject patrolBot;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] Transform currentDest;
    [SerializeField] Transform[] destinations;
    [SerializeField] int destSelect;

	// Use this for initialization
	void Start () 
    {
        currentDest = destinations[destSelect];
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (patrolBot != null)
        {
            patrolBot.transform.position = Vector2.MoveTowards(patrolBot.transform.position, currentDest.position, moveSpeed * Time.deltaTime);

            if (patrolBot.transform.position == currentDest.position)
            {
                destSelect++;

                if (destSelect == destinations.Length)
                {
                    destSelect = 0;
                }

                currentDest = destinations[destSelect];
            }
        }
	}
}
