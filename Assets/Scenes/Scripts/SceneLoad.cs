using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] private string sceneName;


    private bool _isload = false;

    public void OnTriggerEnter(Collider collision)
    {
        LoadSceneAdditive();
    }

    private void LoadSceneAdditive()
    {
        if (!_isload) 
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            _isload = true;
        }
        
        

    }
}
