using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InputForPointScreen : MonoBehaviour
{
    float startTimer;
    bool readyTimer;
    // Start is called before the first frame update
    void Start()
    {
          startTimer = 2.5f;
          readyTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.Space)) {
               readyTimer = true;
          }
          if (readyTimer == true) {
               startTimer -= Time.deltaTime;
          }
          if (startTimer <= 0.0f) {
               SceneManager.LoadScene("DemoScene");
          }
    }
}
