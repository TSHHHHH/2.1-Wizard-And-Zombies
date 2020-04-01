using UnityEngine;
using UnityEngine.UI;

public class MagicUI : MonoBehaviour
{
    public Sprite fireMissileIcon;
    public Sprite iceShardIcon;

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
        if (shootScr.leftM == shootScr.fireMissile)
        {
            current.sprite = fireMissileIcon;
        }
        else if (shootScr.leftM == shootScr.iceShard)
        {
            current.sprite = iceShardIcon;
        }
    }
}