using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float countdownEverySeconds = 60f;
    public float counter;

    void Start()
    {
        counter = countdownEverySeconds;
    }

    void Update()
    {
        if (counter < 0)
        {
            SceneManager.LoadScene("Scene_End");
        }

        // update width
        float percentDone = counter / countdownEverySeconds;
        transform.localScale = new Vector2(percentDone, 1f);

        // update counter 
        counter -= Time.deltaTime;
    }
}
