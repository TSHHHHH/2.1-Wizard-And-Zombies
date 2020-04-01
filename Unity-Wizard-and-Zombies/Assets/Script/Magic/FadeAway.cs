using System.Collections;
using UnityEngine;

public class FadeAway : MonoBehaviour
{
    private SpriteRenderer alphaColor;

    // Use this for initialization
    private void Start()
    {
        alphaColor = GetComponent<SpriteRenderer>();
        StartCoroutine(Fade());
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator Fade()
    {
        yield return new WaitForSeconds(2.0f);

        for (float f = 1f; f >= 0; f -= 0.5f * Time.deltaTime)
        {
            Color c = alphaColor.material.color;
            c.a = f;
            alphaColor.material.color = c;
            yield return null;
        }
    }
}