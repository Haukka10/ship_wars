using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ItemCreate
{
    //Create item in Unity 
    [CreateAssetMenu(fileName = "ItemScriptable", menuName = "Add new Item", order = 1)]
    public class ItemSpawn : ScriptableObject
    {
        public string Name;
        public double Cost;
        public int id = 0;
        public Sprite icon = null;
        [Header("S")]
        public float Damage;
        public float HP;
        public float BuffSpeedBulet;
        public float Speed;
        public Types _Types;
        public rank Rank;

        [System.Flags]
        public enum Types
        {
            None = 0,
            BuffDamage = 1,
            BuffHP = 2,
            BuffSpeedBulet = 3,
            BuffSpeed = 4,
            BuffROF = 5,
            BuffEnemySpeed = 6
        }
        [System.Flags]
        public enum rank
        {
            Common = 0,
            Uncommon = 1,
            Rare = 2,
            Epic = 3,
            Legendary = 4
        }
    }
}
