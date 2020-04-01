using UnityEngine;

public class MusicControl : MonoBehaviour
{
    private AudioSource current;

    // Use this for initialization
    private void Start()
    {
        current = GetComponent<AudioSource>();
        current.volume = 0.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (current.volume <= 0.6f)
        {
            current.volume = current.volume + 0.05f * Time.deltaTime;
        }
    }
}