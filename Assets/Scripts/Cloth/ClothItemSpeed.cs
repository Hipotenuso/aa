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

            if (player == null)
            {
                Debug.LogError("Player está nulo! Não foi possível coletar o item.");
                return;
            }

            if (targetSpeed <= 0)
            {
                Debug.LogError("targetSpeed inválido! O valor de targetSpeed deve ser maior que 0.");
                return;
            }

            player.ChangeSpeed(targetSpeed, duration); // Executa a lógica específica
        }
    }
}
