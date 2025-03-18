using UnityEngine;

namespace Cloth
{
    public class ClothItemSpeed : Clothitembase
    {
        public int cloth1 = 1;
        public float targetSpeed;
        public override void Collect()
        {
            base.Collect();
            player.ChangeSpeed(targetSpeed, duration);
        }
    }

}
