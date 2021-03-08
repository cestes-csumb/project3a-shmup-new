using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    public float speed = 8.0f;
    public GameObject hitParticle;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
         scoreManager = FindObjectOfType<ScoreManager>();
         myRigidbody2D = GetComponent<Rigidbody2D>();
         move();
    }

    // Update is called once per frame
    void Update()
    {
          
          if (transform.position.x <= -11.4f) {
               //Debug.Log("Despawn");
               Destroy(gameObject);
          }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
         scoreManager.UpdateScore(100);
         GameObject hitParticleInstance = Instantiate(hitParticle);
         //Destory bullet on collision
         Destroy(collision.gameObject);
         //destory self on collision
         Destroy(gameObject);
         Destroy(hitParticleInstance, 1.0f);
    }

     void move() {
          myRigidbody2D.velocity = Vector2.right * -speed;
     }
}
