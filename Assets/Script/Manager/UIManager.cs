using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager 
{

    private static UIManager instance = null;

    private UIManager()
    {
    }

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
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
