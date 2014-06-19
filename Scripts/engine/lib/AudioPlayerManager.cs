using UnityEngine;
using System.Collections.Generic;

namespace engine.lib
{
    /// <summary>
    /// 全局的声音管理类，结合PlaySound使用
    /// </summary>
    static public class AudioPlayerManager
    {
        static AudioListener mListener;
        //背景音乐
        static AudioSource background;
        //音效
        static List<AudioSource> sounds = new List<AudioSource>();

        static bool bMLoaded = false;
        static bool bMuteMusic = false;
        static public bool MuteMusic
        {
            get
            {
                if (!bMLoaded)
                {
                    bMLoaded = true;
                    bMuteMusic = (PlayerPrefs.GetInt("MusicMute") == 1 ? true : false);
                }

                return bMuteMusic;
            }
            set
            {
                if (bMuteMusic != value)
                {
                    bMLoaded = true;
                    bMuteMusic = value;
                    background.mute = bMuteMusic;
                    PlayerPrefs.SetInt("MusicMute", (value ? 1 : 0));
                }
            }
        }

        static bool bSLoaded = false;
        static bool bMuteSound = false;
        static public bool MuteSound
        {
            get
            {
                if (!bSLoaded)
                {
                    bSLoaded = true;
                    bMuteSound = (PlayerPrefs.GetInt("SoundMute") == 1 ? true : false);
                }

                return bMuteSound;
            }
            set
            {
                if (bMuteSound != value)
                {
                    bSLoaded = true;
                    bMuteSound = value;
                    foreach (AudioSource source in sounds)
                    {
                        source.mute = bMuteSound;
                    }
                    PlayerPrefs.SetInt("SoundMute", (value ? 1 : 0));
                }
            }
        }

        /// <summary>
        /// 播放循环的背景音
        /// </summary>
        /// <param name="audio">音效文件</param>
        /// <param name="volume">声音</param>
        static public void PlayMusic(AudioClip audio, float volume)
        {
            background = Play(audio, volume, 1f, true);
            background.mute = bMuteMusic;
        }

        /// <summary>
        /// 播放一般音效
        /// </summary>
        /// <param name="audio">音效文件</param>
        /// <param name="volume">声音</param>
        static public void PlaySound(AudioClip audio, float volume)
        {
            if (!bMuteSound)
            {
                AudioSource source = Play(audio, volume);

                if (source != null)
                {
                    sounds.Add(source);
                }
            }
        }

        static AudioSource Play(AudioClip audio, float volume = 1f, float pitch = 1f, bool loop = false)
        {
            if (audio != null && volume > 0.01f)
            {
                if (mListener == null || !GameObjectUtil.GetActive(mListener))
                {
                    //全局查找AudioListener
                    AudioListener[] listeners = GameObject.FindObjectsOfType(typeof(AudioListener)) as AudioListener[];

                    if (listeners != null)
                    {
                        for (int i = 0; i < listeners.Length; ++i)
                        {
                            if (GameObjectUtil.GetActive(listeners[i]))
                            {
                                //获取第一个AudioListener来播放音效
                                mListener = listeners[i];
                                break;
                            }
                        }
                    }

                    if (mListener == null)
                    {
                        //如果全局都没有AudioListener，在摄像机上添加一个
                        Camera cam = Camera.main;
                        if (cam == null) cam = GameObject.FindObjectOfType(typeof(Camera)) as Camera;
                        if (cam != null) mListener = cam.gameObject.AddComponent<AudioListener>();
                    }
                }

                if (mListener != null && mListener.enabled && GameObjectUtil.GetActive(mListener.gameObject))
                {
                    AudioSource source = mListener.audio;
                    if (source == null) source = mListener.gameObject.AddComponent<AudioSource>();
                    source.pitch = pitch;
                    source.loop = loop;
                    source.volume = volume;
                    source.clip = audio;
                    //PlayOneShot和loop冲突，不会产生循环
                    source.Play();
                    return source;
                }
            }
            return null;
        }
    }
}
