using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Diagnostics;


namespace Shoop.Manager.GUI
{
    public class ShoopGUI : MonoBehaviour
    {

        private Shoop.Manager.Slot.ShoopSlot[] Slots;
        private Shoop.Manager.ShoopManager ShoopManager;
        public Transform Transform;
        private int a;
        private void Awake()
        {
            Slots = Transform.GetComponentsInChildren<Shoop.Manager.Slot.ShoopSlot>();
            ShoopManager = FindObjectOfType<Shoop.Manager.ShoopManager>();
            a = Random.Range(0, ShoopManager.AllItems.Count);
        }
        public void UpdateUI()
        {
            if(a == ShoopManager.AllItems.Count)
            {
                a = Random.Range(0, ShoopManager.AllItems.Count);
            }

            for (int i = 0; i < Slots.Length; i++)
            {
                //check count itme and block pick up item if count is 3 
                if (i < ShoopManager.AllItems.Count)
                {
                    //add item to eq 
                    Slots[i].AddItemToShoop(ShoopManager.AllItems[a]);
                }
                else if (i > ShoopManager.AllItems.Count)
                {
                    Slots[i].DropItemFromShoop();
                }
            }
        }

    }
}
