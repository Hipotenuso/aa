using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndGame : MonoBehaviour
{
    private SaveManager saveManager;
    public List<GameObject> endGameObjects;
    private bool _endGame = false;

    public int currentLevel = 1;

    void Awake()
    {
        if(saveManager == null) saveManager = FindFirstObjectByType<SaveManager>();
        endGameObjects.ForEach(i => i.SetActive(false));
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerNew p = other.transform.GetComponent<PlayerNew>();

        if(!_endGame && p != null)
        {
            ShowEndGame();
        }
    }

    public void ShowEndGame()
    {
        _endGame = true;
        endGameObjects.ForEach(i => i.SetActive(true));
        foreach(var i in endGameObjects)
        {
            i.SetActive(true);
            i.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
            saveManager.SaveLastLevel(currentLevel);
        }
    }
}
