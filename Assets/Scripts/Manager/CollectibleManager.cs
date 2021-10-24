using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectibleManager : MonoBehaviour
{
    public Text numSmashBallsText;
    public int smashBallsInStage;
    public GameObject[] smashBallsInStageArr;
    public List<GameObject> smashBallsInTotal;
    public static int numSmashBallsInList;
    
    
    private GameManager GM;

    public static int smashBalls = 0;

    void Awake()
    {
        smashBallsInStage = smashBallsInStageArr.Length + smashBallsInTotal.Count;
    }

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    public void updateTotal(GameObject sb)
    {
        smashBallsInTotal.Add(sb);
    }
    public void Update()
    {
        numSmashBallsInList = smashBallsInTotal.Count;
        numSmashBallsText.text = smashBalls.ToString();

        if(smashBallsInStage != 0)
        {
            foreach (GameObject sb in smashBallsInStageArr)
            {
                //int currentID = sb.GetComponent<SmashBall>().id;
                foreach (GameObject sb2 in smashBallsInTotal)
                {
                    //int currentID2 = sb2.GetComponent<SmashBall>().id;
                    if (sb.GetInstanceID() != sb2.GetInstanceID())
                    {
                        sb2.SetActive(false);
                           
                    }
                }

            }

            foreach (GameObject sb in smashBallsInStageArr)
            {
                if (sb.GetComponent<SmashBall>().isCollected)
                {
                    sb.SetActive(false);
                }
                else if (sb.GetComponent<SmashBall>().isCollected == false)
                {
                    sb.SetActive(true);
                }
            }
        }
        
    }
    public void Add()
    {
        smashBalls++;
    }




   

}
