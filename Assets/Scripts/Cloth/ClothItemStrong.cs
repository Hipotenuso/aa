using UnityEngine;

namespace Cloth
{
    public class ClothItemStrong : Clothitembase
    {
        public int cloth2 = 2;
        public float damageMultiply = .5f;

        public override void Collect()
        {
            base.Collect();

            if (player == null)
            {
                Debug.LogError("Player está nulo em ClothItemStrong!");
                return;
            }

            if (player.healthBase == null)
            {
                Debug.LogError("healthBase está nulo no Player!");
                return;
            }

            player.healthBase.ChangeDamageMultiply(damageMultiply, duration);
        }
    }
}
