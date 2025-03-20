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

        private void Start()
        {
            if (player == null)
            {
                player = FindAnyObjectByType<PlayerNew>();
                if (player == null)
                {
                    Debug.LogError("Player não encontrado na cena!");
                }
            }

            if (clothManager == null)
            {
                clothManager = FindAnyObjectByType<ClothManager>();
                if (clothManager == null)
                {
                    Debug.LogError("ClothManager não encontrado na cena!");
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag(tagToCompare))
            {
                Collect();
            }
        }

        public virtual void Collect()
        {
            if (clothManager == null)
            {
                Debug.LogError("ClothManager está nulo! Não foi possível coletar o item.");
                return;
            }

            if (player == null)
            {
                Debug.LogError("Player está nulo! Não foi possível coletar o item.");
                return;
            }

            var setup = clothManager.GetSetupByType(clothType);
            if (setup == null)
            {
                Debug.LogError("Setup não encontrado para o tipo de roupa: " + clothType);
                return;
            }

            player.ChangeTexture(setup, duration);

            ClothItemSpeed clothSpeed = gameObject.GetComponent<ClothItemSpeed>();
            ClothItemStrong clothStrong = gameObject.GetComponent<ClothItemStrong>();

            if (clothSpeed != null)
            {
                ActualCloth = clothSpeed.cloth1;
            }
            else if (clothStrong != null)
            {
                ActualCloth = clothStrong.cloth2;
            }
            else
            {
                Debug.LogWarning("Nenhuma variação de ClothItem encontrada!");
            }

            HideObject();
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }
    }
}
