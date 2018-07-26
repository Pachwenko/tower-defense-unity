using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour {
    public void LoadScene() {
        SceneManager.LoadScene("Level1");
    }
}
