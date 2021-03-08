using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  public ScoreManager scoreManager;
  public Transform shottingOffset;
    // Update is called once per frame
    void Update()
    {
      float horizontal = Input.GetAxis("Horizontal");
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        //Debug.Log("Bang!");
        Destroy(shot, 3f);

      }
      transform.Translate(transform.right * horizontal * Time.deltaTime * 3.0f);
    }

     private void OnCollisionEnter2D(Collision2D collision)
     {
          Destroy(gameObject);
          Debug.Log("Game Over!");
     }
}
