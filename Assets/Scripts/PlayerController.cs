using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

	public Rigidbody rb;
	public float speed = 1000f;
	private int score;
	public int health = 5;
	public Text scoreText;
	public Text healthText;

	// Use this for initialization
	void Start()
	{

	}

	// Increase the number of calls to FixedUpdate.
	void FixedUpdate()
	{

		if (Input.GetKey("z"))
		{
			rb.AddForce(0, 0, speed * Time.deltaTime);
		}

		if (Input.GetKey("s"))
		{
			rb.AddForce(0, 0, -speed * Time.deltaTime);
		}

		if (Input.GetKey("d"))
		{
			rb.AddForce(speed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey("q"))
		{
			rb.AddForce(-speed * Time.deltaTime, 0, 0);
		}
	}

	void Update()
	{
		if (health == 0)
		{
			Debug.Log("Game Over!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Pickup"))
		{
			score++;
			SetScoreText();
			Debug.Log("Score: " + score);
			other.gameObject.SetActive(false);

		}
		else if (other.CompareTag("Trap"))
		{
			health--;
			SetHealthText();
			Debug.Log("Heatlh: " + health);
		}
		else if (other.CompareTag("Goal"))
		{
			Debug.Log("You win!");
		}
		
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + score;
	}

	void SetHealthText()
	{
		healthText.text = "Health: " + health;
	}
}