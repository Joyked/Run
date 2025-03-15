using UnityEngine;
using UnityEngine.SceneManagement;

public class SeterBackMenu : MonoBehaviour
{
    private TuchButton _button;

    public void Initialized(TuchButton button)
    {
        _button = button;
        _button.ButtonPressed += RestartScene;
    }

    private void OnDisable() => _button.ButtonPressed -= RestartScene;

    private void RestartScene()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }
}
