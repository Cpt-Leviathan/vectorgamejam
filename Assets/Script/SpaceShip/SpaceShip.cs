﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip
{
    const float OXYGENELOST = 0.5f;
    float oxygeneLostPerSeconds = 0;
    float oxygene = 100;
    float oxygeneSeconds = 1;
    float oxygeneTime;
    List<Room> mySpaceShip;
    float nextTime;
    float modifier;
    float minTime = 15;
    float maxTime = 45;


    public void init()
    {
        mySpaceShip = new List<Room>();
        nextTime = 0.0f;
        modifier = Random.Range(minTime, maxTime);
        nextTime = Time.time + modifier;
        mySpaceShip.AddRange(Object.FindObjectsOfType<Room>());

        foreach (Room r in mySpaceShip)
        {
            r.init();
        }
        
    }

    public void UpToDate()
    {
        if (mySpaceShip.Count > 0)
        {
            if (Time.time > nextTime)
            { int random = Random.Range(0, mySpaceShip.Count);

                oxygeneLostPerSeconds += random * OXYGENELOST;

                mySpaceShip[random].destroyRoom();
                modifier = Random.Range(minTime, maxTime);
                nextTime = Time.time + modifier;
            }
        }

        if (Input.GetKey(KeyCode.Space)) {
            int random = Random.Range(0, mySpaceShip.Count);
            oxygeneLostPerSeconds += random * OXYGENELOST;

            mySpaceShip[random].destroyRoom();
            modifier = Random.Range(minTime, maxTime);
            nextTime = Time.time + modifier;
        }

        if (Time.time > oxygeneTime && oxygeneLostPerSeconds > 0) {

            oxygene -= oxygeneLostPerSeconds;

            oxygeneTime = Time.time + oxygeneSeconds;

            UIManager.Instance.Oxygene(oxygene);

        }

    }

    public void RemoveOxygeneLost()
    {
        oxygeneLostPerSeconds -= OXYGENELOST;
    }

    public void AddOxygene(float lvl) {

        oxygene = +lvl;

        if (oxygene > 100)
            oxygene = 100;
    }
}
