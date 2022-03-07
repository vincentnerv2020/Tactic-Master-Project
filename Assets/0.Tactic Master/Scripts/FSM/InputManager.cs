using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Joystick joystick;
    public GameObject joystickObj;
    public Vector2 movementAxis;
    public float movementSpeed;
    public float sqrMagn;
    public float magn;
    public float multiply;



    private void Update()
    {
        HandleInput();
    }


    void HandleInput()
    {
        //Read Input from joystick
        movementAxis.x = joystick.Horizontal;
        movementAxis.y = joystick.Vertical;
    }
    public void HandleJoystick(bool state)
    {
        joystickObj.SetActive(state);
    }
}
