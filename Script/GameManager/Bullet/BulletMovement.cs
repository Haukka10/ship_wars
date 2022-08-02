using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Contriller;

namespace Bullet.Manager.movement
{
    public class BulletMovement : MonoBehaviour
    {
        public float Speed;
        public Rigidbody rb;
        private Player.Contriller.ControllerPlayer ConntrolerPlayer;
        private EnemySystem.Controller.ControllerEnemy ConntrolerEnemy;
        private byte a;
        private int TimeLive;
        private void Awake()
        {
            Speed = 200;
            TimeLive = 5;
            ConntrolerPlayer = FindObjectOfType<Player.Contriller.ControllerPlayer>();
            ConntrolerEnemy = FindObjectOfType<EnemySystem.Controller.ControllerEnemy>();
            a = ConntrolerPlayer.i;
        }
        
        private void Update()
        {
            //move bullet and destroy tihis 
            Destroy(gameObject, TimeLive);
            Move();
        }
        /// <summary>
        /// Move bullet
        /// </summary>
        private void Move()
        {
            rb.velocity = transform.right * Speed * Time.fixedDeltaTime;

            if (a == 1)
                rb.velocity = -transform.right * Speed * Time.fixedDeltaTime;
        }
        private void OnCollisionEnter(Collision collision)
        {
            //Destory bullet
            Destroy(gameObject);
        }
    }
}
