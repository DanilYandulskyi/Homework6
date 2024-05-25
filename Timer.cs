using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UI))]
public class Timer : MonoBehaviour
{
    private int _time;
    private bool _isGoing = false;
    private UI _ui;

    private void Awake()
    {
        _ui = GetComponent<UI>();
    }

    public void SwitchActivity()
    {
        if (_isGoing)
            Stop();
        else
            StartTimer();
    }

    private void Stop()
    {
        _isGoing = false;
        StopAllCoroutines();
    }

    private void StartTimer()
    {
        _isGoing = true;
        StartCoroutine(CountTime());
    }

    private IEnumerator CountTime()
    {
        yield return new WaitForSeconds(1);
        ++_time;
        _ui.UpdateText(_time.ToString());
        StartCoroutine(CountTime());
    }
}
