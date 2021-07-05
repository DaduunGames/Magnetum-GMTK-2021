using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioFadeIn : MonoBehaviour
{
    
    public AudioSource source;
    [Range(0,1)]
    public float volume;
    public float fadeSpeed;

    private void Start()
    {
        source.volume = 0;
    }

    private void Update()
    {
        if (source.volume < volume)
        {
            source.volume += Time.deltaTime * fadeSpeed;
        }
        if (source.volume > volume)
        {
            source.volume = volume;
        }
    }
}
