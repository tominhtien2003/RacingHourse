using Cinemachine;
using System;
using System.Collections;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public event EventHandler OnGameOver;
    [SerializeField] private CinemachineVirtualCamera camGameOver;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("--");
        StartCoroutine(IEGameOver());
    }
    private IEnumerator IEGameOver()
    {
        Time.timeScale = .3f;
        camGameOver.Priority = 20;
        yield return new WaitForSeconds(2f);
        camGameOver.Priority = 0;
        Time.timeScale = 0f;
        OnGameOver?.Invoke(this, EventArgs.Empty);
    }
}
