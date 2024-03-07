using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputBroadcaster : MonoBehaviour
{
    public bool IsTapPressed { get; private set; } = false;
    //TODO add other input events here

    private void Update()
    {
        //NOTE: put your input/detection here. this code
        //is just for simple example and does not account
        //for new input system setup
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            IsTapPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            IsTapPressed = false;
        }
    }
}
