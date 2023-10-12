using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
   public float currentTime = 0;
    public float startingTime = 30f;

    public Text countDownText;
    public GameManeger gameManager;
    public static TimeCount time;

    private void Start()
    {
        time = this;
        currentTime = startingTime;
    }

    private void Update()
    {
        countDownText.color = Color.white;
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");

        if (currentTime < 5)
        {
            countDownText.color = Color.red;
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            gameManager.LevelFail();
        }

    }

}
