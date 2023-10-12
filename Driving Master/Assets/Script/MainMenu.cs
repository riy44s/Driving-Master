using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI TotalCoinText;
    public Parking pr;
    private void Start()
    {
        AudioManeger.Instance.PlayMusic("Theme");
    }
    void Update()
    {
        TotalCoinText.text = "Total Coin: "+PlayerPrefs.GetFloat("Coin").ToString("0");
        Debug.Log(PlayerPrefs.GetFloat("Coin"));
        PlayerPrefs.DeleteAll();
    }

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void carSelection()
    {
        SceneManager.LoadScene("CarSelection");
    }
  
}
