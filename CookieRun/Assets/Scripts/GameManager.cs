using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public Text scoreUI;
    public GameObject gameOverUI;
    public Button restartBtn;

    [Header("ÇÁ¸®Æé")]
    public GameObject[] Obstacles;

    public int Score = 0;
    private bool isGameOver = false;

    private Transform _transform;

    void Start()
    {
        _transform = transform;

        StartCoroutine(GameFlowRoutine());
    }

    IEnumerator GameFlowRoutine()
    {
        while (!isGameOver)
        {
            //StartCoroutine(ObstacleRoutine());
            yield return StartCoroutine(ScoreRoutine());
        }

        yield return new WaitForSecondsRealtime(1f);
        gameOverUI.SetActive(true);
    }


    IEnumerator ObstacleRoutine()
    {
        yield return new WaitForSecondsRealtime(1.5f); 
        SpawnObstacle();
    }

    IEnumerator ScoreRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        Score++;
        scoreUI.text = $"Score:{Score}";
    }

    void SpawnObstacle()
    {
        var randomObst = Random.Range(0, Obstacles.Length);


    }
}
