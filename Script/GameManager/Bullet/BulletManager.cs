using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bullet.Manager
{
    public class BulletManager : MonoBehaviour
    {

        [SerializeField]
        private GameObject Bullet;
        [SerializeField]
        private Transform[] ShootPos;

        private Bullet.Manager.movement.BulletMovement BulletMovement;
        private EnemySystem.Controller.ControllerEnemy ConntrolerEnemy;
        private Player.Contriller.ControllerPlayer ConntrolerPlayer;

        public float StartTimeLive;
        public float TimeLive;
        public Vector3 move;

        private void Awake()
        {
            TimeLive = 2;
            StartTimeLive = 2;
            ConntrolerEnemy = FindObjectOfType<EnemySystem.Controller.ControllerEnemy>();
            ConntrolerPlayer = FindObjectOfType<Player.Contriller.ControllerPlayer>();
        }

        public void Update()
        {
            //get vector3
            move = GameManager.instance.Player.transform.position;

            TimeLive = TimeLive - Time.deltaTime;

            if (TimeLive >= 0)
                TimeLive = StartTimeLive;
        }

        public void Attacking(int a)
        {
            //Spawn bullet
            Instantiate(Bullet, ShootPos[a].transform.position ,Quaternion.identity);
        }
    }
}
