using UnityEngine;

public class LoseGame : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Destroy(col.gameObject);
            BallManager.Instance.DecreaseBallCount();
        }
    }
}
