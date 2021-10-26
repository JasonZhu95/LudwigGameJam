using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStageName : MonoBehaviour
{
    private GameManager GM;
    private float timer = 0f;
    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            GM.LoadArenaLevel();
            timer = 0f;
        }
    }
}
