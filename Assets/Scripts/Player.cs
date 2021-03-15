using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  public ScoreManager scoreManager;
  public Transform shottingOffset;
  Animator animator;
     private void Start()
     {
          animator = gameObject.GetComponent<Animator>();
     }
     // Update is called once per frame
     void Update()
    {
      float horizontal = Input.GetAxis("Horizontal");
      if (Input.GetKeyDown(KeyCode.Space))
      {
        animator.SetTrigger("On_Shot");
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        //Debug.Log("Bang!");
        Destroy(shot, 3f);
        StartCoroutine(AnimationTimer());
      }
      transform.Translate(transform.right * horizontal * Time.deltaTime * 3.0f);
    }

     private void OnCollisionEnter2D(Collision2D collision)
     {
          animator.SetTrigger("On_Death");
          Destroy(collision.gameObject);
          Destroy(gameObject, 0.8f);
          Debug.Log("Game Over!");
     }

     //We utilized a coroutine in class, this is what I'm utilizing to allow the animation to play before resetting the trigger
     //https://answers.unity.com/questions/225213/c-countdown-timer.html
     private IEnumerator AnimationTimer() {
               animator.SetTrigger("Return_To_Idle");
               yield return new WaitForSeconds(0.8f);
     }
}
