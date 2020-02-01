using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager 
{
    private static PlayerManager instance = null;
    private Player player;

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
        player = new Player();
        player.InitPlayer();

    }

    public void Update() {
        player.UpdatePlayer();

    }

    public void FixedUpdate() {
        player.FixedUpdatePlayer();

    }


        
}
