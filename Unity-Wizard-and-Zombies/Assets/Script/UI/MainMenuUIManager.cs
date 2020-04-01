using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    public AudioClip hover;

    // Use this for initialization
    private void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void startGame()
    {
        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void hoverSound()
    {
        AudioSource.PlayClipAtPoint(hover, transform.position);
    }
}