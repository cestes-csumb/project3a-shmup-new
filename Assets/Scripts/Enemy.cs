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
     // Start is called before the first frame update
     private void Start()
     {
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
               scoreManager.UpdateScore(pointValue);
               //Destory bullet on collision
               Destroy(collision.gameObject);
               //destory self on collision
               GameObject hitParticleInstance = Instantiate(hitParticle);
               hitParticleInstance.transform.position = this.transform.position;
               Destroy(hitParticleInstance, 1.0f);
               Destroy(gameObject);
          }
    }

     public void SetShooter() {
          isShooter = true;
     }

     public void SetPoints(int points) {
          pointValue = points;
     }
}
