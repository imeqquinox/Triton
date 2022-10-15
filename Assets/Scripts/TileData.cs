using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileData : ScriptableObject
{
    public TileBase[] tiles { get; private set; }
    public TileType type { get; private set; }

    private float destructionTime = 0f; 

    public enum TileType
    {
        Wood,
        Grass,
        Stone
    }

    private void Awake()
    {
        switch (type)
        {
            case TileType.Wood:
                destructionTime = Random.Range(1.5f, 3f);
                break;

            case TileType.Grass:
                destructionTime = Random.Range(1f, 2f);
                break;

            case TileType.Stone:
                destructionTime = Random.Range(4f, 7f);
                break;

            default:
                destructionTime = 5f; 
                break; 
        }
    }
}
