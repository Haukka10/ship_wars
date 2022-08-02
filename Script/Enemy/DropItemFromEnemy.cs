using UnityEngine;

public class DropItemFromEnemy : MonoBehaviour
{
    [SerializeField]
    private NB.GetItem GetItem;
    [SerializeField]
    private GameObject Item;
    private GameManager gameManager;

    public void SpawnItme(Vector3 PosSpawns)
    {
        GetItem.ItemSpawn = null;
        gameManager = FindObjectOfType<GameManager>();
        //Random index to sent item 
        int a = Random.Range(0, gameManager.BackUPItems.Length);
        //set item of this index 
        GetItem.ItemSpawn = gameManager.BackUPItems[a];

        Instantiate(Item, PosSpawns, Quaternion.identity);

        Destroy(gameObject);
    }
}