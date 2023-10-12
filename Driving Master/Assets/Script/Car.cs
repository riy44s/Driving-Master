using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent (typeof(Rigidbody))]
public class Car : MonoBehaviour
{
    public List<WheelCollider> ThtottleWheels;
    public List<GameObject> SteeringWheels;
    public List<GameObject> meshes;
    public float SteeringCoefficient = 5000f;
    public float maxTurn = 20f;
    public Rigidbody rb;

    public GameObject headLight;

    public float brakeStrength;

    public ParticleSystem particle;
    public ParticleSystem particle1;

    public GameManeger gameManager;

    public TrailRenderer[] tyretrail;
    bool tiremarkflag;

    public static Car car;
    public float carCurrentSpeed = 0;
    public float carMaxSpeed = 100;
    bool isBraking = false;

    public Material breakMaterial;
    private void Start()
    {
        car = this;
        rb = GetComponent<Rigidbody>();   
    }
    private void Update()
    {
        HeadLight();
        Horn();
        if (Input.GetKey(KeyCode.Space) || SimpleInput.GetButton("BrakeButton"))
        {
            isBraking = true;
        }
        else
        {
            isBraking = false;
        }

    }
    private void FixedUpdate()
    {
        foreach(WheelCollider wheel in ThtottleWheels)
        {


            if (isBraking)
            {
                wheel.brakeTorque = brakeStrength * Time.deltaTime;
                particle.Play();
                particle1.Play();
                StartEmiter();
                Fuel.carFuel.setCarMovement(false);
                breakMaterial.EnableKeyword("_EMISSION");
   
            }
            else
            {
                wheel.motorTorque = SteeringCoefficient * Time.deltaTime * SimpleInput.GetAxis("Vertical");
                wheel.brakeTorque = 0f;
                stopEmiter();
                carCurrentSpeed = (rb.velocity.magnitude * 3.6f) / carMaxSpeed;
                Fuel.carFuel.setCarMovement(true);
                breakMaterial.DisableKeyword("_EMISSION");

            }
        
        }

        foreach(GameObject wheel in SteeringWheels)
        {
            wheel.GetComponent<WheelCollider>().steerAngle = maxTurn * SimpleInput.GetAxis("Horizontal");
            wheel.transform.localEulerAngles = new Vector3(0f, SimpleInput.GetAxis("Horizontal") * maxTurn, 0f);
        }

        foreach(GameObject mesh in meshes)
        {
            mesh.transform.Rotate(rb.velocity.magnitude * (transform.InverseTransformDirection(rb.velocity).z) / (2 * Mathf.PI * 0.38f), 0f, 0f);
        }

    }
    public void Braking()
    {
        isBraking = SimpleInput.GetButton("BrakeButton");
    }
    public void HeadLight()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (headLight.activeInHierarchy)
            {
                headLight.SetActive(false);
            }
            else
            {
                headLight.SetActive(true);
            }

        }

    }
    public void Horn()
    {
        if (Input.GetKey(KeyCode.F))
        {
            AudioManeger.Instance.PlaySFX("Horn");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Collide"))
        {
            
            gameManager.LevelFail();
        }
    }

    
    private void StartEmiter()
    {
        if (tiremarkflag) return;
        foreach(TrailRenderer T in tyretrail)
        {
            T.emitting = true;
        }
        tiremarkflag = true;
    }
    private void stopEmiter()
    {
        foreach(TrailRenderer T in tyretrail)
        {
            T.emitting = false;
        }
        tiremarkflag=false;
    }
    
}