using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineControl : MonoBehaviour
{
    public PlayableDirector playableDirector;

    public TimelineAsset timelineAsset;

    private void Start()
    {
        if (playableDirector && timelineAsset)
        {
            print("play");
            playableDirector.Play(timelineAsset);
        }
    }
}