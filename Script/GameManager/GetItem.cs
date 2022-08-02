using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NB
{
    public class GetItem : MonoBehaviour
    {
        public ItemCreate.ItemSpawn ItemSpawn;
        
        private InvetorySystem.Invetory Invetory;
        private InvetorySystem.UI.InvetoryGUI InvetoryUI;
        private Player.Contriller.ControllerPlayer ConntrolerPlayer;
        [SerializeField]
        private InvetorySystem.Slot.invetorySlot invetorySlot;
        [SerializeField]
        private notificationItme NotificationItme;

        private void Start()
        {
            // find script
            invetorySlot = FindObjectOfType<InvetorySystem.Slot.invetorySlot>();
            InvetoryUI = FindObjectOfType<InvetorySystem.UI.InvetoryGUI>();
            Invetory = FindObjectOfType<InvetorySystem.Invetory>();
            ConntrolerPlayer = FindObjectOfType<Player.Contriller.ControllerPlayer>();
            NotificationItme = FindObjectOfType<notificationItme>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                    //check Space in invetory 
                    if(Invetory.Items.Count == 3)
                    {
                        Debug.Log("Max");
                    }
                    else
                    {
                        //add item and destory gameObject
                        Invetory.Items.Add(ItemSpawn);
                        // Check name if not empty 
                        if(ItemSpawn.Name != string.Empty)
                            NotificationItme.NotificationText = ItemSpawn.Name;

                        Destroy(gameObject);
                    }
                    //UpdateUI
                    InvetoryUI.UpdateUI();
                
                switch (ItemSpawn._Types)
                {

                    case ItemCreate.ItemSpawn.Types.BuffDamage:
                        ConntrolerPlayer.SetBuff((int)ItemSpawn.Damage);
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
            }
        }
    }
}
