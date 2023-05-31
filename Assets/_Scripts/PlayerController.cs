using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody _player;

    public float force = 0.5f;
    public bool hasPowerUp;
    public float repulsionForce;
    public float indicatorRotationSpeed;

    private GameObject focalPoint;
    public GameObject[] powerUpIndicators;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _player.AddForce(focalPoint.transform.forward * force * forwardInput, ForceMode.Force);

        foreach(GameObject indicators in powerUpIndicators)
        {
            indicators.transform.position = this.transform.position;
            indicators.transform.Rotate(indicatorRotationSpeed * Vector3.up);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(hasPowerUp && collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody _enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 repulsionDirection = collision.gameObject.transform.position - this.transform.position;

            _enemyRigidbody.AddForce(repulsionDirection * repulsionForce, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountdown()
    {
        powerUpIndicators[0].SetActive(true);

        yield return new WaitForSeconds(2);

        powerUpIndicators[0].SetActive(false);
        powerUpIndicators[1].SetActive(true);

        yield return new WaitForSeconds(2);

        powerUpIndicators[1].SetActive(false);
        powerUpIndicators[2].SetActive(true);

        yield return new WaitForSeconds(2);

        powerUpIndicators[2].SetActive(false);
        hasPowerUp = false;

    }
}
