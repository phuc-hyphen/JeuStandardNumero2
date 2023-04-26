using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TunerScreen : MonoBehaviour
{
    private UIDocument tuner;
    private SliderInt slider; 
    private VisualElement cursor;
    private VisualElement screen;
    private float screenWidth;

    private GameObject music;
    public List<AudioClip> musicList;
    public List<AudioClip> infoList;
     
    void Start()
    {
        tuner = GetComponent<UIDocument>();
        slider = tuner.rootVisualElement.Q<SliderInt>("Slider");
        cursor = tuner.rootVisualElement.Q<VisualElement>("Cursor");
        screen = tuner.rootVisualElement.Q<VisualElement>("Screen");

        music = GameObject.Find("Audio");
    }

    void Update()
    {
        screenWidth = screen.resolvedStyle.width;
        float newX = (screenWidth * slider.value) / 100;
        Vector2 newPosition = new Vector2(newX,0);
        cursor.transform.position = newPosition;

        if (slider.value < 25) {
            PlayChannel(1, "music");
        } else if (slider.value < 50) {
            PlayChannel(2, "music");
        } else if (slider.value < 75) {
            PlayChannel(3, "music");
        }
        // } else {
        //     PlayChannel(4, "info");
        // }
    }

    void PlayChannel(int id, string type) {
        var channelIdOn = GameObject.Find("channel_"+id.ToString());
        AudioSource channelOn = channelIdOn.GetComponent<AudioSource>();
        if (!channelOn.isPlaying) {
            for (int i = 1; i <= 4; i++) {
                var channelIdOff = GameObject.Find("channel_"+i.ToString());
                AudioSource channelOff = channelIdOff.GetComponent<AudioSource>();
                channelOff.Stop();
            }
            if (type == "music") {
                channelOn.clip = musicList[id-1];
                channelOn.time = Random.Range(0,musicList[id-1].length);
                channelOn.loop = true;
            } else {
                channelOn.clip = infoList[0];
            }
            channelOn.Play();
        }
    }
}
