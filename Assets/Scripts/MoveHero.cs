using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveHero : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float jumpForce = 700f;
    public Rigidbody2D rb;
    public float move;
    public bool facingRight = true;
    public int Score = 0;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DieCollider")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (col.gameObject.tag == "Star")
        {
            Destroy(col.gameObject);
            Score++; //Score = Score + 1;
            ScoreText.text = Score.ToString();
            if ( Score >= 4)
            {
                ScoreText.text = "You Win!";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
        if( move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; //theScale.x = theScale.x * -1;
        transform.localScale = theScale;
    }
   
}
