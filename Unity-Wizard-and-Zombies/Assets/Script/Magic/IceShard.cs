using UnityEngine;

public class IceShard : MonoBehaviour
{
    public float speed;
    public GameObject hitPartical;

    private Vector2 getDirection;

    private void Start()
    {
        getDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    private void Update()
    {
        fly();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Zombies")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(hitPartical, transform.position, Quaternion.identity);
    }

    private void fly()
    {
        Vector2 direction = new Vector2(getDirection.x, getDirection.y);
        float HDisplacement = direction.normalized.x * speed * Time.deltaTime;
        float VDisplacement = direction.normalized.y * speed * Time.deltaTime;
        Vector3 displacement = new Vector3(HDisplacement, VDisplacement);
        transform.position = transform.position + displacement;
    }
}