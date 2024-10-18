using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DifficultyButton : MonoBehaviour
{

    public Button easyLevel;
    public Button mediumLevel;
    public Button hardLevel;


    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
    }

    // Niveau facile
    public void easyDifficulty()
    {
        
    }

    // Niveau moyen
    public void mediumDifficulty()
    {
        
    }

    // Niveau difficile
    public void hardDifficulty()
    {
        
    }
    
}
