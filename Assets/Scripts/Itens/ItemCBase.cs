using Unity.VisualScripting;
using UnityEngine;
using SFXP;

namespace Itens
{
    public class ItemCBase : MonoBehaviour
    {
        public SFXType sfx;
        public ItemType itemType;
        public Animator animator;
        
        public ItemManager itemManager;
        public string compareTag = "Tag";
        public float delayToDesapear;

        [Header("Sounds")]
        public AudioSource audioSource;

        void Awake()
        {
            if(itemManager == null)
            {
                itemManager = FindAnyObjectByType<ItemManager>();
            }
            
        }

        private void OnTriggerEnter(Collider collision)
        {
            if(collision.transform.CompareTag(compareTag))
            {
                Collect();
                
            }
        }

        private void PlaySFX()
        {
            SFXPool.Instance.Play(sfx);
        }

        protected virtual void Collect()
        {
            OnCollect();
            //animator.SetBool("Desapear", true);
            Destroy(gameObject, delayToDesapear);
        }
        protected virtual void OnCollect()
        {
            PlaySFX();
            itemManager.AddByType(itemType);
        }
    }
}