using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [Header("Movement")]
    private float _horizontal;
    [SerializeField] private float _speed;
    private bool _isFacingPlayer;

    [Header("Melee Attack")]
    [SerializeField] private GameObject _attackArea;
    private bool _enemyAttacked = false;
    private float _timer;
    [SerializeField] private float _attackRate;
    [SerializeField] private AudioSource _meleeSound;

    GameObject _playerRef;

    private void Start()
    {
        _timer = 0;
        _playerRef = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
            _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);

        Flip();
        Move();

        _timer += Time.deltaTime;

        MeleeAttack();
        
        if (_enemyAttacked == true && _timer >= 0.5f)
        {
            _attackArea.SetActive(false);
            Debug.Log("enemy stopped attacking");
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
        if (Vector2.Distance(_playerRef.transform.position, transform.position) != 0)
              {
                  transform.position = Vector2.MoveTowards(transform.position, new Vector2(_playerRef.gameObject.transform.position.x, transform.position.y), _speed * Time.deltaTime);
              }

    }

    public void MeleeAttack()
    {


        if (Vector2.Distance(_playerRef.transform.position, transform.position) <= 2 && _timer >= _attackRate)
        {
            PlayAttackSFX();
            _attackArea.SetActive(true);
            Debug.Log("enemy attacked");
            _timer = 0;
            _enemyAttacked = true;
        }

    }

    void PlayAttackSFX()
    {

        // play sfx
        if (_meleeSound != null)
        {
            AudioSource newSound = Instantiate(_meleeSound,
                transform.position, Quaternion.identity);
            Destroy(newSound.gameObject, newSound.clip.length);
        }
    }
}
