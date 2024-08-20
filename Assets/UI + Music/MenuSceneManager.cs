using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    [SerializeField] private string firstLevelScene;
    public void PlayGame()
    {
        SceneManager.LoadScene(firstLevelScene);
    }
}
