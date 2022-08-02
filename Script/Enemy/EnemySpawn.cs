using UnityEngine;

namespace EnemySystem.Spawn
{
    public class EnemySpawn : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField]
        private GameObject SpawnPosition;
        [SerializeField]
        private GameObject EnemyEntity;
        [SerializeField]
        private EnemySystem.counter.EnemyCounter EnemyCounter;

        public GameManager GameManager;
        public GameObject[] TypeEnemy;
        private int e;

        public void Spawn()
        {
            int a = Random.Range(0, TypeEnemy.Length);
            EnemyEntity = TypeEnemy[a];

            EnemyEntity.name = "Enemy " + e++;

            //add random Pos to z and x 
            float Z = Random.Range(GameManager.instance.Player.transform.position.z * 10, GameManager.instance.Player.transform.position.z * 12.2f);
            float X = Random.Range(GameManager.instance.Player.transform.position.x * 10, GameManager.instance.Player.transform.position.x * 12.2f);

            // Spawn random Pos enemy 
            SpawnPosition.transform.position = new Vector3(X, 0, Z);
            // Spawn Enemy 
             Instantiate(EnemyEntity,SpawnPosition.transform.position,Quaternion.identity);
            //find new enemy 
            EnemyCounter.Find();
            Debug.Log("Enemy Spawn on  " + EnemyEntity.transform.position);
            
        }
    }
}
