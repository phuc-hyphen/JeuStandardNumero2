using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = System.Random;
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

    private Random rand = new Random();
    private GameObject music;
    public List<AudioClip> musicList_1;
    public List<AudioClip> musicList_2;
    public List<AudioClip> musicList_3;
    public List<AudioClip> musicList_4;
    private string Planet = "";

    private Dictionary<int, List<AudioClip>> playlists = new Dictionary<int, List<AudioClip>>();
    private List<AudioClip> currPlayist;
    private int playlistId;

    private List<string> randomState = new List<string>();

    void OnEnable()
    {
        playlists.Clear();

        playlists.Add(1, musicList_1);
        playlists.Add(2, musicList_2);
        playlists.Add(3, musicList_3);
        playlists.Add(4, musicList_4);

        Planet = PlanetManager.currentPlanet;

        Debug.Log(Planet);

        tuner = GetComponent<UIDocument>();
        slider = tuner.rootVisualElement.Q<SliderInt>("Slider");
        cursor = tuner.rootVisualElement.Q<VisualElement>("Cursor");
        screen = tuner.rootVisualElement.Q<VisualElement>("Screen");

        if (System.Environment.GetEnvironmentVariable("sliderValueEnv") != null)
        {
            slider.SetValueWithoutNotify(int.Parse(System.Environment.GetEnvironmentVariable("sliderValueEnv")));
        }

        music = GameObject.Find("Audio");

        ChangePlanete();
    }

    void Update()
    {
        screenWidth = screen.resolvedStyle.width;
        float newX = (screenWidth * slider.value) / 100;
        Vector2 newPosition = new Vector2(newX, 0);
        cursor.transform.position = newPosition;

        if (slider.value < 25)
        {
            if (randomState[0] == "music" || (GameVariables.CurrentRadio.info == null))
            {
                PlayChannel(1);
            }
            else
            {
                PlayTS(GameVariables.CurrentRadio.info);
            }
        }
        else if (slider.value < 50)
        {
            if (randomState[1] == "music" || (GameVariables.CurrentRadio.info == null))
            {
                PlayChannel(2);
            }
            else
            {
                PlayTS(GameVariables.CurrentRadio.info);
            }
        }
        else if (slider.value < 75)
        {
            if (randomState[2] == "music" || (GameVariables.CurrentRadio.info == null))
            {
                PlayChannel(3);
            }
            else
            {
                PlayTS(GameVariables.CurrentRadio.info);
            }
        }
        else
        {
            if ((randomState[3] == "music") || (GameVariables.CurrentRadio.info == null))
            {
                PlayChannel(4);
            }
            else
            {
                PlayTS(GameVariables.CurrentRadio.info);
            }
        }
    }

    void PlayChannel(int id)
    {
        var channelIdOn = GameObject.Find("channel_" + id.ToString());
        AudioSource channelOn = channelIdOn.GetComponent<AudioSource>();
        if (!channelOn.isPlaying)
        {
            destroySpeech();
            MuteChannel();
            channelOn.clip = currPlayist[id - 1];
            channelOn.time = UnityEngine.Random.Range(0, currPlayist[id - 1].length);
            channelOn.loop = true;
            channelOn.Play();
        }
    }

    void MuteChannel()
    {
        for (int i = 1; i <= 4; i++)
        {
            var channelIdOff = GameObject.Find("channel_" + i.ToString());
            AudioSource channelOff = channelIdOff.GetComponent<AudioSource>();
            channelOff.Stop();
        }
    }

    void PlayTS(string text)
    {
        Debug.Log(text);
        initSpeech();
        changeVoice(voiceIdx);
        MuteChannel();
        Speak(text, true);
    }

    void OnDisable()
    {
        System.Environment.SetEnvironmentVariable("sliderValueEnv", string.Format("{0}", slider.value));
        System.Environment.SetEnvironmentVariable("currPlanet", Planet);
        System.Environment.SetEnvironmentVariable("currRandomState1", randomState[0]);
        System.Environment.SetEnvironmentVariable("currRandomState2", randomState[1]);
        System.Environment.SetEnvironmentVariable("currRandomState3", randomState[2]);
        System.Environment.SetEnvironmentVariable("currRandomState4", randomState[3]);
        System.Environment.SetEnvironmentVariable("currPlaylistId", string.Format("{0}", playlistId));
    }

    void OnDestroy()
    {
    }

    void Speak(string msg, bool interruptable = false)
    {
        Encoding encoding = System.Text.Encoding.GetEncoding(System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ANSICodePage);
        var data = encoding.GetBytes(msg);
        if (interruptable)
            clearSpeechQueue();
        addToSpeechQueue(data);
    }

    void ChangePlanete()
    {
        if (Planet != (System.Environment.GetEnvironmentVariable("currPlanet")))
        {

            List<int> seen = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                int index;
                
                do
                {
                    index = rand.Next(1, 5);
                } while (seen.Contains(index));

                seen.Add(index);

                switch (index)
                {
                    case 1:
                        randomState.Add("music");
                        break;
                    case 2:
                        randomState.Add("music");
                        break;
                    case 3:
                        randomState.Add("music");
                        break;
                    case 4:
                        randomState.Add("text");
                        break;
                }

            }
            playlistId = rand.Next(1, 5);
            currPlayist = playlists[playlistId];
            Debug.Log("diff:");
            Debug.Log(playlistId);
        }
        else
        {
            randomState.Add(System.Environment.GetEnvironmentVariable("currRandomState1"));
            randomState.Add(System.Environment.GetEnvironmentVariable("currRandomState2"));
            randomState.Add(System.Environment.GetEnvironmentVariable("currRandomState3"));
            randomState.Add(System.Environment.GetEnvironmentVariable("currRandomState4"));
            playlistId = int.Parse(System.Environment.GetEnvironmentVariable("currPlaylistId"));
            Debug.Log(playlistId);
            currPlayist = playlists[playlistId];
            Debug.Log("same:");
        }
        foreach (string var in randomState)
        {
            Debug.Log(var);
        }
    }

    void OnApplicationQuit()
    {
        destroySpeech();
    }
}
