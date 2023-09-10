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
	public Text winLoseText;
	public Image winLoseImage;

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

		if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(0);
        }
	}

	void Update()
	{
		if (health == 0)
		{
			winLoseImage.gameObject.SetActive(true);
			winLoseImage.color = Color.red;
			winLoseText.color = Color.white;
			winLoseText.text = "Game Over!";
			StartCoroutine(LoadScene(3));
		}
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Pickup"))
		{
			score++;
			SetScoreText();
			other.gameObject.SetActive(false);

		}
		else if (other.CompareTag("Trap"))
		{
			health--;
			SetHealthText();
		}
		else if (other.CompareTag("Goal"))
		{
			winLoseImage.gameObject.SetActive(true);
			winLoseImage.color = Color.green;
			winLoseText.color = Color.black;
			winLoseText.text = "You Win!";
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

	IEnumerator LoadScene(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}