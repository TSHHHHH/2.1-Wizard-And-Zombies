using UnityEngine;

public class myCursor : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        Cursor.visible = false;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }
}