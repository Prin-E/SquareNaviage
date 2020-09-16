using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAction : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource bgm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClip()
    {
        if(clip)
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    public void ToggleBGM(UnityEngine.UI.Toggle toggle) {
        bgm.enabled = toggle.isOn;
    }
}
