using UnityEngine;

public class ObstacleSpawner : GameManager
{
    public float speed = 5f;

    public void SpawnObstacle()
    {
        var randomObst = Random.Range(0, obstacles.Length);
        GameObject prefab = Resources.Load<GameObject>(obstacles[randomObst].name);

        GameObject obst = Instantiate(prefab);

        MoveObstacle(obst);
    }

    public void MoveObstacle(GameObject _obst)
    {
        transform.Translate(Vector3.left * speed);

        if(transform.position.x < -10f)
        {
            Destroy(_obst);
        }
    }
}
