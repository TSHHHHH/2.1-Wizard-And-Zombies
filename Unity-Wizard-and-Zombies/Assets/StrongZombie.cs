using UnityEngine;

public class StrongZombie : MonoBehaviour
{
    public float initialSpeed;
    public float damageRange;
    public float waitingTime;
    public Transform[] dropScrolls;
    public GameObject player;

    private Rigidbody2D rb;
    private SpriteRenderer cuColor;
    private float finishTime;
    private float currentSpeed;
    private float health = 20;
    private float damageDelay;
    private float nextRoamTime;
    private bool startRestore;

    // Use this for initialization
    private void Start()
    {
        currentSpeed = initialSpeed;
        finishTime = 0.0f;
        damageDelay = 0.0f;
        nextRoamTime = 0.0f;

        startRestore = false;

        rb = GetComponent<Rigidbody2D>();
        cuColor = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        rb.freezeRotation = true;

        movement();

        damageDelay -= Time.deltaTime;

        restoreSpeed();
        checkHealth();
    }

    private void FixedUpdate()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "FireMissile")
        {
            health -= 5.0f;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "FireBall")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "FireBallBlast")
        {
            health -= 10.0f;
        }

        if (other.gameObject.tag == "LightingStrikeBlast")
        {
            health -= 10.0f;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "IceShard")
        {
            health -= 2.0f;
            startRestore = true;
            float slowTime = 3.0f;
            currentSpeed = initialSpeed * 0.5f;
            finishTime = Time.time + slowTime;
            cuColor.color = Color.blue;
            Destroy(other.gameObject);
        }
    }

    private void checkHealth()
    {
        if (health <= 0.0f)
        {
            Destroy(gameObject);
            drop();
        }
    }

    private void restoreSpeed()
    {
        if (Time.time > finishTime && startRestore == true)
        {
            currentSpeed = initialSpeed;
            cuColor.color = Color.white;
            startRestore = false;
        }
    }

    private void drop()
    {
        int i = Random.Range(1, 100);
        if (i >= 1 && i <= 10)
        {
            int randDrop = Random.Range(0, dropScrolls.Length);
            Instantiate(dropScrolls[randDrop], transform.position, Quaternion.identity);
        }
    }

    private void dotDamage()
    {
        if (damageDelay <= 0.0f)
        {
            health -= 5.0f;

            damageDelay = 1.0f / 1.0f;
        }
    }

    private void movement()
    {
        if (Vector2.Distance(player.transform.position, transform.position) <= 10)
        {
            Vector2 playerDirection = player.transform.position - transform.position;
            rb.velocity = playerDirection.normalized * currentSpeed * Time.deltaTime;
        }
        else if (Vector2.Distance(player.transform.position, transform.position) > 10)
        {
            roamAround();
        }
    }

    private float randomNumber(float a, float b)
    {
        int i = Random.Range(1, 100);
        if (i >= 1 && i <= 50)
        {
            return a;
        }
        else
        {
            return b;
        }
    }

    private void roamAround()
    {
        if (Time.time > nextRoamTime)
        {
            float betweenRoam = 5.0f;
            nextRoamTime = nextRoamTime + betweenRoam;
            Vector2 roamDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rb.velocity = roamDirection.normalized * currentSpeed * Time.deltaTime;
        }
    }
}