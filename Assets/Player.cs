using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerd : MonoBehaviour
{
    private Text lifetext;
    private int lifeScoreCount;
    private bool canDamage;

    void Awake()
    {
        lifetext = GameObject.Find("LifeText").GetComponent<Text>();
        lifeScoreCount = 3;
        lifetext.text = "x" + lifeScoreCount;
        canDamage = true;

    }

    void start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {

    }

    public void DealDamage()
    {
        if (canDamage)
        {
            canDamage = false;
            lifeScoreCount--;

            if (lifeScoreCount >= 0)
            {
                lifetext.text = "x" + lifeScoreCount;
            }

            if (lifeScoreCount == 0)
            {
                Time.timeScale = 0f;
                StartCoroutine(RestartGame());
            }
            StartCoroutine(waitforDamage());
        }



    }
    IEnumerator waitforDamage()
    {
        yield return new WaitForSeconds(5f);
        canDamage = true;


    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene("game2");
    }
}
