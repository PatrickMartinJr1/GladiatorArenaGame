using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{

    private PlayerInput _playerInput;

    public InputAction _touchPressAction;

    public bool IsTapPressed { get; private set; } = false;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _touchPressAction = _playerInput.actions["TouchPressed"];

    }

    private void Update()
    {
        if (_touchPressAction.WasPressedThisFrame())
        {
            IsTapPressed = true;
        }
        else
        {
            IsTapPressed = false;
        }
    }

  /*  private void OnEnable()
      {
          _touchPressAction.performed += TouchPressed;
      }

      private void OnDisable()
      {
          _touchPressAction.performed -= TouchPressed;
      }       

    private void TouchPressed(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        Debug.Log(value);
        if (value >= 0.5f)
        {
            IsTapPressed = true;
        }
        else
        {
            IsTapPressed = false;
        }
 
    }
  */
}
