using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public Player player;
    bool gameIsOver;
    // Start is called before the first frame update
    void Start()
    {
          gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
          if (enemySpawner.transform.childCount == 0)
          {
               gameIsOver = true;
          }
          else if (player.Equals(null))
          {
               gameIsOver = true;
          }
          else if (enemySpawner.barrierVictory == true) {
               gameIsOver = true;
          }
          if (gameIsOver == true) {
               //Debug.Log("Switch to other scene...");
               SceneManager.LoadScene("Credits");
          }
    }
}
