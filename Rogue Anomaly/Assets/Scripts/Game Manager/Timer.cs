using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] 
    [Range(0, 5)] 
    [Tooltip("Change the multiplier at which time will pass. 1 is real time rate")] 
    public float timeMulitiplier = 1;

    [SerializeField]
    [Tooltip("Any GameObjects containing a class realizing the IActionEvent interface")] 
    public List<GameObject> timedEvents;

    [SerializeField]
    [Tooltip("The cooldowns attached to the Timed Events. Match indexes")] 
    public List<float> timedEventCooldowns;

    // Get amount of seconds passed on timer
    public float elapsedTime {get; private set;}

    // Get time passed on timer in hh:mm:ss string format
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

    // Reset timer back to zero
    public void ResetTimer()
    {
        elapsedTime = 0;
    }

    // Start the timer
    public void StartTimer() 
    {
        StopCoroutine(RunTimer());
        StartCoroutine(RunTimer());
    }

    // Stop the timer
    public void StopTimer()
    {
        StopCoroutine(RunTimer());
    }

    // Coroutine method
    private IEnumerator RunTimer()
    {
        while (true) {
            for(int i = 0; i < timedEvents.Count; i++)
            {
                IActionEvent _event = timedEvents[i].GetComponent<IActionEvent>();
                if (_event == null)
                    continue;

                if (elapsedTime % timedEventCooldowns[i] == 0)
                {
                    _event.TriggerEvent(this.gameObject, "timerTick", elapsedTime);
                }
            }
            
            yield return new WaitForSeconds(1 / timeMulitiplier);
            elapsedTime++;
        }
    }
}
