using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoCarousel : MonoBehaviour
{
    public ScrollRect scrollRect;
    public int numberOfPages = 3;
    public float timeBetweenPages = 3f;
    public float slideSpeed = 2f;

    public Image[] dots;
    public Color activeColor = Color.white;
    public Color inactiveColor = Color.gray;

    private int currentPage = 0;

    void Start()
    {
        UpdateDots();
        StartCoroutine(AutoSlide());
    }

    void UpdateDots()
    {
        for (int i = 0; i < dots.Length; i++)
        {
            dots[i].color =
                i == currentPage
                ? activeColor
                : inactiveColor;
        }
    }

    IEnumerator AutoSlide()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenPages);

            currentPage++;

            if (currentPage >= numberOfPages)
                currentPage = 0;

            UpdateDots();

            float target =
                (float)currentPage / (numberOfPages - 1);

            while (
                Mathf.Abs(scrollRect.horizontalNormalizedPosition - target) > 0.001f)
            {
                scrollRect.horizontalNormalizedPosition =
                    Mathf.Lerp(
                        scrollRect.horizontalNormalizedPosition,
                        target,
                        slideSpeed * Time.deltaTime);

                yield return null;
            }

            scrollRect.horizontalNormalizedPosition = target;
        }
    }
}