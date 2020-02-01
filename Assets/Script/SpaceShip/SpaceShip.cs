using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip
{
    List<Room> mySpaceShip;
    float nextTime;
    float modifier;
    float minTime = 15;
    float maxTime = 40;

    public void init()
    {
        mySpaceShip = new List<Room>();
        nextTime = 0.0f;
        modifier = Random.Range(minTime, maxTime);
        nextTime = Time.time + modifier;
        mySpaceShip.AddRange(Object.FindObjectsOfType<Room>());
        
    }

    public void UpToDate()
    {
        if (mySpaceShip.Count > 0)
        {
            if (Time.time > nextTime)
            {
                mySpaceShip[Random.Range(0, mySpaceShip.Count)].destroyRoom();
                modifier = Random.Range(minTime, maxTime);
                nextTime = Time.time + modifier;
            }
        }
        

    }
}
