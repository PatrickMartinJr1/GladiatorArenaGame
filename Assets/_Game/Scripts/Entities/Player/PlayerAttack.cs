using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private GameObject _attackArea = default;

    private bool _attacking = false;

    private float _timeToAttack = 0.25f;
    private float _timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _attacking = true;
            _attackArea.SetActive(_attacking);
            Debug.Log("attacked");
        }

        if (context.canceled)
        {
            _attacking = false;
            _attackArea.SetActive(_attacking);
            Debug.Log("stopped attacking");
        }
    }
}
