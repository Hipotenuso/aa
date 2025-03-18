using System.Collections.Generic;
using UnityEngine;

namespace Cloth
{
    public enum ClothType
    {
        Speed,
        Strong
    }
    public class ClothManager : MonoBehaviour
    {
        public List<ClothSetup> clothSetups;

        public ClothSetup GetSetupByType(ClothType clothType)
        {
            return clothSetups.Find(i => i.clothType == clothType);
        }
    }

    [System.Serializable]
    public class ClothSetup
    {
        public ClothType clothType;
        public Texture2D texture;
    }
}
