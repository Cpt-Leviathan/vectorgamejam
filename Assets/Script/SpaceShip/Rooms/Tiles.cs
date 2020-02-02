﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tiles
{
    bool isDamaged;
    Vector2Int pos;
    TileBase texture;
    public List<RequireListTool> repairList;
    Room parent;
    GameObject particleEffects;

    public void init(TileBase tb, Room _parent, Vector2Int v2)
    {
        isDamaged = false;
        texture = tb;
        pos = v2;
        repairList = new List<RequireListTool>();
        parent = _parent;
    }

    public void damageTile()
    {
        List<RequireListTool> tempList = RepairList.generateListOrders((int)Random.Range(0, 6));
        foreach (RequireListTool rlt in tempList)
        {
            repairList.Add(rlt);
        }
        isDamaged = true;
    }

    public void repairTile(RequireListTool tool)
    {
        if (repairList.Count > 0)
            if (repairList[0] == tool)
            {
                SpaceShipManager.Instance.krina.RemoveOxygeneLost();
                repairList.RemoveAt(0);
                parent.tilemap.SetTile((Vector3Int)pos, Resources.Load<TileBase>("Tiles/tool_tiles/Tile_" + repairList[0]));
                parent.tilemap.RefreshTile((Vector3Int)pos);

                switch (tool)
                {
                    case RequireListTool.Hammer:
                        
                        GameObject go = GameObject.Instantiate(Resources.Load("Prefabs/Spark_Particle"), parent.tilemap.CellToWorld((Vector3Int)pos), Quaternion.identity) as GameObject;
                        GameObject.Destroy(go, 10);

                        break;
                    case RequireListTool.Extincteur:
                        break;
                    case RequireListTool.Welder:
                        break;
                    case RequireListTool.Wrench:
                        break;
                    default:
                        break;
                }
            }
        checkTile();
    }

    public void checkTile()
    {
        if (repairList.Count < 1)
        {
            isDamaged = false;
            SpaceShipManager.Instance.krina.AddOxygene(2);
            parent.tilemap.SetTile((Vector3Int)pos, texture);
            parent.tilemap.RefreshTile((Vector3Int)pos);
            Debug.Log("checking");
        }
    }

    public void setPos(Vector2Int v)
    {
        pos = v;
    }

    public bool getIsDamaged()
    {
        return isDamaged;
    }
}
