using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Shoop.Manager
{
    public class ShoopManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject GameObject;

        public List<ItemCreate.ItemSpawn> AllItems = new List<ItemCreate.ItemSpawn>();
        private Shoop.Manager.GUI.ShoopGUI ShoopGUI;
        private InvetorySystem.UI.InvetoryGUI InvetoryGUI;
        private GameManager GameManager;

        private void Awake()
        {
            ShoopGUI = FindObjectOfType<Shoop.Manager.GUI.ShoopGUI>();
            InvetoryGUI = FindObjectOfType<InvetorySystem.UI.InvetoryGUI>();
            GameManager = FindObjectOfType<GameManager>();
            GameManager.BackUPItems = AllItems.ToArray();
        }
        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (Input.GetButton("Invetory"))
                {
                    GameObject.SetActive(true);
                    Time.timeScale = 0.25f;
                    ShoopGUI.UpdateUI();
                    InvetoryGUI.UpdateUI();

                }
                else
                {
                    GameObject.SetActive(false);
                    Time.timeScale = 1.0f;
                }
            }else
                Time.timeScale = 1.0f;
            
            
        }

    }
}
