using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    private void Awake()
    {
        Button button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
            });
        }
    }
}
