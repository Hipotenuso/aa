using UnityEngine;

namespace Cloth
{
    public class ClothItemSpeed : Clothitembase
    {  
        public int cloth1 = 1;
        public float targetSpeed;
        public override void Collect()
        {
            base.Collect(); // Executa a lógica da classe base
            player.ChangeSpeed(targetSpeed, duration); // Executa a lógica específica
        }
    }

}
