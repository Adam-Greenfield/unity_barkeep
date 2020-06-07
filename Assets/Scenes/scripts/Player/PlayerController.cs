using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    public Interactable focus;

    Camera cam;
    PlayerMotor motor;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                Debug.Log("something's happening");


                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.collider.name);
                    motor.MoveToPoint(hit.point);
                    RemoveFocus();
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    Debug.Log(hit.collider);

                    if (interactable != null)
                    {
                        //instead of setting focus here, we're going to open a menu, passing in the interactable
                        interactable.OpenMenu();
                    }
                }
            }
        }
    }

    public void SetFocus(Interactable newFocus)
    {
        Debug.Log("setting focus");
        if(newFocus != focus)
        {
            if (focus != null)
                focus.onDefocused();

            focus = newFocus;
            motor.FollowTarget(focus);
        }
        
        newFocus.onFocused(transform);
        
    }

    void RemoveFocus()
    {
        if(focus != null)
            focus.onDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }
}

