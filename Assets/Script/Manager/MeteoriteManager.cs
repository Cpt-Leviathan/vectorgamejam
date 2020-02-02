using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteManager 
{
    private static MeteoriteManager instance = null;

    private MeteoriteManager()
    {
    }

    public static MeteoriteManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MeteoriteManager();
            }
            return instance;
        }
    }

    List<GameObject> meteorites;

    public void init()
    {
        meteorites = new List<GameObject>();

    }

    public void Update() {


        foreach (GameObject go in meteorites)
        {
            go.transform.position += go.transform.right;
        }


    }

    public void FixedUpdate() {

    }


        
}
