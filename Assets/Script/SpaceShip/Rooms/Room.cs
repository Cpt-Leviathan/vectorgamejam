using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    Tilemap tilemap;
    List<Tiles> tileList;

    BoundsInt bounds;
    TileBase[] allTiles;

    public void init()
    {
        tilemap = GetComponent<Tilemap>();

        bounds = tilemap.cellBounds;
        allTiles = tilemap.GetTilesBlock(bounds);
        tileList = new List<Tiles>();

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    Tiles t = new Tiles();
                    t.init(tile);
                    //tilemap.GetTile();
                    //tilemap.Tile();
                    tileList.Add(t);

                   // Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                }
                else
                {
                    //Debug.Log("x:" + x + " y:" + y + " tile: (null)");
                }
            }
        }
    }

    public void destroyRoom()
    {
        int RoomsDestroyed = Random.Range(1,5);

        for (int i = 0; i < RoomsDestroyed; i++)
        {
            if (tileList.Count < 1)
            {
                Debug.Log("not working");
            }
            else
            {
                Debug.Log(tileList[/*RandomTile(tileList.Count-1)*/0]);
                tileList[/*RandomTile(tileList.Count-1)*/0].damageTile();
            }
            
        }
    }

    int RandomTile(int bound)
    {
        return (int)Random.Range(0, bound);
    }
}
