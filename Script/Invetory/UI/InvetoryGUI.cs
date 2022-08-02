using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InvetorySystem.UI
{
    public class InvetoryGUI : MonoBehaviour
    {
        private InvetorySystem.Slot.invetorySlot[] Slots;
        private InvetorySystem.Invetory Invetory;
        private NB.GetItem Building;
        public Transform Item;

        private void Start()
        {
            Slots = Item.GetComponentsInChildren<InvetorySystem.Slot.invetorySlot>();
            Invetory = FindObjectOfType<InvetorySystem.Invetory>();
            Building = FindObjectOfType<NB.GetItem>();
        }
        public void UpdateUI()
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                //check count itme and block pick up item if count is 3 
                    if (i < Invetory.Items.Count)
                    {
                        //add item to eq 
                        Slots[i].AddItem(Invetory.Items[i]);

                    }
                    else if(i > Invetory.Items.Count)
                    {
                        Slots[i].DropItem();
                    }
            }
        }
    }
}
