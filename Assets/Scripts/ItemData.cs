using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Data")]
public class ItemData : ScriptableObject
{
    public string id;
    public string displayName;
    public Sprite icon;
    public Sprite prefab;
    public Type type; 

    public enum Type
    {
        Weapon, 
        Tool,
        Food
    }
}
