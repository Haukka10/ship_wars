using UnityEngine;

namespace EnemySystem.Controller
{
    public class ControllerEnemy : MonoBehaviour
    {
        private bool isarmor;
        private float armor;
        private float maxHP;
        private float _damageEnemy;
        private float hp;
        private float getexp;
        public float HP
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
            }
        }
        public bool IsArmor
        {
            get
            {
                return isarmor;
            }
            set
            {
                isarmor = value;
                Debug.Log("Armor is " + value);
            }
        }
        public float ArmorValue
        {
            get
            {
                return armor;
            }
            set
            {
                armor = value;
            }
        }
        public float MaxHP
        {
            get
            {
                return maxHP;
            }
            set
            {
                maxHP = value;
            }
        }

        public float GetExp
        {
            get
            {
                return getexp;
            }
            set
            {
                getexp = value;
            }
        }

        public void Setup()
        {
           GetExp = 0.5F;
           MaxHP = 15;
           HP = MaxHP;
           Debug.Log("MaxHP " + MaxHP + "hp "+ HP);

           if (IsArmor)
               MaxHP = 25;
        }
    }
}