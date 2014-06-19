using System;
using System.Collections.Generic;
using UnityEngine;

namespace engine.lib
{
    public class PlaySound : MonoBehaviour
    {
        public AudioClip audioClip;
        public float volume = 1f;
        public TriggerEnum trigger = TriggerEnum.Start;
        public AudioTypeEnum type = AudioTypeEnum.Sound;

        void Start()
        {
            if (trigger == TriggerEnum.Start)
            {
                if (type == AudioTypeEnum.Music)
                {
                    AudioPlayerManager.PlayMusic(audioClip, volume);
                }
                else
                {
                    AudioPlayerManager.PlaySound(audioClip, volume);
                }
            }
        }
    }

    public enum TriggerEnum
    {
        Start,
        OnClick,
        OnMouseOver,
        OnMouseOut,
        OnPress,
        OnRelease,
    }

    public enum AudioTypeEnum
    {
        Music,
        Sound,
    }

}
