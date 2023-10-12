using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Rigidbody target;
    public Rigidbody target2;
    public float maxSpeed = 0.0f; 

    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;

    GameManeger gm;

    [Header("UI")]
    public TextMeshProUGUI speedLabel; 
    public RectTransform arrow; 

    private float speed = 0.0f;
 
    private void Update()
    {

        speed = target.velocity.magnitude * 3.6f;
        speed = target2.velocity.magnitude * 3.6f;

        if (speedLabel != null)
            speedLabel.text = ((int)speed) + " km/h";
        if (arrow != null)
            arrow.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));
    }
}