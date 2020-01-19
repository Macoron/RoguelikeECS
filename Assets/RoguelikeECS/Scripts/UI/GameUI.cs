using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public PauseMenu pauseMenu;
    private bool isPauseShown;

    private void Awake()
    {
        EnablePauseMenu(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPauseShown = !isPauseShown;
            EnablePauseMenu(isPauseShown);
        }
    }

    public void EnablePauseMenu(bool isEnabled)
    {
        pauseMenu?.gameObject.SetActive(isEnabled);
    }
}
