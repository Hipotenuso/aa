using Itens;
using UnityEngine;

namespace Cloth
{
    public class Clothitembase : MonoBehaviour
    {
        public ClothType clothType;
        public ClothManager clothManager;
        public PlayerNew player;
        public float duration = 2f;
        public string tagToCompare = "Player";
        public int ActualCloth;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag(tagToCompare))
            {
                Collect();
            }
        }

        public virtual void Collect()
        {
            var setup = clothManager.GetSetupByType(clothType);
            player.ChangeTexture(setup, duration);
            ActualCloth = gameObject.GetComponent<ClothItemSpeed>().cloth1;
            ActualCloth = gameObject.GetComponent<ClothItemStrong>().cloth2;
            HideObject();
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }
    }
}
