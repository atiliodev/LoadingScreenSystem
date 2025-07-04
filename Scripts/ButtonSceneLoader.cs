using UnityEngine;
using UnityEngine.UI;

public class ButtonSceneLoader : MonoBehaviour
{
    private Button button;
    public SceneLoader sceneLoaderPainel;
    public string sceneName;

    private void Start() { button = GetComponent<Button>(); }

    private void Update() { button.onClick.AddListener(LoadScene); }

    private void LoadScene() { sceneLoaderPainel.LoadScene(sceneName); Debug.Log("Starting to load the scene..."); }
}
