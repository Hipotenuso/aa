using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHellper : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
