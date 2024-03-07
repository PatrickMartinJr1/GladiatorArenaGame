using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private GamePlayState _playState;
    [SerializeField] private int _health = 5;

    [SerializeField]  private int _maxHealth = 5;

    [SerializeField] private ParticleSystem _hurtParticles;
    [SerializeField] private AudioSource _hurtSound;
    [SerializeField] private AudioSource _deathSound;

    private GameObject _healthManager;
    [SerializeField] private bool _hasHealthBar = false;

    private void Start()
    {
        if (_hasHealthBar == true)
        {
            _healthManager = GameObject.FindGameObjectWithTag("HealthManager");
        }

    }
    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this._health -= amount;

        PlayHurtFX();

        if (_hasHealthBar == true)
        {

            HealthManager _healthManagerScript = _healthManager.GetComponent<HealthManager>();
            _healthManagerScript.ReduceHealthbar(amount);
        }


        if(_health <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        PlayDeathFX();
        Debug.Log("dead");
        GamePlayState._killCount++;
        gameObject.SetActive(false);
        
    }

    void PlayHurtFX()
    {
        // play vfx
        if (_hurtParticles != null)
        {
            // spawn a particle effect from assets
            ParticleSystem newParticle = Instantiate(_hurtParticles,
                transform.position, Quaternion.identity);
            newParticle.Play();
        }
        // play sfx
        if (_hurtSound != null)
        {
            AudioSource newSound = Instantiate(_hurtSound,
                transform.position, Quaternion.identity);
            Destroy(newSound.gameObject, newSound.clip.length);
        }
    }

    void PlayDeathFX()
    {

        // play sfx
        if (_deathSound != null)
        {
            AudioSource newSound = Instantiate(_deathSound,
                transform.position, Quaternion.identity);
            Destroy(newSound.gameObject, newSound.clip.length);
        }
    }
}
