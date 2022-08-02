using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InvetorySystem.Slot
{
    public class invetorySlot : MonoBehaviour
    {
        [SerializeField]
        private Image Image;
        [SerializeField]
        private Button Button;
        private InvetorySystem.Invetory Invetory;
        [SerializeField]
        private ItemCreate.ItemSpawn ItemSpawn;
        private Player.Contriller.ControllerPlayer ConntrolerPlayer;
        public bool a = false;

        private void Start()
        {
            Button.gameObject.SetActive(false);
            Invetory = FindObjectOfType<InvetorySystem.Invetory>();
            ConntrolerPlayer = FindObjectOfType<Player.Contriller.ControllerPlayer>();
        }
        public void AddItem(ItemCreate.ItemSpawn NewItemSpawn)
        {
            switch (NewItemSpawn._Types)
            {
                case ItemCreate.ItemSpawn.Types.BuffDamage:
                    a = true;
                    break;
                default:
                    a = false;
                    break;
            }
            //add item to eq
            Button.gameObject.SetActive(true);
            ItemSpawn = NewItemSpawn;
            Image.sprite = NewItemSpawn.icon;
        }

        public void DropItem()
        {
            //check is damage buff 
            if (a)
            {
                ConntrolerPlayer.SetDef();
                Debug.Log(a);
                Button.gameObject.SetActive(false);
                Image.sprite = null;
                Invetory.Items.Remove(ItemSpawn);
                ItemSpawn = null;
                Debug.Log("Drop Item Def");
            }
            else
            {
                //delet item
                Button.gameObject.SetActive(false);
                Image.sprite = null;
                Invetory.Items.Remove(ItemSpawn);
                ItemSpawn = null;
            }
        }
    }
}
