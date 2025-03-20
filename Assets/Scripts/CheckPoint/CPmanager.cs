using System.Collections.Generic;
using UnityEngine;

public class CPmanager : MonoBehaviour
{
    public List<CheckPointbase> checkPoints = new List<CheckPointbase>();
    public int lastCheckPoint = 0;

    void Start()
    {
        // Preenche a lista com todos os checkpoints na cena, caso não estejam atribuídos manualmente
        if (checkPoints.Count == 0)
        {
            checkPoints = new List<CheckPointbase>(FindObjectsByType<CheckPointbase>(FindObjectsSortMode.None));
        }
    }

    public bool HasCheckPoint()
    {
        return lastCheckPoint > 0;
    }

    public void SaveCheckPoint(int i)
    {
        if (i > lastCheckPoint)
        {
            lastCheckPoint = i;
            Debug.Log("Checkpoint salvo: " + lastCheckPoint);
        }
    }

    public Vector3 GetPositionToRespawn()
    {
        var checkpoint = checkPoints.Find(i => i.key == lastCheckPoint);

        if (checkpoint != null)
        {
            Debug.Log("Respawn no checkpoint: " + lastCheckPoint);
            return checkpoint.transform.position;
        }

        Debug.LogWarning("Nenhum checkpoint encontrado! Retornando posição inicial.");
        return Vector3.zero;
    }
}
