using System.Collections;
using UnityEngine;

public class DayToNight : MonoBehaviour
{
    [SerializeField] private float turn = 0.1f;

    public bool Night
    {
        get
        {
            if (transform.rotation.x <= 0f)
                return true;
            else
                return false;
        }
    }
    private void OnEnable()
    {
        StartCoroutine(RotateSun());
    }
    private IEnumerator RotateSun()
    {
        while (enabled)
        {
            transform.RotateAround(transform.position, Vector3.forward, turn);
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
    private void OnDisable()
    {
        StopCoroutine(RotateSun());
    }
}
