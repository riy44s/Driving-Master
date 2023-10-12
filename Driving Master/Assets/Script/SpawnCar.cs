using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject[] Cars;
    int random = 0;
    void Start()
    {
        StartCoroutine(SpawnWithDelay());
    }
    IEnumerator SpawnWithDelay()
    {
        while (true)
        {
            Spawn(); // Call the Spawn method
            yield return new WaitForSeconds(11f); // Wait for 2 seconds before the next spawn
        }
    }
    void Spawn()
    {
        for(int i=0; i<transform.childCount; i++)
        {
            random = Random.Range(0,Cars.Length);
           Instantiate(Cars[random],transform.GetChild(i).transform.position, transform.GetChild(i).transform.rotation);

         }
    }

}
