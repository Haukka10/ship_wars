using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InvetorySystem
{
    public class Invetory : MonoBehaviour
    {
        #region Singleton
        public static Invetory instance;
        private void Awake()
        {
            instance = this;
        }
        #endregion
        [Header("Item List")]
        public List<ItemCreate.ItemSpawn> Items = new List<ItemCreate.ItemSpawn>();

        [SerializeField]
        private GameObject VInvetory;
        public bool IsOpen;
        private void Start()
        {
            IsOpen = false;
            VInvetory.SetActive(false);
        }
        private void Update()
        {
            //open invetory
            if (Input.GetButtonDown("Invetory"))
            {
                IsOpen = true;
                VInvetory.SetActive(true);
                return;
            }else if (Input.GetButtonUp("Invetory"))
            {
                //close inventory
                IsOpen = false;
                VInvetory.SetActive(false);
                return;
            }
        }
    }
}
