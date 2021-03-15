using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsTimer : MonoBehaviour
{
    float creditsTimer;
    // Start is called before the first frame update
    void Start()
    {
          creditsTimer = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
          creditsTimer -= Time.deltaTime;
          if(creditsTimer <= 0.0)
          {
               SceneManager.LoadScene("DemoScreen");
          }
    }
}
