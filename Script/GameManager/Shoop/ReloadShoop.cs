using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadShoop : MonoBehaviour
{
    private GameManager gameManager;
    private Shoop.Manager.Slot.ShoopSlot ShoopSlot;
    private Shoop.Manager.ShoopManager ShoopManager;

    private void Awake() 
    {
        gameManager = FindObjectOfType<GameManager>();
        ShoopSlot = FindObjectOfType<Shoop.Manager.Slot.ShoopSlot>();
        ShoopManager= FindObjectOfType<Shoop.Manager.ShoopManager>();
    }
    public void Reload(int a)
    {
        for (int i = 0; i > ShoopManager.AllItems.Count; i++)
            a = Random.Range(0, gameManager.BackUPItems.Length);



        if (ShoopManager.AllItems.Count <= 1)
        {
            for (int i = 0; i < ShoopManager.AllItems.Count; i++)
                ShoopManager.AllItems.Add(gameManager.BackUPItems[i]);
        }

        ShoopSlot.AddItemToShoop(ShoopManager.AllItems[a]);
        ShoopSlot.DropItemFromShoop();
    }
}
