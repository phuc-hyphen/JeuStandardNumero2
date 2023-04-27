using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

public class TunerScreen : MonoBehaviour
{
    [DllImport("WindowsTTS")]
    public static extern void initSpeech();

    [DllImport("WindowsTTS")]
    public static extern void destroySpeech();

    [DllImport("WindowsTTS")]
    public static extern void addToSpeechQueue(byte[] s);
    //[DllImport("WindowsVoice", CharSet=CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    //public static extern void addToSpeechQueue([MarshalAs(UnmanagedType.LPStr)] string s);

    [DllImport("WindowsTTS")]
    public static extern void clearSpeechQueue();

    [DllImport("WindowsTTS")]
    public static extern void statusMessage(StringBuilder str, int length);

    [DllImport("WindowsTTS")]
    public static extern void changeVoice(int vIdx);

    [DllImport("WindowsTTS")]
    public static extern bool isSpeaking();

    public static TunerScreen theVoice = null;

    public int voiceIdx = 0;

    static List<string> keyValue = new List<string>();

    static List<string> keyValueOnTask = new List<string>();
    static int currIdx = 0;

    private UIDocument tuner;
    private SliderInt slider;
    private VisualElement cursor;
    private VisualElement screen;
    private float screenWidth;

    private GameObject music;
    public List<AudioClip> musicList;
    public List<AudioClip> infoList;

    void OnEnable()
    {
        tuner = GetComponent<UIDocument>();
        slider = tuner.rootVisualElement.Q<SliderInt>("Slider");
        cursor = tuner.rootVisualElement.Q<VisualElement>("Cursor");
        screen = tuner.rootVisualElement.Q<VisualElement>("Screen");

        slider.SetValueWithoutNotify(int.Parse(System.Environment.GetEnvironmentVariable("sliderValueEnv")));

        music = GameObject.Find("Audio");
    }

    void Update()
    {
        screenWidth = screen.resolvedStyle.width;
        float newX = (screenWidth * slider.value) / 100;
        Vector2 newPosition = new Vector2(newX, 0);
        cursor.transform.position = newPosition;

        if (slider.value < 25)
        {
            PlayChannel(1, "music");
        }
        else if (slider.value < 50)
        {
            PlayChannel(2, "music");
        }
        else if (slider.value < 75)
        {
            PlayChannel(3, "music");
        } else {
            PlayTS("hello");
        }
    }

    void PlayChannel(int id, string type)
    {
        var channelIdOn = GameObject.Find("channel_" + id.ToString());
        AudioSource channelOn = channelIdOn.GetComponent<AudioSource>();
        if (!channelOn.isPlaying)
        {
            TunerScreen.destroySpeech();
            MuteChannel();
            channelOn.clip = musicList[id - 1];
            channelOn.time = Random.Range(0, musicList[id - 1].length);
            channelOn.loop = true;
            channelOn.Play();
        }
    }

    void MuteChannel()
    {
        for (int i = 1; i <= 3; i++)
        {
            var channelIdOff = GameObject.Find("channel_" + i.ToString());
            AudioSource channelOff = channelIdOff.GetComponent<AudioSource>();
            channelOff.Stop();
        }
    }

    void PlayTS(string text)
    {
        initSpeech();
        changeVoice(voiceIdx);
        MuteChannel();
        TunerScreen.speak(text, true);
    }

    void OnDisable()
    {
        System.Environment.SetEnvironmentVariable("sliderValueEnv", string.Format("{0}", slider.value));
    }

    void OnDestroy()
    {
        if (theVoice == this)
        {
            Debug.Log("Destroying speech");
            destroySpeech();
            theVoice = null;
        }
    }

    public static void speak(string msg, bool interruptable = false)
    {
        Encoding encoding = System.Text.Encoding.GetEncoding(System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ANSICodePage);
        var data = encoding.GetBytes(msg);
        if (interruptable)
            clearSpeechQueue();
        addToSpeechQueue(data);
        //addToSpeechQueue(msg);
    }


    private void OnApplicationQuit()
    {
        TunerScreen.destroySpeech();
    }
}
