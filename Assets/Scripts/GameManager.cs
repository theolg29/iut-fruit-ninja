using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> GameItems = new List<GameObject>();

    public TMPro.TextMeshProUGUI scoreText;
    private int score = 0;

    public bool isGameActive;

    public TMPro.TextMeshProUGUI gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(InstantiateObjects());

        GameOver();
    }
    // Coroutine to instantiate objects with a delay
    IEnumerator InstantiateObjects()
    {
        while (true)
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
        
    }

    // Méthodes pour le score
    void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }

    public void IncreaseScore()
    {
        score += 5;
        UpdateScore();
    }

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
        }       
    }

}
