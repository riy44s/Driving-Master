using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Parking : MonoBehaviour
{
    public Collider parkCheck;
    public Collider parkCheck2;
    public Collider parkCheck3;
    public Collider parkCheck4;

    public Renderer parkCheckRenderer;
    public Renderer parkCheckRenderer2;
    public Renderer parkCheckRenderer3;
    public Renderer parkCheckRenderer4;

    public bool isCollideWithTarget = false;
    public bool isCollideWithTarget2 = false;
    public bool isCollideWithTarget3 = false;
    public bool isCollideWithTarget4 = false;

    public GameObject playerCar;

    public GameObject parkingInfo;
    public Button parkingButton;

    public GameObject nextPanel;
    public GameObject speedometerObject;

    public TextMeshProUGUI LevelCount;

    public float timeRemaining = 0;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI TotalCoin;
    public float levelBounce = 100;
    public float totalCoin=0;
    public float currentLevelScore = 0;
    public bool isPaused = false;
    public GameObject CarFalse;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Coin"))
        {
            totalCoin = PlayerPrefs.GetFloat("Coin", totalCoin);
        }
      
        speedometerObject.GetComponent<Speedometer>();
    }
    private void Update()
    {
        if (isCollideWithTarget && isCollideWithTarget2)
        {
          
                    if(isCollideWithTarget3 && isCollideWithTarget4)
                    {
                        parkingInfo.SetActive(true);
                        Material material = parkCheckRenderer.material;
                        Material material2 = parkCheckRenderer2.material;
                        Material material3 = parkCheckRenderer3.material;
                        Material material4 = parkCheckRenderer4.material;

                        Color greenColor = new Color(0, 1, 0, 0.5f);
                        material.color = greenColor;
                        material2.color = greenColor;
                        material3.color = greenColor;
                        material4.color = greenColor;

                        if (parkingButton.interactable)
                        {
                            parkingButton.onClick.AddListener(OnButtonClick);


                        }
                       
                    }
                   
                
                
            
        }
        else
        {
            parkingInfo.SetActive(false);
            Material material = parkCheckRenderer.material;
            Material material2 = parkCheckRenderer2.material;
            Material material3 = parkCheckRenderer3.material;
            Material material4 = parkCheckRenderer4.material;

            Color redColor = new Color(1, 0, 0, 0.5f);
            material.color = redColor;
            material2.color = redColor;
            material3.color = redColor;
            material4.color = redColor;

        }

        isPaused = false;

       
    }

    public void OnButtonClick()
    {
        if (!isPaused)
        {
            PlayerPrefs.DeleteAll();

            UnlockNewLevel();

            TimeCount.time.enabled = false;

            timeRemaining = (TimeCount.time.currentTime * 10) + levelBounce;
            Debug.Log(" " + TimeCount.time.currentTime);
            Score.text += timeRemaining.ToString("0");
          
             totalCoin+= timeRemaining;
            TotalCoin.text += totalCoin.ToString("0");
            currentLevelScore += timeRemaining;

            PlayerPrefs.SetFloat("Coin", totalCoin );
            PlayerPrefs.Save();
             
            Debug.Log("Current Level Score: " + currentLevelScore.ToString("F0"));
            Debug.Log("Total Coin: " + totalCoin.ToString("F0"));

            AudioManeger.Instance.musicSource.Stop();
            speedometerObject.SetActive(false);
            CarFalse.SetActive(false);
            nextPanel.SetActive(true);
            AudioManeger.Instance.PlaySFX("Winning");
        }
        isPaused = true;
    }
    public void ResetCurrentLevelScore()
    {
        currentLevelScore = 0;
    }
    void UnlockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}