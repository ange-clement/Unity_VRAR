using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIBehaviour : MonoBehaviour
{
    public GameObject objectToshow;

    public int headToTouch = 3;

    TMP_Text headText;
    TMP_Text timerText;
    int nbHeads = 0;

    float timeWin;

    Coroutine timer;

    private GameObject player;
    void Start()
    {
        headText = GameObject.Find("lblBob").GetComponent<TMPro.TMP_Text>();
        timerText = GameObject.Find("lblTime").GetComponent<TMPro.TMP_Text>();

        player = GameObject.FindGameObjectWithTag("Player");


        GameVariables.currentTime = GameVariables.allowedTime;

        timer = StartCoroutine(TimerTick());

        timeWin = 0;
    }
    void Update()
    {
    }
    public void AddHit()
    {
        nbHeads++;
        headText.text = "BobHeads: " + nbHeads;

        if (nbHeads >= headToTouch)
        {
            objectToshow.transform.position = player.transform.position;
            objectToshow.transform.LookAt(player.transform.position);

            if (timeWin == 0)
            {
                timeWin = 5.0f;
                StartCoroutine(launchWin());
            }
        }
    }

    IEnumerator TimerTick()
    {
        while (GameVariables.currentTime > 0)
        {
            // attendre une seconde
            yield return new WaitForSeconds(1);
            GameVariables.currentTime--;
            timerText.text = "Time :" + GameVariables.currentTime.ToString();
        }
        // game over
        SceneManager.LoadScene("terrain"); // le nom de votre scene
    }

    IEnumerator launchWin()
    {
        StopCoroutine(timer);
        while (timeWin > 0)
        {
            yield return new WaitForSeconds(1);
            timeWin--;
        }
        SceneManager.LoadScene("terrain");
    }
}
