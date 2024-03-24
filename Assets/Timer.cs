using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private IEnumerator _timerCoroutine;

    private float _delay = 0.5f;

    private bool _isWork = false;

    private void Start()
    {
        _timerCoroutine = CountUp(_delay);
    }

    private IEnumerator CountUp(float delay)
    {
        var wait = new WaitForSeconds(delay);

        for (int i = 0; i >= 0; i++)
        {
            DisplayCountUp(i);
            yield return wait;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isWork = !_isWork;
        }

        if (_isWork)
        {
            StartCoroutine(_timerCoroutine);
        }
        else
        {
            StopCoroutine(_timerCoroutine);
        }
    }

    private void DisplayCountUp(int count)
    {
        _text.text = count.ToString("");
    }
}