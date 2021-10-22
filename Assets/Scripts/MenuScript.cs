using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
 
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Text smashBallNum;
    [SerializeField] int numSmashBalls;


    public static bool isPaused = false;
    public static int staticSmashBallNum = 0;
    public static MenuScript instance;

    private PlayerInputHandler pc;
    private GameObject player;
    private Rigidbody2D playerBody;

    public void Awake()
    {
        staticSmashBallNum = numSmashBalls;
    }
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerInputHandler>();
        playerBody = player.GetComponent<Rigidbody2D>();
        pauseMenu.SetActive(false);

    }

    

    public void Update()
    { 

        if (pc.PauseInput)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else if(isPaused == false)
            {
                PauseGame();
            }
        }

        smashBallNum.text = PlayerInputHandler.smashBalls.ToString();
    }


    public void PauseGame()
    {
        //playerBody.velocity = Vector2.zero;
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

    }

    public void ResumeGame()
    {
        //playerBody.velocity = new Vector3(0, 0, 0);
        pc.disableInputs = false;
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

    }

}
