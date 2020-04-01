using UnityEngine;

public class ScrollTimedDestroy : MonoBehaviour
{
    public float destroyTime;
    public GameObject scrollGoneParticle;

    // Use this for initialization
    private void Start()
    {
        Invoke("die", destroyTime);
    }

    private void die()
    {
        Instantiate(scrollGoneParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}