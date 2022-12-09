using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //public variables
    public ParticleSystem explosionParticle;
    public int pointValue;

    //private variables
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //random force on y-axis
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        //random torque(rotation) on xyz axes
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        //random x-axis position
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //destroy object on mouse click
    //private void OnMouseDown()
    //{
        //if (gameManager.isGameActive)
       // {
          //  Destroy(gameObject);
            //Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation); //spawns particle on objects position
            //gameManager.UpdateScore(pointValue); //calls update score method passing the pointValue variables assigned to game objects
        //}
        
    //}

    //when objects drop below sensor bar destroy object
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        // if an object that is not tagged bad falls below sensor and game is still active, lose a life
        if(!gameObject.CompareTag("Bad") && gameManager.isGameActive)
        {
            gameManager.UpdateLives(-1);
        }
    }

    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation); //spawns particle on objects position
            gameManager.UpdateScore(pointValue); //calls update score method passing the pointValue variables assigned to game objects
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
