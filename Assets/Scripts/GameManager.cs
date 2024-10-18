using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> GameItems = new List<GameObject>();

    public TMPro.TextMeshProUGUI scoreText;
    private int score = 0;

    public bool isGameActive;
    public bool isStartGame;

    public TMPro.TextMeshProUGUI gameOverText;
    public TMPro.TextMeshProUGUI titre;
    public Button restartGame;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(InstantiateObjects());

        GameOver();

        isGameActive = true;
        isStartGame = true;   
    }

    // Instancier les objets
    IEnumerator InstantiateObjects()
    {
        yield return new WaitForSeconds(1f);
        while (isGameActive && isStartGame)
        {
            foreach (GameObject item in GameItems)
            {
                int listLenght = Random.Range(0, GameItems.Count);
                Instantiate(GameItems[listLenght], new Vector3(Random.Range(-5f, 5f), 0, 0), Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(0.1f, 1f));
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    // --- Méthodes pour le score ---
    void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }

    // Augmenter le score
    public void IncreaseScore()
    {
        score += 5;
        UpdateScore();
    }

    // Diminuer le score
    public void DecreaseScore()
    {
        score -= 5;
        UpdateScore();
    }

    // Affichage de GameOver
    public void GameOver()
    {
        if (score < 0)
        {
            gameOverText.gameObject.SetActive(true);
            restartGame.gameObject.SetActive(true);
            isGameActive = false;
        }       
    }

    // Méthode pour redémarrer le jeu
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

    

