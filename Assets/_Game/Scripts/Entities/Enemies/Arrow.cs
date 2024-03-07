using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    private GameObject _player;
    private Rigidbody2D rb;
    public float _arrowSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = _player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * _arrowSpeed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }


}
