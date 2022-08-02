using UnityEngine;
using EnemySystem.Controller;


namespace EnemySystem.counter
{
    public class EnemyCounter : MonoBehaviour 
    {
        private EnemySystem.Spawn.EnemySpawn EnemySpawn;

        [Header("Ammout of enemy")]
        public GameObject[] EnemyC;

        public int CurrentAmmoutOfEnemy;
        public int MaxAmmoutEnemy;

        private void Awake()
        {
            try
            {
                EnemyC.Clone();
                EnemySpawn = FindObjectOfType<EnemySystem.Spawn.EnemySpawn>();
                EnemyC = GameObject.FindGameObjectsWithTag("Enemy");
                CurrentAmmoutOfEnemy = EnemyC.Length;
                MaxAmmoutEnemy = EnemyC.Length;
            }
            catch (System.Exception)
            {
                Debug.LogWarning("Not find EnemySpawn");
                throw;
            }
        }

        private void LateUpdate() => ChekEntity();

        /// <summary>
        /// Find new enemy and add to list 
        /// </summary>
        public void Find() => EnemyC = GameObject.FindGameObjectsWithTag("Enemy");

        public void RomveEnemy()
        {
            EnemyC.Clone();
            EnemyC = GameObject.FindGameObjectsWithTag("Enemy");
            CurrentAmmoutOfEnemy = EnemyC.Length;
        }

        /// <summary>
        /// Chek entity to spawn new entity 
        /// </summary>
        float t;
        public void ChekEntity()
        {
            if(CurrentAmmoutOfEnemy == 0)
            {
                t = Time.fixedTime;

                if (t < 1.5f)
                    return;

                t = 0;

                for (int i = 0; i < 5; i++)
                    EnemySpawn.Spawn();

                CurrentAmmoutOfEnemy = EnemyC.Length;
                MaxAmmoutEnemy = EnemyC.Length;
            }

            if (CurrentAmmoutOfEnemy < MaxAmmoutEnemy)
                EnemySpawn.Spawn();

            Find();
            CurrentAmmoutOfEnemy = EnemyC.Length;
        }
    }
}