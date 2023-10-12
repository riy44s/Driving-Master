using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hScript : MonoBehaviour
{
    void Start()
    {        
        Invoke("DisableGameObject", 7f);
    }

    void DisableGameObject()
    {
        gameObject.SetActive(false);
    }

}
