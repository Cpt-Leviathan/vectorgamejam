using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager 
{

    private static RoomManager instance = null;

    private RoomManager()
    {
    }

    public static RoomManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new RoomManager();
            }
            return instance;
        }
    }

    public void init()
    {


    }

    public void Update()
    {


    }

    public void FixedUpdate()
    {


    }

}
