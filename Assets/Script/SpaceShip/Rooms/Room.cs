using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    Tilemap tilemap;
    List<Tiles> tileList;

    BoundsInt bounds;
    public TileBase[] allTilesBases;
    public List<Tile> allTiles;

    public void init()
    {
        tilemap = GetComponent<Tilemap>();
        allTiles = new List<Tile>();

        bounds = tilemap.cellBounds;
        allTilesBases = tilemap.GetTilesBlock(bounds);

        foreach (TileBase t in allTilesBases)
        {
            allTiles.Add((t as Tile));

        }

        tileList = new List<Tiles>();

        int i = 0;
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTilesBases[x + y * bounds.size.x];
                Tile test = (tile as Tile);
                if (tile != null)
                {
                    Tiles t = new Tiles();
                    t.init(allTiles[i]);
                    
                    //tilemap.GetTile();
                    //tilemap.Tile();
                    tileList.Add(t);

                   // Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                }
                else
                {
                    //Debug.Log("x:" + x + " y:" + y + " tile: (null)");
                }
                i++;
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
