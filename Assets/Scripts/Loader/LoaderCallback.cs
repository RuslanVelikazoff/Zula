using UnityEngine;
using UnityEngine.UI;

public class LoaderCallback : MonoBehaviour
{
    [SerializeField] 
    private Slider loadingSlider;

    private float timeLoading = 2f;
    private float timeLeft;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (timeLeft < timeLoading)
        {
            timeLeft += Time.deltaTime;
            loadingSlider.value = timeLeft;
        }
        else
        {
            Loader.LoaderCallback();
        }
    }
}
