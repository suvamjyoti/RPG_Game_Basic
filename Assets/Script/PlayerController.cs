using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    //to filterout ground from other object
    [SerializeField]
    private LayerMask movementMask;

    private PlayerMotor motor;

    void Awake()
    {
        //setting the camera instance
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //casting a ray from camera to point we hit
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //storing information about the point we hit
            RaycastHit hit;
            
            
            if(Physics.Raycast(ray,out hit,100,movementMask))
            {
                //if we hit something then execute this
                // now to move the player to point we hit
                motor.MoveToPoint(hit.point);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            //casting a ray from camera to point we hit
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //storing information about the point we hit
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 100))
            {
                //if we hit something then execute this
                //player interact with the object hit
                Debug.Log("interactable");
            }
        }
    }
}
