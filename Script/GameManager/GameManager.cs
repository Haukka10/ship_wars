using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion
    public GameObject Player;
    public TextMeshProUGUI text;
    public float Time_Game;
    public ItemCreate.ItemSpawn[] BackUPItems;


    private void Update()
    {
        //Update Global time in game 
        Time_Game = Time.fixedTime / 10;
        text.text = "Time of game: " + ((decimal)Time_Game);
    }
}