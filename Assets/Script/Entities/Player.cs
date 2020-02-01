using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    private List<Tool> tools;
    private int activeTool;
    private float x, y;
    [SerializeField] private float speed;
    public bool canRefill;
    private Rigidbody2D rb;
    GameObject cinemachine;
    GameObject minMap;

    public GridLayout gl;

    public void InitPlayer()
    {
        //speed = 2;

        cinemachine = GameObject.Instantiate(Resources.Load("Prefabs/CM vcam2", typeof(GameObject))) as GameObject;
        minMap = GameObject.Instantiate(Resources.Load("Prefabs/MiniMap", typeof(GameObject))) as GameObject;

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

        Vector3 temp = new Vector3(transform.position.x, transform.position.y, -12);
        cinemachine.transform.position = temp;

        Vector3 temp2 = new Vector3(transform.position.x, transform.position.y, -35);
        minMap.transform.position = temp2;



        SwitchTool();

        Interact();
    
    }

    public void FixedUpdatePlayer()
    {
        
    }

    public void Interact()
    {
        if (InputManager.GetKeysInput().F)
            if (canRefill)
                tools[activeTool].FillEnergy();
            else
            {
                List<Vector3Int> adjTiles = new List<Vector3Int>();
                RaycastHit2D hit;
                int layerMask = 1 << 9;
                hit = Physics2D.Raycast(transform.position, new Vector2(0, 0), Mathf.Infinity, layerMask);
                Room currentRoom = hit.transform.GetComponent<Room>();
                //adjTiles.Add(currentRoom.tilemap.WorldToCell(transform.position));

                for(int y =  -1; y < 2; y++)
                {
                    for(int x = -1; x < 2; x++)
                    {
                        adjTiles.Add(new Vector3Int(currentRoom.tilemap.WorldToCell(transform.position).x + x, currentRoom.tilemap.WorldToCell(transform.position).y + y, 0));
                    }
                }

                List<Tiles> tiles = new List<Tiles>();
                tiles.AddRange(currentRoom.tiles.Values);
                bool foundDamaged = false;
                for(int i = 0; i < tiles.Count && !foundDamaged; i++) {
                    Tiles t = tiles[i];

                    if (t.getIsDamaged()){
                        foundDamaged = true;
                        tools[activeTool].Use(t);
                    }
                }
            }
    }

    private void Move()
    {
        Vector2 dir = new Vector2(0,0);

        if (InputManager.GetKeysInput().W) {
            transform.localEulerAngles = new Vector3(0, 0, 0);
            dir += new Vector2(0, 1);
        }
        if (InputManager.GetKeysInput().S) {
            transform.localEulerAngles = new Vector3(0, 0, 180);
            dir += new Vector2(0, -1);
        }

        if (InputManager.GetKeysInput().A) {
            transform.localEulerAngles = new Vector3(0, 0, 90);
            dir += new Vector2(-1, 0);
        }

        if (InputManager.GetKeysInput().D) {
            transform.localEulerAngles = new Vector3(0, 0, -90);
            dir += new Vector2(1, 0);
        }



        rb.velocity = dir * speed;
    }

    private void RotatePlayer()
    {
        //left
        if (Input.GetAxis("Horizontal") > 0) {
            //transform.rotation = new Quaternion(0,-90,0,0);
            transform.eulerAngles = new Vector2(0, -90);
            //new Quaternion(0,90,0,0
        }
        //right
        if (Input.GetAxis("Horizontal") > 0) {
            //transform.rotation = new Quaternion(0, 90, 0, 0);
            transform.eulerAngles = new Vector2(0, 90);

        }
        //down
        if (Input.GetAxis("Vertical") < 0) {
            //transform.rotation = new Quaternion(0, 180, 0, 0);
            transform.eulerAngles = new Vector2(0, 180);

        }
        //up
        if (Input.GetAxis("Vertical") > 0) {
            //transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
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
