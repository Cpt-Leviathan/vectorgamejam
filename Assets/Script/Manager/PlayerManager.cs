using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager 
{
    private static PlayerManager instance = null;

    private PlayerManager()
    {
    }

    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerManager();
            }
            return instance;
        }
    }

    public void init()
    {


    }

    public void Update() {


    }

    public void FixedUpdate() {


    }


        
}
