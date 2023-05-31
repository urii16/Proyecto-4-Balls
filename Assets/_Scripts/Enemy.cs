using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float force = 0.5f;

    private Rigidbody _enemy;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.transform.position - this.transform.position).normalized;
        _enemy.AddForce(force * direction, ForceMode.Force);

        if(_enemy.transform.position.y < -10)
        {
            Destroy(_enemy.gameObject);
        }
    }
}
