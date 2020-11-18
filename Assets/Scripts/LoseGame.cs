using UnityEngine;

public class LoseGame : MonoBehaviour
{
    public bool IsLose;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            IsLose = true;
        }
    }
}
