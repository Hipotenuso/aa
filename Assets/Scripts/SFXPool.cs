using System.Collections.Generic;
using UnityEngine;

namespace SFXP
{
    public class SFXPool : MonoBehaviour
    {

        public static SFXPool Instance { get; private set; }

        public SoundManager soundManager;
        private List<AudioSource> audioSourceList;
        public int poolSize = 10;
        private int _index = 0;

        void Awake()
        {
            soundManager = FindFirstObjectByType<SoundManager>();
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            CreatePool();
            
        }

        public void CreatePool()
        {

            audioSourceList = new List<AudioSource>();

            for(int i = 0; i < poolSize; i++)
            {
                CreateAudioSourceItem();
            }
        }

        public void CreateAudioSourceItem()
        {
            GameObject go = new GameObject("SFX_Pool");
            go.transform.SetParent(gameObject.transform);
            audioSourceList.Add(go.AddComponent<AudioSource>());
            
        }

        public void Play(SFXType sfxTypee)
        {
            if(sfxTypee == SFXType.NONE) return;
            var sfx = soundManager.GetSFXByType(sfxTypee);
            audioSourceList[_index].clip = sfx._clip;
            audioSourceList[_index].Play();

            _index++;
            if(_index >= audioSourceList.Count) _index = 0;
            
        }
    }

}
