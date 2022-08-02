using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace EnemySystem.AI
{
    public class EnemyAI : MonoBehaviour
    {
        [Header("AI")]
        [SerializeField]
        private NavMeshAgent agent;
        [SerializeField]
        public float Speed;
        public float SpeedShooting;
        public bool isNotFire;
        private float FOR = 0.15f;
        private int CurrentBullet;

        private EnemySystem.counter.EnemyCounter EnemyCounter;
        private EnemySystem.Controller.ControllerEnemy controllerEnemy;

        private Transform Taget;
        [SerializeField]
        private GameObject Bullet;
        [SerializeField]
        private Transform Pot;


        void Start()
        {
            agent.autoBraking = true;
            //AI
            try
            {
                Taget = GameManager.instance.Player.transform;
            }
            catch (System.Exception)
            {
                Debug.LogError("Taget not find");
                Taget = FindObjectOfType<Player.Contriller.ControllerPlayer>().transform;
                throw;
            }
            //Script
            controllerEnemy = FindObjectOfType<EnemySystem.Controller.ControllerEnemy>();
            EnemyCounter = FindObjectOfType<EnemySystem.counter.EnemyCounter>();
            //Speed and cunter 
            Speed = 2f;
            EnemyCounter.CurrentAmmoutOfEnemy = EnemyCounter.EnemyC.Length;
            agent.speed = Speed;
            controllerEnemy.ArmorValue = Random.Range(0.05f, 0.25f);
        }

        private void Update()
        {
            CheckAI();

            if(!isNotFire)
            if (CurrentBullet < 20)
                Fire();
        }

        private void Fire()
        {
            if(Time.time > FOR)
            {
                //spawn bullet
                Instantiate(Bullet, Pot.transform.position,Quaternion.identity);
                //add name 
                Bullet.name = "Bullet Enemy";
                FOR = Time.time + SpeedShooting + 0.20f;
            }
        }

        /// <summary>
        /// choice type AI
        /// </summary>
        private void CheckAI()
        {
            if (isNotFire == false)
            {
                controllerEnemy.MaxHP = 15;

                agent.SetDestination(-Taget.position);
            }
            else
                agent.SetDestination(Taget.position);
        }
    }
}