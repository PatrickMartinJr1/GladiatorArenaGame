using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [Header("Movement")]
    private float _horizontal;
    [SerializeField] private float _speed;
    private bool _isFacingPlayer;


    [Header("Ranged Attack")]
    [SerializeField] private GameObject _enemyArrow;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _arrowSpeed;
    private float _timer;
    [SerializeField] private float _attackRate;
    [SerializeField] private AudioSource _shootSound;

    GameObject _playerRef;

    private void Start()
    {
        _playerRef = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);

        Flip();
        Move();

        if(_timer > _attackRate)
        {
            _timer = 0;
            RangedAttack();
        }


 

    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;

        if (_playerRef.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (_isFacingPlayer ? 1 : -1);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (_isFacingPlayer ? 1 : -1);
        }

        transform.localScale = scale;
    }

    public void Move()
    {
        if (Vector2.Distance(_playerRef.transform.position, transform.position) >= 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_playerRef.gameObject.transform.position.x, transform.position.y), _speed * Time.deltaTime);
        }

    }

    public void RangedAttack()
    {

        PlayAttackSFX();
        Instantiate(_enemyArrow, _spawnPoint.position,
           Quaternion.identity);
       /* Rigidbody2D arrowRig = arrowObj.GetComponent<Rigidbody2D>();
        Vector3 direction = _playerRef.transform.position - arrowObj.transform.position;
        _rb.velocity = new Vector2(direction.x, direction.y).normalized * _arrowSpeed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        arrowObj.transform.rotation = Quaternion.Euler(0, 0, rot * 90);

        Destroy(arrowObj, 2f);*/
        Debug.Log("Ranged enemy shot");
    }

    void PlayAttackSFX()
    {

        // play sfx
        if (_shootSound != null)
        {
            AudioSource newSound = Instantiate(_shootSound,
                transform.position, Quaternion.identity);
            Destroy(newSound.gameObject, newSound.clip.length);
        }
    }
}
