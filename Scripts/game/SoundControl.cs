using System;
using System.Collections.Generic;
using UnityEngine;
using engine.lib;

namespace com.components
{
    /// <summary>
    /// 声音控制之所以做成公共组件，而不使用DontDestroyOnLoad，是因为：
    /// UIRoot被卸载的时候会删除其下所有的子对象，忽略DontDestroyOnLoad设置的对象
    /// </summary>
    public class SoundControl : MonoBehaviour
    {
        public UIAtlas atlas;
        UISprite musicMute, soundMute;

        void Awake()
        {   
            if (AudioPlayerManager.MuteSound)
            {
                SetSoundMute();
            }

            if (AudioPlayerManager.MuteMusic)
            {
                SetMusicMute();
            }

            UIEventListener.Get(GameObject.Find("Sound")).onClick = OnSoundClick;
            UIEventListener.Get(GameObject.Find("Music")).onClick = OnMusicClick;
        }

        UISprite GetMuteSprite(Vector3 pos)
        {
            UISprite mute = NGUITools.AddSprite(gameObject, atlas, "mute");
            mute.MakePixelPerfect();
            mute.transform.position = pos;
            return mute;
        }

        void SetSoundMute()
        {
            soundMute = GetMuteSprite(new Vector3(-1f, 0.91f));
        }

        void SetMusicMute()
        {
            musicMute = GetMuteSprite(new Vector3(-0.87f, 0.91f));
        }

        void OnSoundClick(GameObject sprite)
        {
            if (soundMute)
            {
                soundMute.gameObject.SetActive(!soundMute.isVisible);
                AudioPlayerManager.MuteSound = soundMute.isVisible;
            }
            else
            {
                SetSoundMute();
                AudioPlayerManager.MuteSound = true;
            }
        }

        void OnMusicClick(GameObject sprite)
        {
            if (musicMute)
            {
                AudioPlayerManager.MuteMusic = !musicMute.isVisible;
                musicMute.gameObject.SetActive(!musicMute.isVisible);
            }
            else
            {
                SetMusicMute();
                AudioPlayerManager.MuteMusic = true;
            }
        }
    }
}
