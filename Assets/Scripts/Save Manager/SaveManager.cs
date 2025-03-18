using UnityEngine;
using System.IO;
using System;
using Itens;
using Mono.Cecil.Cil;
using Cloth;

public class SaveManager : MonoBehaviour
{
    private string _path = Application.dataPath + "/save.txt";
    public int lastLevel;
    public Action<SaveSetup> FileLoaded;
    [SerializeField] private SaveSetup _saveSetup;
    public ItemManager itemManager;
    public Clothitembase _cloth;
    public PlayerNew _pLife;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        itemManager = FindFirstObjectByType<ItemManager>();
    }

    private void CreateNewSave()
    {
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 0;
        _saveSetup.playerName = "TestName";
    }

    void Start()
    {
        Invoke(nameof(Load), .1f);
    }

    #region SAVE
    public void SaveItens()
    {
        _saveSetup.coins = itemManager.GetByType(Itens.ItemType.Coin).soInt.value;
        _saveSetup.health = itemManager.GetByType(Itens.ItemType.Life_pack).soInt.value;
        Save();
    }

    [NaughtyAttributes.Button]
    private void Save()
    
    {
        string setupToJson = JsonUtility.ToJson(_saveSetup, true);
        Debug.Log(setupToJson);
        SaveFile(setupToJson);
    }

    private void SaveLifeAndCloth(string sc, int i)
    {
        _saveSetup.cloth = _cloth.ActualCloth;
        _saveSetup.life = _pLife.healthBase.ALife;
        Save();
    }

    public void SaveName(string s)
    {
        _saveSetup.playerName = s;
        Save();
    }

    public void SaveLastLevel(int level)
    {
        _saveSetup.lastLevel = level;
        SaveItens();
        Save();
    }
    #endregion

    private void SaveFile(string json)
    {
        
        Debug.Log(_path);

        File.WriteAllText(_path, json);
    }

    [NaughtyAttributes.Button]
    private void SaveLevelOne()
    {
        SaveLastLevel(1);
    }

    [NaughtyAttributes.Button]
    private void SaveLevelFive()
    {
        SaveLastLevel(5);
    }

    [NaughtyAttributes.Button]
    private void Load()
    {
        string fileLoaded = "";

        if(File.Exists(_path))
        {
            fileLoaded = File.ReadAllText(_path);
            _saveSetup = JsonUtility.FromJson<SaveSetup>(fileLoaded);

            lastLevel = _saveSetup.lastLevel;
        }
        else
        {
            CreateNewSave();
            Save();
        }
            


        FileLoaded?.Invoke(_saveSetup);
    }

    public SaveSetup Setup
    {
        get
        {
            return _saveSetup;
        }
    }

}








[System.Serializable]
public class SaveSetup
{
    public int lastLevel;
    public float coins;
    public float health;
    public string playerName;
    public int cloth;
    public float life;
}
