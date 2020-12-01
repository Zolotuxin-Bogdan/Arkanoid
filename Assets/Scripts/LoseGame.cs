using UnityEngine;

public class LoseGame : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            BallManager.Instance.DestroyBall(col.gameObject);
        }
    }
}
