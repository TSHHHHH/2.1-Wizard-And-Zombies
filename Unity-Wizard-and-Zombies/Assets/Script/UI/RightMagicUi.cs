using UnityEngine;
using UnityEngine.UI;

public class RightMagicUi : MonoBehaviour
{
    public Sprite fireBallIcon;
    public Sprite lightingStrikeIcon;

    private Shoot shootScr;
    private Image current;

    // Use this for initialization
    private void Start()
    {
        shootScr = GameObject.FindGameObjectWithTag("Player").GetComponent<Shoot>();
        current = GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        checkMagic();
    }

    private void checkMagic()
    {
        if (shootScr.rightM == shootScr.fireBall)
        {
            current.sprite = fireBallIcon;
        }
        else if (shootScr.rightM == shootScr.lightingStrike)
        {
            current.sprite = lightingStrikeIcon;
        }
    }
}