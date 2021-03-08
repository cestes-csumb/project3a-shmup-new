using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyA;
    public GameObject EnemyB;
    public GameObject EnemyC;
    public GameObject EnemyGroup;
    //public GameObject ScoreManager;
    public ScoreManager scoreManager;
    private GameObject[] groups;
    private GameObject lastRow;
    private GameObject shootingGroup;
    private float speed;
    //private bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
          //Instantiate(ScoreManager);
          groups = new GameObject[3];
          for (int i = 0; i < groups.Length; i++) {
               groups[i] = Instantiate(EnemyGroup);
               groups[i].transform.SetParent(this.transform);
               groups[i].GetComponent<EnemyGroup>().SetSpeed(0.0f);
          }
          //last row will be the first element of groups
          lastRow = groups[0];
          lastRow.GetComponent<EnemyGroup>().SetLastRow(true);
          //set enemy types
          groups[0].GetComponent<EnemyGroup>().SetEnemyType(EnemyA);
          groups[0].GetComponent<EnemyGroup>().SetScoreValue(30);
          groups[1].GetComponent<EnemyGroup>().SetEnemyType(EnemyB);
          groups[1].GetComponent<EnemyGroup>().SetScoreValue(20);
          groups[2].GetComponent<EnemyGroup>().SetEnemyType(EnemyC);
          groups[2].GetComponent<EnemyGroup>().SetScoreValue(10);
          //groups[3].GetComponent<EnemyGroup>().SetEnemyType(EnemyA);
          //set positions
          groups[0].transform.position = new Vector3(-8.6f, 4.0f, 0);
          groups[1].transform.position = new Vector3(-8.6f, 2.0f, 0);
          groups[2].transform.position = new Vector3(-8.6f, 0.0f, 0);
          //set which group will shoot (it should be the one closest to the player)
          shootingGroup = groups[2];
          shootingGroup.GetComponent<EnemyGroup>().IsShootingGroup(true);
    }

    // Update is called once per frame
    void Update()
    { 
          if (transform.childCount == 0) {
               Debug.Log("Game Over");
          }

          if (lastRow == null)
          {
               for (int i = 0; i < groups.Length; i++)
               {
                    if (groups[i] != null)
                    {
                         lastRow = groups[i];
                         lastRow.GetComponent<EnemyGroup>().SetLastRow(true);
                         break;
                    }
               }
          }
          else {
               if (lastRow.GetComponent<EnemyGroup>().GetReadyToMoveDown())
               {
                    for (int i = 0; i < groups.Length; i++)
                    {
                         if (groups[i] != null)
                         {
                              groups[i].GetComponent<EnemyGroup>().SetMoveDown(true);
                         }
                    }
               }
          }
          if (shootingGroup == null)
          {
               for (int i = groups.Length - 1; i >= 0; i--)
               {
                    if (groups[i] != null)
                    {
                         shootingGroup = groups[i];
                         shootingGroup.GetComponent<EnemyGroup>().IsShootingGroup(true);
                         break;
                    }
               }
          }
     }
}
