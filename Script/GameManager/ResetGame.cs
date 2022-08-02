using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    [SerializeField]
    private Player.Contriller.ControllerPlayer ConntrolerPlayer;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private EnemySystem.counter.EnemyCounter EnemyCounter;
    [SerializeField]
    private EnemySystem.TakeDamage.TakeDamage TakeDamage;

    public void Resetgame()
    {
        TakeDamage = FindObjectOfType<EnemySystem.TakeDamage.TakeDamage>();

        EnemyCounter.EnemyC.Clone();
        EnemyCounter.CurrentAmmoutOfEnemy = 0;
        EnemyCounter.MaxAmmoutEnemy = 2;
        ConntrolerPlayer.HP = ConntrolerPlayer.MaxHP;
        Player.transform.position = new Vector3(20, 0, 20);
        TakeDamage.TakeDmage(1000);
        ConntrolerPlayer.death.SetActive(false);
        Time.timeScale = 1;
    }

    public void MeinMenu()
    {
        SceneManager.LoadScene(1);
    }
}
