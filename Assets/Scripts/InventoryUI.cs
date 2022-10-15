using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject itemFrame;
    [SerializeField] private GameObject uiParent; 
    [SerializeField] private Transform uiSpawnPoint; 

    private Inventory playerInventory;

    private void Start()
    {
        playerInventory = GetComponentInParent<PlayerController>().inventory;

        for (int i = 0; i < playerInventory.items.Count; i++)
        {
            var uiItem = Instantiate(itemFrame, uiSpawnPoint.position, Quaternion.identity, uiParent.transform);
            uiItem.GetComponent<Image>().sprite = playerInventory.items[i].data.icon;
            uiSpawnPoint.position = uiSpawnPoint.position + new Vector3(100f, 0f, 0f); 
        }
    }
}
