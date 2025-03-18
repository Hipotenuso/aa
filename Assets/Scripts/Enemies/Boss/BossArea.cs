using UnityEngine;

public class BossArea : MonoBehaviour
{
    public GameObject Boss;
    public Collider AggroSpawn;
    public GameObject bossCamera;
    public Color gizmoColor = Color.yellow;
    public string tagoToCheck = "Player";
    private void Awake()
    {
        bossCamera.SetActive(false);
        Boss.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == tagoToCheck)
        {
            Boss.SetActive(true);
            TurnOnCamera();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == tagoToCheck)
        {
            TurnOffCamera();
        }
    }

    private void TurnOnCamera()
    {
        bossCamera.SetActive(true);
    }

    private void TurnOffCamera()
    {
        bossCamera.SetActive(false);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, transform.localScale.y);
    }
}