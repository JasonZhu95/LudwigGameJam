using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStageName : MonoBehaviour
{
   
    private float timer = 0f;
    private void Start()
    {
        
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            SceneManager.LoadScene("Arena");
            timer = 0f;
        }
    }
}
