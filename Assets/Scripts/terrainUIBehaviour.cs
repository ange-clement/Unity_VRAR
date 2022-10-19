using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class terrainUIBehaviour : MonoBehaviour
{
    TMP_Text timerText;

    void Start()
    {
        timerText = GameObject.Find("lblTime").GetComponent<TMPro.TMP_Text>();


        StartCoroutine(newTimerTick());
    }
    void Update()
    {
    }

    IEnumerator newTimerTick()
    {
        while (GameVariables.currentTime > 0)
        {
            // attendre une seconde
            yield return new WaitForSeconds(1);
            GameVariables.currentTime--;
            timerText.text = "Time :" + GameVariables.currentTime.ToString();
        }
        // game over
        //SceneManager.LoadScene("stageTP2"); // le nom de votre scene

        timerText.text = "Time's up !\n He is comming...";
    }
}
