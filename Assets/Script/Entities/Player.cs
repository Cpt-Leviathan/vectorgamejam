using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Tool> tools;
    private int activeTool;
    private float x, y;
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    public void InitPlayer()
    {
        //speed = 2;

        activeTool = 0;
        tools = new List<Tool>();
        for(int i = 0; i < 4; i++)
        {
            tools.Add(new Tool());
        }

        tools[0].InitTool(RequireListTool.Hammer, 100, 0);
        tools[1].InitTool(RequireListTool.Wrench, 100, 0);
        tools[2].InitTool(RequireListTool.Extincteur, 100, 10);
        tools[3].InitTool(RequireListTool.Welder, 100, 20);

        rb = GetComponent<Rigidbody2D>();

    }

    public void UpdatePlayer()
    {
        Move();

        SwitchTool();

        if (InputManager.GetKeysInput().F)
            //print("f");
            Interact();
    }

    public void FixedUpdatePlayer()
    {
        
    }

    public void Interact()
    {
        tools[activeTool].Use();
    }

    private void Move()
    {
        Vector2 dir = new Vector2(0,0);

        if (InputManager.GetKeysInput().W)
            dir += new Vector2(0, 1);

        if (InputManager.GetKeysInput().S)
            dir += new Vector2(0, -1);

        if (InputManager.GetKeysInput().A)
            dir += new Vector2(-1, 0);

        if (InputManager.GetKeysInput().D)
            dir += new Vector2(1, 0);

        rb.velocity = dir * speed;
    }

    private void SwitchTool()
    {
        if (InputManager.GetKeysInput().tool1Pressed)
        {
            print("Hammer");
            activeTool = 0;
        }
        if (InputManager.GetKeysInput().tool2Pressed)
        {
            print("Wrench");
            activeTool = 1;
        }
        if (InputManager.GetKeysInput().tool3Pressed)
        {
            print("Extincteur");
            activeTool = 2;
        }
        if (InputManager.GetKeysInput().tool4Pressed)
        {
            print("Welder");
            activeTool = 3;
        }
    }
}
