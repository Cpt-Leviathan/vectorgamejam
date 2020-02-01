using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Tool[] tools;
    private int activeTool;
    public void InitPlayer()
    {
        activeTool = 0;
    }

    public void UpdatePlayer()
    {
        if (InputManager.GetKeysInput().tool1Pressed)
            activeTool = 0;
        if (InputManager.GetKeysInput().tool2Pressed)
            activeTool = 1;
        if (InputManager.GetKeysInput().tool3Pressed)
            activeTool = 2;
        if (InputManager.GetKeysInput().tool4Pressed)
            activeTool = 3;

        if (InputManager.GetKeysInput().F)
            print("f");
            //Interact();
    }

    public void FixedUpdatePlayer()
    {
        
    }

    public void Interact()
    {

    }
}
