using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectibleManager : MonoBehaviour
{
    public Text numSmashBallsText;
    public static int allowedNumOfSmashBalls = 0;

    public static List<GameObject> smashBallList = new List<GameObject>(0);
    public int balls;
    public static int smashBalls;

    public static string currentScene;
    public string scene;

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
        scene = currentScene;
    }

    void Start()
    {
        balls = allowedNumOfSmashBalls;

        if (scene == "Prologue")
        {
            for (int i = 0; i < smashBallList.Count; i++)
            {
                int k = smashBallList[i].GetComponent<SmashBall>().id;

                if (k != 1)
                {
                    smashBallList[i].SetActive(false);
                }
                if (k == 1)
                {
                    bool c = smashBallList[i].GetComponent<SmashBall>().isCollected;
                    if (c)
                    {
                        smashBallList[i].SetActive(false);
                    }
                    else if (!c)
                    {
                        smashBallList[i].SetActive(true);
                    }
                }
            }
        }

        if (scene == "Pools")
        {
            for (int i = 0; i < smashBallList.Count; i++)
            {
                int k = smashBallList[i].GetComponent<SmashBall>().id;

                if (k != 2 || k != 3 || k != 4)
                {
                    smashBallList[i].SetActive(false);
                }
                if (k == 2)
                {
                    bool c = smashBallList[i].GetComponent<SmashBall>().isCollected;
                    if (c)
                    {
                        smashBallList[i].SetActive(false);
                    }
                    else
                    {
                        smashBallList[i].SetActive(true);
                    }
                }
                if (k == 3)
                {
                    bool c = smashBallList[i].GetComponent<SmashBall>().isCollected;
                    if (c)
                    {
                        smashBallList[i].SetActive(false);
                    }
                    else
                    {
                        smashBallList[i].SetActive(true);
                    }
                }
                if (k == 4)
                {
                    bool c = smashBallList[i].GetComponent<SmashBall>().isCollected;
                    if (c)
                    {
                        smashBallList[i].SetActive(false);
                    }
                    else
                    {
                        smashBallList[i].SetActive(true);
                    }
                }
            }
        }
        if (scene == "Top64")
        {
            for (int i = 0; i < smashBallList.Count; i++)
            {
                int k = smashBallList[i].GetComponent<SmashBall>().id;

                if (k != 5 || k != 6 || k != 7)
                {
                    smashBallList[i].SetActive(false);
                }
                if (k == 5)
                {
                    bool c = smashBallList[i].GetComponent<SmashBall>().isCollected;
                    if (c)
                    {
                        smashBallList[i].SetActive(false);
                    }
                    else
                    {
                        smashBallList[i].SetActive(true);
                    }
                }
                if (k == 6)
                {
                    bool c = smashBallList[i].GetComponent<SmashBall>().isCollected;
                    if (c)
                    {
                        smashBallList[i].SetActive(false);
                    }
                    else
                    {
                        smashBallList[i].SetActive(true);
                    }
                }
                if (k == 7)
                {
                    bool c = smashBallList[i].GetComponent<SmashBall>().isCollected;
                    if (c)
                    {
                        smashBallList[i].SetActive(false);
                    }
                    else
                    {
                        smashBallList[i].SetActive(true);
                    }
                }
            }
            
        }

        
        if (scene == "Top8")
        {
            for (int i = 0; i < smashBallList.Count; i++)
            {
                int k = smashBallList[i].GetComponent<SmashBall>().id;

                if (k != 8 || k != 9 || k != 10)
                {
                    smashBallList[i].SetActive(false);
                }
                if (k == 8)
                {
                    bool c = smashBallList[i].GetComponent<SmashBall>().isCollected;
                    if (c)
                    {
                        smashBallList[i].SetActive(false);
                    }
                    else
                    {
                        smashBallList[i].SetActive(true);
                    }
                }
                if (k == 9)
                {
                    bool c = smashBallList[i].GetComponent<SmashBall>().isCollected;
                    if (c)
                    {
                        smashBallList[i].SetActive(false);
                    }
                    else
                    {
                        smashBallList[i].SetActive(true);
                    }
                }
                if (k == 10)
                {
                    bool c = smashBallList[i].GetComponent<SmashBall>().isCollected;
                    if (c)
                    {
                        smashBallList[i].SetActive(false);
                    }
                    else
                    {
                        smashBallList[i].SetActive(true);
                    }
                }
            }

        }
        if (scene != "Top8" || scene != "Pools" || scene != "Top64" || scene != "Prologue")
        {
            for (int i = 0; i < smashBallList.Count; i++)
            {
                smashBallList[i].SetActive(false);
            }
        }
    }

    void Update()
    {
        numSmashBallsText.text = smashBalls.ToString();
    }
    public void Add()
    {
        smashBalls++;
    }


}
