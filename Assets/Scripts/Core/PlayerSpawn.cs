using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;

    [SerializeField] private Animator[] playerAnimator;
    [SerializeField] private GameObject[] playerGameObject;

    private void Awake()
    {
        for (int i = 0; i < playerAnimator.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("SelectedCharacter"))
            {
                playerGameObject[i].SetActive(true);
                player.SetPlayerAnimator(playerAnimator[i]);
                player.SetPlayerSprite(playerGameObject[i]);
            }
            else
            {
                playerGameObject[i].SetActive(false);
            }
        }
    }
}
