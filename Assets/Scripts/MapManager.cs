using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor; 

public class MapManager : MonoBehaviour
{
    private static MapManager _instance; 
    public static MapManager Instance { get { return _instance; } }

    private Tilemap grid;
    public List<TileData> tileData;
    private Dictionary<TileBase, TileData> dataFromTiles; 

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject); 
        } 
        else
        {
            _instance = this; 
        }

        grid = GetComponent<Tilemap>();
        tileData = new List<TileData>();
        tileData.Add((TileData)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/ScriptableObjects/Tiles/WoodTileData.asset", typeof(TileData))); 
        dataFromTiles = new Dictionary<TileBase, TileData>(); 
    }

    private void Start()
    {
        //foreach (var tile_data in tileData)
        //{
        //    foreach (var tile in tile_data.tiles)
        //    {
        //        dataFromTiles.Add(tile, tile_data);
        //    }
        //}
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }

    private void PickTile()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        TileBase clickedTile = grid.GetTile(gridPosition);

        TileData.TileType type = dataFromTiles[clickedTile].type;
    }
}
