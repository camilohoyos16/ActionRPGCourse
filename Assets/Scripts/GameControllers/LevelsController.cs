using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsController : MonoBehaviour {

    public void LoadLevel() {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = ++currentLevel;
        SceneManager.LoadScene(nextLevel);
    }

}
