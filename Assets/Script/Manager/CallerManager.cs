using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallerManager
{
    private static CallerManager instance = null;
    public Caller caller;

    private CallerManager()
    {
    }

    public static CallerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CallerManager();
            }
            return instance;
        }
    }

    public void init()
    {
        caller.Init();
    }

    public void Update()
    {
        caller.updateCaller();
    }
}
