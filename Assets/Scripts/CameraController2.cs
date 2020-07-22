using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CameraController2 : MonoBehaviour
{

    // Use this for initialization

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 0.2F;
    public float sensitivityY = 0.2F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -90F;
    public float maximumY = 90F;
    float rotationY = -60F;

    Vector3 touchStart;
    public int upperLimit = 0;
    public int lowerLimit = 7000;

    // For camera movement
    float cameraPanningSpeed = 5.0f;


    void Update()
    {
        MouseInput();
    }

    void MouseInput()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
        }
        else if (Input.GetMouseButton(1))
        {
            MouseRightClick();
        }
        else if (Input.GetMouseButton(2))
        {
            MouseMiddleButtonClicked();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            ShowAndUnlockCursor();
        }
        else if (Input.GetMouseButtonUp(2))
        {
            ShowAndUnlockCursor();
        }
        else
        {
            MouseWheeling();
        }
    }

    void ShowAndUnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void HideAndLockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void MouseMiddleButtonClicked()
    {
        /*        HideAndLockCursor();
                Vector3 NewPosition = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));
                Vector3 pos = transform.position;
                if (NewPosition.x > 0.0f)
                {
                    pos += transform.right / cameraPanningSpeed;
                }
                else if (NewPosition.x < 0.0f)
                {
                    pos -= transform.right / cameraPanningSpeed;
                }
                if (NewPosition.z > 0.0f)
                {
                    pos += transform.forward / cameraPanningSpeed;
                }
                if (NewPosition.z < 0.0f)
                {
                    pos -= transform.forward / cameraPanningSpeed;
                }
                pos.y = transform.position.y;
                transform.position = pos;*/

        //pan all at same time

    }

    void MouseRightClick()
    {
        HideAndLockCursor();
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }

    void MouseWheeling()
    {
        Vector3 pos = transform.position;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            pos = pos - transform.forward;
            transform.position = pos;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            pos = pos + transform.forward;
            transform.position = pos;
        }
    }
}
