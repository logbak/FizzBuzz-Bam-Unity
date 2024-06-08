using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByContactHazard : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    public Text displayNumber;
    private GameController gameController;
    private float i;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        AssignNumber();

    }

    public void AssignNumber()
    {
        i = Random.Range(1, 100);
        if (i % 15 == 0)
        {
            scoreValue = 15;
            displayNumber.fontSize = 10;
            displayNumber.text = "FizzBuzz";
        }

        else if (i % 3 == 0)
        {
            scoreValue = 3;
            displayNumber.fontSize = 12;
            displayNumber.text = "Fizz";
        }
        else if (i % 5 == 0)
        {
            scoreValue = 5;
            displayNumber.fontSize = 12;
            displayNumber.text = "Buzz";
        }
        else
        {
            scoreValue = 1;
            displayNumber.text = "" + i;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //prevents script from destroying the boundary collider that destroys objects off screen
        if (other.tag == "Boundary") 
        {
            return;
        }

        //setting up this way to force a Vector2 into the instantiate's second position (default is Vector3), may not be necessary?
        Vector2 explosionPosition = new Vector2(transform.position.x, transform.position.y);
        Instantiate(explosion, explosionPosition, transform.rotation);

        if (other.tag == "Player")
        {
        Vector2 otherExplosionPosition = new Vector2(other.transform.position.x, other.transform.position.y);
        Instantiate(playerExplosion, otherExplosionPosition, other.transform.rotation);
        gameController.GameOver();
        }
        if (other.tag != "Player") //prevents scoring points when you run into a hazard with your ship
        {
            gameController.AddScore(scoreValue);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
