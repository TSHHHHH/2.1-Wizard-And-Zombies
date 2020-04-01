using System.Collections;
using UnityEngine;

public class InnerArua : MonoBehaviour
{
    public float innerRotationSpeed = -90.0f;
    public GameObject middleArua;

    // Use this for initialization
    private void Start()
    {
        StartCoroutine(ExecuteAfterTime(1.0f));
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, 0, innerRotationSpeed * Time.deltaTime);
    }

    private IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Instantiate(middleArua, transform.position, Quaternion.identity);
    }
}