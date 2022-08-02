using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemySystem.AIBullet
{
    public class BulletAI : MonoBehaviour
    {
        [Header("Bullet AI")]
        [SerializeField]
        private NavMeshAgent agent;
        private Transform Taget;
        private Player.Contriller.ControllerPlayer ConntrolerPlayer;
        private EnemySystem.Controller.ControllerEnemy ConntrolerEnemy;
        private Controller.attacking.attackingAI attackingAI;

        private void Awake()
        {
            Taget = GameManager.instance.Player.transform;
            attackingAI = FindObjectOfType<Controller.attacking.attackingAI>();
            ConntrolerPlayer = FindObjectOfType<Player.Contriller.ControllerPlayer>();
            ConntrolerEnemy = FindObjectOfType<EnemySystem.Controller.ControllerEnemy>();
        }

        private void Update()
        {
            agent.SetDestination(Taget.position);
            Destroy(gameObject, 5f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                ConntrolerPlayer.TakeDamage(Mathf.RoundToInt(attackingAI.DamageEnemy));
                Destroy(gameObject);
            }
        }
    }
}