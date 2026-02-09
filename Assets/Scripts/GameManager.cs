using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Score = 0;
    private bool isGameOver = false;
    public Text scoreUI;

    private void Awake()
    {

    }

    void Start()
    {


        StartCoroutine(CountScore());
    }

    IEnumerator CountScore()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1.0f);
            Score++;
        }

    }

    void Update()
    {
        
    }
}
