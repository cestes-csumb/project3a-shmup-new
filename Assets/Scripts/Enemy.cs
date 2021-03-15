using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject hitParticle;
    public GameObject bullet;
    public ScoreManager scoreManager;
    public TMPro.TextMeshProUGUI currentScore;
    private bool isShooter;
    private float shootTimer;
    private int pointValue;
    private Animator animator;
     // Start is called before the first frame update
     private void Start()
     {
          animator = gameObject.GetComponent<Animator>();
          isShooter = false;
          shootTimer = 2.0f;
          scoreManager = FindObjectOfType<ScoreManager>();
     }
     private void Update()
     {
          shootTimer -= Time.deltaTime;
          if (isShooter == true) {
               //shoot bullet on timer
               if (shootTimer <= 0.0f) {
                    animator.SetTrigger("On_Shot");
                    StartCoroutine(AnimationTimer());
                    //shoot bullet
                    shootTimer = 2.0f;
                    isShooter = false;
                    //get offset
                    Vector2 bulletOffset = transform.position;
                    bulletOffset.y += -1.0f;
                    GameObject shot = Instantiate(bullet, bulletOffset, Quaternion.identity);
                    //Debug.Log("Shot created...");
                    Destroy(shot, 1.2f);
               }
          }
     }
     void OnCollisionEnter2D(Collision2D collision)
    {
          if (collision.gameObject.name.StartsWith("Bullet")) {
               animator.SetTrigger("On_Death");
               scoreManager.UpdateScore(pointValue);
               //Destory bullet on collision
               Destroy(collision.gameObject);
               //destory self on collision
               GameObject hitParticleInstance = Instantiate(hitParticle);
               hitParticleInstance.transform.position = this.transform.position;
               Destroy(hitParticleInstance, 1.0f);
               Destroy(gameObject, 0.8f);
          }
    }

     public void SetShooter() {
          isShooter = true;
     }

     public void SetPoints(int points) {
          pointValue = points;
     }
     
     //We utilized a coroutine in class, this is what I'm utilizing to allow the animation to play before resetting the trigger
     //https://answers.unity.com/questions/225213/c-countdown-timer.html
     private IEnumerator AnimationTimer()
     {
          animator.SetTrigger("Return_To_Idle");
          yield return new WaitForSeconds(0.8f);
     }
}
