using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image _healthBar;
    public float _healthAmount = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealthbar(float damage)
    {
        _healthAmount -= damage;
        _healthBar.fillAmount = _healthAmount / 100f;
    }
}
