using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    //to filterout ground from other object
    [SerializeField]
    private LayerMask movementMask;

    public Interactable focus;
    private PlayerMotor motor;

    void Awake()
    {
        //setting the camera instance
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }


//`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//UPDATE METHOD
//`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````


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
                //remove focus
                RemoveFocus();

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
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    //focus on an object
                    setFocus(interactable);
                }
            }
        }
    }

//`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````


    void setFocus(Interactable newFocus){
        if(newFocus!=focus){
            if(focus!=null){
                focus.onDeFocused();
            }
            focus = newFocus;
            motor.followTarget(newFocus);
        }
        
        newFocus.OnFocused(transform); 
    }

    void RemoveFocus(){
        if(focus!=null){
            focus.onDeFocused();
        }
        focus = null;
        motor.StopFollowingTarget();
    }
}
