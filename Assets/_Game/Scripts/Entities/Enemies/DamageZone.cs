using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    
    private GameObject _playerRef;

    private void Start()
    {
        _playerRef = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Health _currentHealth = other.GetComponent<Health>();
            if (_currentHealth != null)
            {
                _currentHealth.Damage(_damage);
            }
        }


    }
}
