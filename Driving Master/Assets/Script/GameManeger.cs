using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject carControll;
    public GameObject carControll2;
  
    public GameObject parkingButton;
    public GameObject levelFail;

    public static bool isPAused = false;

    public GameObject speedometerObject;

    public int lc = 0;
    public TextMeshProUGUI LevelCount;

    public GameObject winningObject;
    public TextMeshProUGUI TotalCoin;

    public GameObject FuelFalsing;
    private bool isPauseMenuActive = false;
    public GameObject SettingsFalsing;

    private void Start()
    {
        speedometerObject.GetComponent<Speedometer>();
    }
    private void Update()
    {
   
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPAused)
            {
                Resume();
            }
            else
            {
                LevelPause();
            }

        }
    }
    public void Settings()
    {
        speedometerObject.SetActive(false);
        FuelFalsing.SetActive(false);
    }
    public void LevelPause()
    {
        speedometerObject.SetActive(false);
        FuelFalsing.SetActive(false);
        SettingsFalsing.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPAused = true;
    }

    public void Resume()
    {
        speedometerObject.SetActive(true);
        FuelFalsing.SetActive(true);
        SettingsFalsing.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPAused = false;
    }

    public void Restart()
    {
        PlayerPrefs.SetFloat("Coin", 0);
        PlayerPrefs.SetFloat("Fuel1", 100f);
        AudioManeger.Instance.sfxSource.Play();
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }


    public void Home()
    {   
        SceneManager.LoadScene("MainMenu");
        AudioManeger.Instance.musicSource.Play();
        Time.timeScale = 1;
    }

    public void LevelFail()
    {
        speedometerObject.SetActive(false);
        FuelFalsing.SetActive(false);
        SettingsFalsing.SetActive(false);
        carControll.SetActive(false);
        carControll2.SetActive(false);
        levelFail.SetActive(true);
        Time.timeScale = 0;
        AudioManeger.Instance.PlaySFX("LevelFailed");
      
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Play()
    {
        AudioManeger.Instance.musicSource.Stop();
        SceneManager.LoadScene("Level1");
      
    }
    public void Next()
    {
        carControll.SetActive(false);
        carControll2.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        PlayerPrefs.SetFloat("Fuel1", 100f);
        AudioManeger.Instance.sfxSource.Play();
    }
   
    public void PlayAgain()
    {
       
        PlayerPrefs.SetFloat("Fuel1", 100f);
        AudioManeger.Instance.sfxSource.Play();
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1;
    }
    public void Level8()
    {
        carControll.SetActive(false);
        carControll2.SetActive(false);
        winningObject.SetActive(true);
        PlayerPrefs.SetFloat("Fuel1", 100f);
        AudioManeger.Instance.sfxSource.Stop();      
    }    
}
