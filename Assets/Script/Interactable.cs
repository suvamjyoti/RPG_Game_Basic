using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    Transform player;
    bool isFocus=false;
    bool isInteracting;

    internal virtual void Interact(){
        //meant to be overriden later
        Debug.Log("is interacting with " + transform.name);
    }

    private void Update() {
        if(isFocus && !isInteracting){
            float distance = Vector3.Distance(player.transform.position,transform.position);
            if(distance<radius){
                Interact();
                isInteracting = true;
            }
        }
    }



    internal void OnFocused(Transform playerTransform){
        isFocus = true;
        player  = playerTransform;
        isInteracting = false;
    }

    internal void onDeFocused(){
        isFocus = false;
        player = null;
        isInteracting = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


}
