using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public float currentFuel = 100f;
   [HideInInspector] public TextMeshProUGUI fuel;
    bool isCarMoving;
    float countDown = 1f;
    public float baseInterval = 1f;

    [HideInInspector] public static Fuel carFuel;

    public Slider fuelSlider;

    private GameManeger gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManeger>();
        carFuel = this;

        if (PlayerPrefs.HasKey("Fuel1"))
        {
            currentFuel = PlayerPrefs.GetFloat("Fuel1");
        }

        countDown = baseInterval;
    }

 
    void Update()
    {
        if (isCarMoving)
        {
            if (countDown > 0)
            {
                countDown -= Time.deltaTime; 
            }
            else
            {
                countDown = baseInterval;
                currentFuel -= 1f;
                

                if (currentFuel <= 0f)
                {
                    currentFuel = 0f;
                    isCarMoving = false;
                    gameManager.LevelFail();
                }
                PlayerPrefs.SetFloat("Fuel1", currentFuel);
            }
          
        }
      //  fuel.text = " : " + currentFuel;
        fuelSlider.value = currentFuel / 100;
    }
    public void setCarMovement(bool Fuelcheck)
    {
        isCarMoving = Fuelcheck;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fuel")
        {
            currentFuel = 100f;
            Destroy(other.gameObject);
        }
    }
  
}
