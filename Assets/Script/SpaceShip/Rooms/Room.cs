using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    Tilemap tilemap;
    List<Tile> tileList;

    BoundsInt bounds;
    TileBase[] allTiles;

    public void init()
    {
        tilemap = GetComponent<Tilemap>();

        bounds = tilemap.cellBounds;
        allTiles = tilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    tileList[(x * bounds.size.y) + y].init(tile);
                    //Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
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
            tileList[(RandomTile(bounds.size.x) * bounds.size.y) + RandomTile(bounds.size.y)].damageTile();
        }
    }

    int RandomTile(int bound)
    {
        return (int)Random.Range(0, bound);
    }
}
