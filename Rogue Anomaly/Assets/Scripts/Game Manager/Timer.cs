using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField, Range(0, 5), Tooltip("Change the multiplier at which time will pass. 1 is real time rate")] float timeMulitiplier = 1;
    [SerializeField, Tooltip("All elements used for visualizing the gametimer")] public List<GameObject> frontendElements;

    public float elapsedTime {get; private set;}
    public string elapsedTimeString {
        get {
            System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(elapsedTime);
            return timeSpan.ToString(@"hh\:mm\:ss");
        }
    }

    void Start()
    {
        StartTimer();
    }

    public void ResetTimer()
    {
        elapsedTime = 0;
    }

    public void StartTimer() 
    {
        StopCoroutine(RunTimer());
        StartCoroutine(RunTimer());
    }

    public void StopTimer()
    {
        StopCoroutine(RunTimer());
    }

    private IEnumerator RunTimer()
    {
        while (true) {
            foreach (GameObject timer in frontendElements)
            {
                TextMeshProUGUI text = timer.GetComponent<TextMeshProUGUI>();
                if (text != null)
                    text.SetText(elapsedTimeString);
            }

            yield return new WaitForSeconds(1 / timeMulitiplier);
            elapsedTime++;
        }
    }
}
