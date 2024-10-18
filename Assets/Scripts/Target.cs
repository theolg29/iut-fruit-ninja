using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    Rigidbody body;

    private GameManager gameManager;

    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        MoveUp();

        gameManager = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveUp()
    {
        body.AddForce(Vector3.up * Random.Range(11, 13), ForceMode.Impulse);
        body.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);
        body.AddForce(new Vector3(Random.Range(-3, 3), 0, 0), ForceMode.VelocityChange);
    }

    void OnMouseDown()
    {
        if (gameObject.CompareTag("IncreaseScore"))
        {
            gameManager.IncreaseScore();
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("DecreaseScore"))
        {
            gameManager.DecreaseScore();
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sensor"))
        {
            gameManager.DecreaseScore();
            Destroy(gameObject);

            gameManager.GameOver();

        }


    }


}
