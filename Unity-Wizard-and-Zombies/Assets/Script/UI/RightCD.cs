using UnityEngine;
using UnityEngine.UI;

public class RightCD : MonoBehaviour
{
    private float nextCD = 0.0f;
    private float value;
    private float maxValue;
    private Image filled;
    private Shoot shootScr;

    // Use this for initialization
    private void Start()
    {
        filled = GetComponent<Image>();
        shootScr = GameObject.FindGameObjectWithTag("Player").GetComponent<Shoot>();

        maxValue = shootScr.rightFireRate;
        value = maxValue;
    }

    // Update is called once per frame
    private void Update()
    {
        value += Time.fixedDeltaTime;
        float actualValue = Mathf.Clamp(value, 0, maxValue);
        float amount = actualValue / maxValue;
        filled.fillAmount = amount;

        if (Input.GetButton("Fire2") && Time.time > nextCD)
        {
            value = 0.0f;
            nextCD = Time.time + shootScr.rightFireRate;
        }
    }
}