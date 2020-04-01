using System.Collections;
using UnityEngine;

public class MiddleArua : MonoBehaviour
{
    public float middleRotationSpeed = -30.0f;
    public GameObject outerArua;

    // Use this for initialization
    private void Start()
    {
        StartCoroutine(ExecuteAfterTime(1.0f));
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, 0, middleRotationSpeed * Time.deltaTime);
    }

    private IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Instantiate(outerArua, transform.position, Quaternion.identity);
    }
}