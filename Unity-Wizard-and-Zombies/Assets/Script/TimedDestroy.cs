using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public float destroyTime;

    // Use this for initialization
    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}