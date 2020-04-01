using System;
using UnityEngine;

public class FireMissileScroll : MonoBehaviour
{
    public float pickUpRange;
    public float floatRange;

    private float orY;
    private Shoot shootScr;
    private Transform playerPos;
    private SpriteRenderer scroll;

    // Use this for initialization
    private void Start()
    {
        shootScr = GameObject.FindGameObjectWithTag("Player").GetComponent<Shoot>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        this.orY = this.transform.position.y;
        scroll = GetComponent<SpriteRenderer>();

        InvokeRepeating("blink", 5f, 0.3f);
    }

    // Update is called once per frame
    private void Update()
    {
        pickUp();
    }

    private void FixedUpdate()
    {
        floating();
    }

    private void floating()
    {
        transform.position = new Vector2(transform.position.x, orY + ((float)Math.Sin(Time.time) * floatRange));
    }

    private void pickUp()
    {
        if (Vector2.Distance(playerPos.position, transform.position) <= pickUpRange)
        {
            if (Input.GetKeyDown("e"))
            {
                shootScr.leftM = shootScr.fireMissile;
                Destroy(gameObject);
            }
        }
    }

    private void blink()
    {
        if (scroll.enabled == true)
        {
            scroll.enabled = false;
        }
        else if (scroll.enabled == false)
        {
            scroll.enabled = true;
        }
    }
}