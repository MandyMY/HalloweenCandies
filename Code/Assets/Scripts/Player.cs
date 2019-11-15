using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int score;
    private bool playerDied;

    public float moveSpeed = 3;
    public float push = 10f;
    public Text scoreText;
    public Sprite sad;
    public Sprite happy;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.isKinematic = true;
        score = 0;
        SetScoreText();
        this.GetComponent<SpriteRenderer>().sprite = happy;
    }

    void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "flyGhost")
        {
            playerDied = true;
            rb2d.isKinematic = true;
            rb2d.velocity = Vector2.zero;
            GameController.instance.GameOver();
            this.GetComponent<SpriteRenderer>().sprite = sad;
        }
        else if (other.tag == "collector")
            GameController.instance.GameOver();
        else if (other.tag != "bg")
        {
            switch (other.tag)
            {
                case "c1":
                case "coin":
                    score += 1;
                    break;
                case "c5":
                    score += 2;
                    break;
                case "c2":
                    score += 1;
                    break;
                case "c4":
                    score += 2;
                    break;
                case "vik":
                    score -= 5;
                    break;
            }

            rb2d.velocity = new Vector2(rb2d.velocity.x, push);
            other.gameObject.SetActive(false);
            SetScoreText();
            Sounds.instance.JumpM();
        }
    }

    private void Move()
    {
        if (!GameController.instance.isStart || playerDied)
            return;
        rb2d.isKinematic = false;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
