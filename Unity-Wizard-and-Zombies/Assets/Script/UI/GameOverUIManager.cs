using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    public AudioClip hover;

    // Use this for initialization
    private void Start()
    {
        Time.timeScale = 1f;

        Cursor.visible = true;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void hoverSound()
    {
        AudioSource.PlayClipAtPoint(hover, transform.position);
    }
}