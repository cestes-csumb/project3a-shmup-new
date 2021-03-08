using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    //public GameObject EnemyGroupTypePrefab;
    private GameObject EnemyPrefab;
    private float movementTimer = 1.0f;
    private float shootingTimer = 2.0f;
    private bool goingLeft;
    private GameObject[] enemyGroup;
    private GameObject leftLeader;
    private GameObject rightLeader;
    private bool isLastRow;
    private bool moveDown;
    private bool readyToMoveDown = false;
    private bool isShootingGroup = false;
    private int scoreValue;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
          goingLeft = false;
          //group size is 5
          enemyGroup = new GameObject[5];
          float xStart = this.transform.position.x;
          for (int i = 0; i < enemyGroup.Length; i++) {
               enemyGroup[i] = Instantiate(EnemyPrefab);
               //all these objects need to be children of the parent
               enemyGroup[i].transform.SetParent(this.transform);
               enemyGroup[i].transform.position = new Vector3(xStart, this.transform.position.y, this.transform.position.z);
               enemyGroup[i].GetComponent<Enemy>().SetPoints(scoreValue);
               xStart += 3.0f;
          }
          leftLeader = enemyGroup[0];
          rightLeader = enemyGroup[enemyGroup.Length-1];
          isLastRow = false;
          moveDown = false;
    }

    // Update is called once per frame
    void Update()
    {
          movementTimer -= Time.deltaTime;
          shootingTimer -= Time.deltaTime;
          if (movementTimer <= 0) {
               movementTimer = 1.0f - speed;
               Vector3 groupPos = transform.position;
               //Debug.Log(groupPos);
               if (goingLeft == false)
               {
                    //if we're going to the right get info from right leader
                    Vector3 pos = rightLeader.transform.position;
                    //Debug.Log(pos);
                    //Debug.Log("Going Right!");
                    if (pos.x + 1.0f >= 10.2f)
                    {
                         readyToMoveDown = true;
                         if (moveDown == true) {
                              groupPos.y -= 1.0f;
                              goingLeft = true;
                              readyToMoveDown = false;
                              moveDown = false;
                         }
                    }
                    else if(readyToMoveDown == false)
                    {
                         groupPos.x += 1.0f;
                    }
               }
               else {
                    // if we're going left, get info from left leader
                    Vector3 pos = leftLeader.transform.position;
                    //Debug.Log("Going Left!");
                    if (pos.x - 1.0f <= -10.4f)
                    {
                         readyToMoveDown = true;
                         //Debug.Log("Moving Down!");
                         if (moveDown == true) {
                              groupPos.y -= 1.0f;
                              goingLeft = false;
                              readyToMoveDown = false;
                              moveDown = false;
                         }

                    }
                    else if(readyToMoveDown == false) {
                         groupPos.x -= 1.0f;
                    }
               }
               transform.position = groupPos;
          }

          if (transform.childCount == 0)
          {
               //Debug.Log("Group empty!");
               Destroy(gameObject);
          }
          else {
               UpdateLeaders();
               if (isShootingGroup && shootingTimer <= 0.0f)
               {
                    AssignShooter();
                    shootingTimer = 2.0f;
               }
          }
    }
     void UpdateLeaders() {
          if (leftLeader.Equals(null)) {
               for (int i = 0; i < enemyGroup.Length; i++) {
                    if (!enemyGroup[i].Equals(null))
                    {
                         speed += 0.05f;
                         leftLeader = enemyGroup[i];
                         break;
                    }
               }
          }

          if (rightLeader.Equals(null)) {
               for (int i = enemyGroup.Length - 1; i >= 0 ; i--)
               {
                    if (!enemyGroup[i].Equals(null))
                    {
                         speed += 0.05f;
                         rightLeader = enemyGroup[i];
                         break;
                    }
               }
          }
     }

     void AssignShooter() {
          int randomEnemy = Random.Range(0, enemyGroup.Length-1);
          //Debug.Log(randomEnemy);
          if (enemyGroup[randomEnemy] != null)
          {
               enemyGroup[randomEnemy].GetComponent<Enemy>().SetShooter();
          }
          else {
               for (int i = 0; i < enemyGroup.Length; i++)
               {
                    if (!enemyGroup[i].Equals(null))
                    {
                         enemyGroup[i].GetComponent<Enemy>().SetShooter();
                         //Debug.Log(i + " is shooting!");
                         break;
                    }
               }
          }
     }

     public void SetEnemyType(GameObject enemy) {
          EnemyPrefab = enemy;
     }

     public void SetLastRow(bool answerFromSpawner) {
          isLastRow = answerFromSpawner;
     }

     public void SetMoveDown(bool answerFromSpawner) {
          moveDown = answerFromSpawner;
     }

     public bool GetReadyToMoveDown() {
          return readyToMoveDown;
     }

     public void IsShootingGroup(bool answerFromSpawner) {
          isShootingGroup = answerFromSpawner;
     }

     public void SetScoreValue(int points) {
          scoreValue = points;
     }

     public void SetSpeed(float newSpeed) {
          speed = newSpeed;
     }
}
