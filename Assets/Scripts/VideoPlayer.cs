using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class VideoPlayer : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer player;
    public UnityEngine.UI.Text urlText;

    // Start is called before the first frame update
    void Start()
    {
        player.url = Path.Combine(Application.streamingAssetsPath, "sample-mp4-file.mp4");
        urlText.text = player.url;
        player.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExplicitPlay()
    {
        player.Play();
    }
}
