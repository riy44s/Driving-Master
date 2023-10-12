using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject levelButtons;

    private void Awake()
    {
        ButtonsToArray();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for(int i=0; i<buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for(int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void OpenLevel(int levelId)
    {
       
        int selectedCarIndex = PlayerPrefs.GetInt("SelectedCarIndex", 0);

       
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");
        if (selectedCarIndex >= 0 && selectedCarIndex < cars.Length)
        {
            cars[selectedCarIndex].SetActive(true);
        }
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
        AudioManeger.Instance.musicSource.Stop();
    }
    void ButtonsToArray()
    {
        int childCount = levelButtons.transform.childCount;
        buttons = new Button[childCount];
        for(int i = 0; i < childCount; i++)
        {
            buttons[i] = levelButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }
}
