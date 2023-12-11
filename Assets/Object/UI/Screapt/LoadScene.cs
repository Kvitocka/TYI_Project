using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void loadScenePlay1 (){
        SceneManager.LoadScene("PlayScene1");
    }
    public void loadScenePlay2 (){
        SceneManager.LoadScene("PlayScene2");
    }
    public void loadSceneMeny (){
        SceneManager.LoadScene("meny");
    }
}
