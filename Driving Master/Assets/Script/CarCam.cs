using UnityEngine;

public class CarCam : MonoBehaviour
{
    Transform rootNode;
    Transform carCam;
    Transform car;
    Rigidbody carPhysics;


    public float rotationThreshold = 1f;
    
  
    public float cameraStickiness = 10.0f;
    
  
    public float cameraRotationSpeed = 5.0f;

    void Awake()
    {
        carCam = Camera.main.GetComponent<Transform>();
        rootNode = GetComponent<Transform>();
        car = rootNode.parent.GetComponent<Transform>();
        carPhysics = car.GetComponent<Rigidbody>();
    }

    void Start()
    {
       
        rootNode.parent = null;
    }

    void FixedUpdate()
    {
        Quaternion look;

      
        rootNode.position = Vector3.Lerp(rootNode.position, car.position, cameraStickiness * Time.fixedDeltaTime);

     
        if (carPhysics.velocity.magnitude < rotationThreshold)
            look = Quaternion.LookRotation(car.forward);
        else
            look = Quaternion.LookRotation(carPhysics.velocity.normalized);
        

        look = Quaternion.Slerp(rootNode.rotation, look, cameraRotationSpeed * Time.fixedDeltaTime);                
        rootNode.rotation = look;
    }
}