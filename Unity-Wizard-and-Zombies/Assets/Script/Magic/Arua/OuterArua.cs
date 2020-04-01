using System.Collections;
using UnityEngine;

public class OuterArua : MonoBehaviour
{
    public float outerRotationSpeed = -15.0f;
    public GameObject lightingStrikeAni;
    public GameObject lightingStrike;
    public GameObject lightingStrikeTrail;

    // Use this for initialization
    private void Start()
    {
        StartCoroutine(ExecuteAfterTime(0.5f));
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, 0, outerRotationSpeed * Time.deltaTime);
    }

    private IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(lightingStrikeTrail, transform.position, Quaternion.identity);
        Instantiate(lightingStrikeAni, transform.position, Quaternion.identity);
        Instantiate(lightingStrike, transform.position, Quaternion.identity);
    }
}