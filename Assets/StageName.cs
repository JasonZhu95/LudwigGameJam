using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageName : MonoBehaviour
{
        public string currentStage;
        [SerializeField] Text stageText;

        void Update()
        {
            stageText.text = currentStage.ToString();
        }

}
