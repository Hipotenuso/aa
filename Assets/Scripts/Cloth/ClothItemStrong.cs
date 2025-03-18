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
            player.healthBase.ChangeDamageMultiply(damageMultiply, duration);
        }
    }
}
