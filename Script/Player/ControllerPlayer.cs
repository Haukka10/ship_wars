using UnityEngine;
using TMPro;


namespace Player.Contriller
{
    public class ControllerPlayer : MonoBehaviour
    {
        private Bullet.Manager.BulletManager Shooting;
        private Bullet.Manager.movement.BulletMovement BulletMovement;
        private InvetorySystem.Invetory Invetory;

        private const float ToNowLevel = 100;
        private readonly byte MaxLevel = 10;
        private float DamageWithOutBuff;
        private float HPWithInBuff;
        private float SpeedWithOutBuff;
        private float _currentEXP;
        private float hp;

        public float CurrentEXP
        {
            get
            {
                return _currentEXP;
            }
            set
            {
                _currentEXP = value;
            }
        }

        [SerializeField]
        private Player.MovementPlayer Movementplayer;
        [SerializeField]
        private TextMeshProUGUI text;
        [HideInInspector]
        public byte i = 0;
        [HideInInspector]
        public bool a = false;

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

        [Header("Status Player")]
        public float MaxHP;
        public double Damage;
        public byte CurrentLevel = 1;
        public float Armor;
        public float Money;
        public GameObject death;

        private void Awake()
        {
            //set damage and HP
            HP = MaxHP;
            HPWithInBuff = MaxHP;
            DamageWithOutBuff = (float)Damage;
            Damage = DamageWithOutBuff;
            SpeedWithOutBuff = Movementplayer.Speed;
            //find scripts 
            Invetory = FindObjectOfType<InvetorySystem.Invetory>();
            Shooting = FindObjectOfType<Bullet.Manager.BulletManager>();
            BulletMovement = FindObjectOfType<Bullet.Manager.movement.BulletMovement>();
            gameObject.transform.position = new Vector3(0,0, 0);
        }
        private void Update()
        {
           if (CurrentLevel > 1)
           text.text = string.Empty;
           else
           text.text = "Level: " + CurrentLevel.ToString();

            if (!Invetory.IsOpen)
                if (Input.GetButtonDown("Fire1"))
                {
                    switch (a)
                    {
                        case true:
                            i = 1;
                            a = false;
                            Shooting.Attacking(i);
                            break;
                        default:
                            i = 0;
                            a = true;
                            Shooting.Attacking(i);
                            break;
                    }
                }
            CheckLevel();
        }
        
        /// <summary>
        /// check level if is not max level have's 
        /// </summary>
        private void CheckLevel()
        {
            if (CurrentLevel != MaxLevel)
            {
                if (CurrentEXP >= ToNowLevel)
                {
                    //add 10 HP and set current EXP to 0 
                    MaxHP = MaxHP + 10;
                    CurrentLevel++;
                    CurrentEXP = 0;
                    Damage = Damage + (float)1.5;
                    Debug.Log("Add level " + CurrentLevel + " Left to level " + CurrentEXP + " And to do new level is " + ToNowLevel);
                }
            }
            else
                Debug.Log("Level Max");
        }
        public void TakeDamage(float Damege)
        {
            HP -= Damege;
            Debug.Log(HP);
            if (HP <= 0)
            {
                death.SetActive(true);
                Invetory.Items.Clear();
                Time.timeScale = 0f;
                gameObject.transform.position = new Vector3(0,0, 0);
            }
        }
        //Add damage buff 
        public void SetBuff(int DamageBuff) => Damage += DamageBuff;
        // add HP buff
        public double SetHP(float Hp) => MaxHP += Hp;
        // add Speed Bullet buff 
        public double SetSpeedBulle(float Speed) => Speed * BulletMovement.Speed;
        public double SetSpeed(float SpeedM) => SpeedM * Movementplayer.Speed;
        public void SetDef()
        {
            //set to def hp and damage and speed 
            DamageWithOutBuff = ((float)Damage);
            HPWithInBuff = HP;
            HP = HPWithInBuff;
            Damage = DamageWithOutBuff;
            Movementplayer.Speed = SpeedWithOutBuff;
        }
    }
}
