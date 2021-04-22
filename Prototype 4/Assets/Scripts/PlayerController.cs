using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerUpIndicator;
    private float powerStrength = 15.0f;
    public float speed = 5.0f;
    public bool hasPower = false;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPower = true;
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
            StartCoroutine(PowerUpCountDown());
        }

    }
    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(7);
        hasPower = false;
        powerUpIndicator.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
        if (collision.gameObject.CompareTag("Enemy") && hasPower)
        {
            Debug.Log("Collided with" + collision.gameObject.name + "with the power set to" + hasPower);
            enemyRb.AddForce(awayFromPlayer * powerStrength , ForceMode.Impulse);
        }
    }
}
