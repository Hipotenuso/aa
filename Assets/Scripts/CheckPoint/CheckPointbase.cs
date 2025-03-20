using UnityEngine;

public class CheckPointbase : MonoBehaviour
{
    public CPmanager cPmanager;
    public MeshRenderer meshRenderer;
    public int key = 1;
    private bool checkPointActived = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!checkPointActived && other.CompareTag("Player"))
        {
            Debug.Log("Checkpoint atingido: " + key);
            CheckCheckPoint();
        }
    }

    private void CheckCheckPoint()
    {
        TurnItOn();
        SaveCheckPoint();
    }

    [NaughtyAttributes.Button]
    private void TurnItOn()
    {
        Debug.Log("Checkpoint ativado: " + key);
    }

    private void SaveCheckPoint()
    {
        cPmanager.SaveCheckPoint(key);
        checkPointActived = true;
    }
}