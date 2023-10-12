using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsRest : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.DeleteAll();
    }
}
