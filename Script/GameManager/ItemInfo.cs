using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public ItemCreate.ItemSpawn ItemInfoSpwan;
    public ItemCreate.ItemSpawn ItemSpawn;


    private void Start()
    {
        ItemSpawn = ItemInfoSpwan;
    }
}