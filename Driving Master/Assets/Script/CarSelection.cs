using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    [Header ("Buttons and Canvas")]
    public Button Next;
    public Button Previous;

    private int currentCar;
    private GameObject[] carList;
    private void Awake()
    {
        chooseCar(0);
    }
    private void Start()
    {
        currentCar = PlayerPrefs.GetInt("CarSelected");
        carList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        carList[i] = transform.GetChild(i).gameObject;
        
        foreach(GameObject go in carList)
            go.SetActive(false);
        if (carList[currentCar])
            carList[currentCar].SetActive(true);
    }
    public void chooseCar(int index)
   {
        Previous.interactable = (currentCar != 0);
        Next.interactable = (currentCar!= transform.childCount-1);

        for(int i=0; i<transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
   }
    public void switchCar(int switchCars)
    {
        currentCar += switchCars;
        chooseCar(currentCar);
    }
    public void Play()
    {
        PlayerPrefs.SetInt("CarSelected", currentCar);
        SceneManager.LoadScene("Level1");
        AudioManeger.Instance.musicSource.Stop();
    }
}
