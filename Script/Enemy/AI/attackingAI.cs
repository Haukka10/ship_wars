using UnityEngine;
using EnemySystem.Conntrolera;

namespace EnemySystem.Controller.attacking
{
    public class attackingAI : ControllerEnemy
    {
        [SerializeField]
        private Player.Contriller.ControllerPlayer ControllerPlayer;
        [SerializeField]
        private EnemySystem.counter.EnemyCounter EnemyCounter;
        public float DamageEnemy;
        private void Awake()
        {
            EnemyCounter = FindObjectOfType<EnemySystem.counter.EnemyCounter>();
            ControllerPlayer = FindObjectOfType<Player.Contriller.ControllerPlayer>();
            
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "Player")
                Attak();
        }
        private void Attak()
        {
            float a = ControllerPlayer.Armor;
            switch (a)
            {
                case 0:
                    ControllerPlayer.TakeDamage(Mathf.Floor(DamageEnemy));
                    break;
                default:
                    ControllerPlayer.TakeDamage(Mathf.Floor(DamageEnemy / Mathf.Floor(ControllerPlayer.Armor)));
                    break;
            }

            if (EnemyCounter.MaxAmmoutEnemy != 255)
                EnemyCounter.MaxAmmoutEnemy++;

            Destroy(gameObject);
        }
    }
}