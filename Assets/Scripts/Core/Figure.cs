using UnityEngine;

public class Figure : MonoBehaviour
{
    [SerializeField] private bool isGoal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            
            if (isGoal)
            {
                AudioManager.Instance.Play("Goal");
                GoalManager.Instance.CollectedGoal();
            }
            else
            {
                PlayerHealth.Instance.Damage();
            }
        }
    }
}
