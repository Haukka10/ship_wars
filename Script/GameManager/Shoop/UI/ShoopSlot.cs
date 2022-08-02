using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Shoop.Manager.Slot
{
    public class ShoopSlot : MonoBehaviour
    {
        [SerializeField]
        private Image Image;
        [SerializeField]
        private TextMeshProUGUI text;
        public Player.Contriller.ControllerPlayer ConntrolerPlayer;
        private float Cost;

        public ItemCreate.ItemSpawn ItemSpawn;
        private InvetorySystem.Invetory Invetory;
        private InvetorySystem.Slot.invetorySlot invetorySlot;
        private Shoop.Manager.ShoopManager Shoopmanager;
        private GameManager GameManager;
        private void Awake()
        {
            Invetory = FindObjectOfType<InvetorySystem.Invetory>();
            invetorySlot = FindObjectOfType<InvetorySystem.Slot.invetorySlot>();
            Shoopmanager = FindObjectOfType<Shoop.Manager.ShoopManager>();
            GameManager = FindObjectOfType<GameManager>();
        }

        public void AddItemToShoop(ItemCreate.ItemSpawn NewItemSpawn)
        {
            //add item to eq
            ItemSpawn = NewItemSpawn;
            Image.sprite = NewItemSpawn.icon;
            Cost = (float)ItemSpawn.Cost;
            text.text = Cost.ToString();
        }

        public void BuyItem()
        {
           int a = Random.Range(0, GameManager.BackUPItems.Length);
            if (ItemSpawn.Cost <= ConntrolerPlayer.Money)
                if (Invetory.Items.Count != 3)
                {
                    Invetory.Items.Add(ItemSpawn);
                    ConntrolerPlayer.Money -= (float)ItemSpawn.Cost;
                    Shoopmanager.AllItems.Add(GameManager.BackUPItems[a]);

                    Debug.Log("Add item of id>>  " + a + " Name>> " + ItemSpawn.Name);
                    switch (ItemSpawn._Types)
                    {
                        case ItemCreate.ItemSpawn.Types.BuffDamage:
                            ConntrolerPlayer.SetBuff(((int)ItemSpawn.Damage));
                            invetorySlot.a = true;
                            break;
                        case ItemCreate.ItemSpawn.Types.BuffHP:
                            ConntrolerPlayer.SetHP(ItemSpawn.HP);
                            invetorySlot.a = true;
                            break;
                        case ItemCreate.ItemSpawn.Types.BuffSpeed:
                            invetorySlot.a = true;
                            ConntrolerPlayer.SetSpeed(ItemSpawn.Speed);
                            break;
                        case ItemCreate.ItemSpawn.Types.BuffSpeedBulet:
                            invetorySlot.a = true;
                            ConntrolerPlayer.SetSpeedBulle(ItemSpawn.BuffSpeedBulet);
                            break;
                        case ItemCreate.ItemSpawn.Types.BuffEnemySpeed:
                            break;
                        default:
                            break;
                    }
                    
                    DropItemFromShoop();
                }
        }

        public void DropItemFromShoop()
        {
            //check is damage buff
            text.text = ItemSpawn.Cost.ToString();
            Shoopmanager.AllItems.Remove(ItemSpawn);
            Image.sprite = null;
            ItemSpawn = null;
        }
        public void SellItem()
        {
            int a = Mathf.CeilToInt((float)ItemSpawn.Cost);

            ConntrolerPlayer.Money += a;
            invetorySlot.DropItem();
        }
    }
}
