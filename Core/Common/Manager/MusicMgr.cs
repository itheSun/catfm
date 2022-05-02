using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace CatFM
{
    /// <summary>
    /// “Ù¿÷π‹¿Ì∆˜
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class MusicMgr : DntdMonoSingleton<MusicMgr>
    {
        private AudioSource audioSource;
        private Dictionary<SceneID, AudioClip> bgmMap = new Dictionary<SceneID, AudioClip>();

        private void Awake()
        {
            if (!TryGetComponent<AudioSource>(out audioSource))
                audioSource = gameObject.AddComponent<AudioSource>();

            Init();
        }

        private void Init()
        {
            LoadAsset();
        }

        private void LoadAsset()
        {
            AudioClip[] audioClips = ResMgr.Instance.LoadAll<AudioClip>(Constant.Path_Res_Bgm);
            foreach (AudioClip clip in audioClips)
            {
                bgmMap.Add((SceneID)Enum.Parse(typeof(SceneID), clip.name), clip);
            }
        }

        public void PlayBgm(SceneID scene)
        {
            if (!bgmMap.ContainsKey(scene))
            {
                Debug.LogWarning(string.Format("{0} Bgms does not exist in the bgmDict", name));
                return;
            }
            audioSource.clip = bgmMap[scene];
            audioSource.loop = true;
            audioSource.Play();
        }

        public void StopBgm()
        {
            audioSource.Stop();
        }
    }
}