using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float leftFireRate;
    public float rightFireRate;
    public GameObject fireMissile;
    public GameObject fireBall;
    public GameObject fireSnap;
    public GameObject iceShard;
    public GameObject lightingStrike;
    public GameObject leftM;
    public GameObject rightM;

    private float leftNextFire = 0f;
    private float rightNextFire = 0f;
    private Transform playerPos;
    private Vector2 mousePos;

    private void Start()
    {
        playerPos = GetComponent<Transform>();
        leftM = fireMissile;
        rightM = fireBall;
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 shootPosition = playerPos.position;

        if (Input.GetButton("Fire1") && Time.time > leftNextFire)
        {
            leftNextFire = Time.time + leftFireRate;
            Instantiate(leftM, playerPos.position, Quaternion.identity);
        }

        if (Input.GetButton("Fire2") && Time.time > rightNextFire)
        {
            if (rightM == lightingStrike)
            {
                shootPosition = mousePos;
            }
            rightNextFire = Time.time + rightFireRate;
            Instantiate(rightM, shootPosition, Quaternion.identity);
        }
    }
}