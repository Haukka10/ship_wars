using UnityEngine;
using EnemySystem.Controller;

namespace EnemySystem.Conntrolera.Ranks
{
    public class ControllerRanks : ControllerEnemy
    {
        private Controller.attacking.attackingAI attacking;
        Ranks ranks = 0;
        public enum Ranks
        {
            //set rank to enemy each rank give buff and debuff 
            Common = 0,
            Rare = 1,
            ArmorEnemy = 2,
        }
        private void Start()
        {
            attacking = FindObjectOfType<Controller.attacking.attackingAI>();
            int a = Random.Range(0, 2);
            ranks = (Ranks)a;

            RanksSet();
            Debug.Log("Rank " + ranks);
        }
        /// <summary>
        /// Set Ranks enemy 
        /// </summary>
        private void RanksSet()
        {
            switch (ranks)
            {
                case Ranks.Common:
                    break;
                case Ranks.Rare:
                    float addDamage = attacking.DamageEnemy * 0.35f;
                    attacking.DamageEnemy += Mathf.Floor(addDamage);
                    float AddHP = ((float)MaxHP) * 0.25f;
                    MaxHP += Mathf.Floor(AddHP);
                    IsArmor = false;
                    ArmorValue = 0;
                    break;
                case Ranks.ArmorEnemy:
                    IsArmor = true;
                    attacking.DamageEnemy *= 2;
                    MaxHP = MaxHP / 0.10f;
                    ArmorValue = 0.15f;
                    break;
            }
        }
    }
}