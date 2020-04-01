using UnityEngine;

public class AcidBall : MonoBehaviour
{
    public float speed;
    public GameObject hitPartical;

    private Vector2 target;
    private Vector2 getDirection;
    private Vector2 direction;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        getDirection = player.transform.position - transform.position;
    }

    private void Update()
    {
        fly();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(hitPartical, transform.position, Quaternion.identity);
        }
    }

    private void fly()
    {
        direction = new Vector2(getDirection.x, getDirection.y);
        float HDisplacement = direction.normalized.x * speed * Time.deltaTime;
        float VDisplacement = direction.normalized.y * speed * Time.deltaTime;
        Vector3 displacement = new Vector3(HDisplacement, VDisplacement);
        transform.position = transform.position + displacement;
    }
}