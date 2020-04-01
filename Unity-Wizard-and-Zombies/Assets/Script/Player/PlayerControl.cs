using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public int health = 10;
    public float speed = 10f;
    public float knockBackForce;
    public Slider healthBar;
    public Vector2 moveInput;
    public GameObject youWin;

    private Vector2 moveVelocity, knockBackDirection, lastHMove, lastVMove;
    private Rigidbody2D rb;
    private SpriteRenderer current;
    private Animator anim;
    private float currentHealth, knockBackRestoreTime;
    private bool checkKnock, checkMove, isMoving;

    // Use this for initialization
    private void Start()
    {
        transform.position = new Vector2(0, 0);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        current = GetComponent<SpriteRenderer>();
        currentHealth = health;

        checkKnock = false;
        checkMove = true;

        youWin.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        rb.freezeRotation = true;

        //Player movement
        isMoving = false;
        playerMovement();
        anim.SetBool("IsMoving", isMoving);
        anim.SetFloat("LastHMove", lastHMove.x);
        anim.SetFloat("LastVMove", lastVMove.y);
        checkFlip();
        checkGameOver();
    }

    private void FixedUpdate()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Zombies")
        {
            currentHealth--;
            healthBar.value = currentHealth;
            knockBack(other.gameObject);
        }

        if (other.gameObject.tag == "StrongZombies")
        {
            currentHealth -= 3;
            healthBar.value = currentHealth;
            knockBack(other.gameObject);
        }

        if (other.gameObject.tag == "Acid Balls")
        {
            currentHealth--;
            healthBar.value = currentHealth;
            knockBack(other.gameObject);
        }

        if(other.gameObject.tag == "Exit")
        {
            youWin.SetActive(true);
            checkMove = false;
            Time.timeScale = .25f;
            Invoke("BackToMainMenu", 1.0f);
        }
    }

    private void playerMovement()
    {
        if (checkKnock == false && checkMove == true)
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            anim.SetFloat("HMove", moveInput.x);
            anim.SetFloat("VMove", moveInput.y);
            lastHMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0.0f);
            lastVMove = new Vector2(0.0f, Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * speed;
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
            if (Input.GetAxisRaw("Horizontal") != 0.0f || Input.GetAxisRaw("Vertical") != 0.0f)
            {
                isMoving = true;
            }
        }

        if (checkKnock == true && checkMove == false)
        {
            rb.velocity = knockBackDirection.normalized * knockBackForce * Time.deltaTime;
            restoreKnock();
        }
    }

    private void checkFlip()
    {
        if (!(Input.GetAxisRaw("Horizontal") < 0))
        {
            current.flipX = false;
        }
        else
        {
            current.flipX = true;
        }
    }

    private void knockBack(GameObject other)
    {
        knockBackDirection = new Vector2((other.transform.position.x - transform.position.x) * -1f, (other.transform.position.y - transform.position.y) * -1f);
        checkKnock = true;
        checkMove = false;
        float knockBackTime = 0.1f;
        knockBackRestoreTime = Time.time + knockBackTime;
    }

    private void restoreKnock()
    {
        if (Time.time > knockBackRestoreTime)
        {
            rb.velocity = Vector2.zero;
            checkMove = true;
            checkKnock = false;
        }
    }

    private void checkGameOver()
    {
        if (currentHealth < 0.0f)
        {
            checkMove = false;
            Time.timeScale = .25f;
            Invoke("gameOver", 1.0f);
        }
    }

    private void gameOver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
    }

    void backToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}