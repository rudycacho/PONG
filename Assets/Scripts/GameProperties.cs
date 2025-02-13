using UnityEngine;

public class GameProperties : MonoBehaviour
{
    public static bool CPUMode = false;
    public static bool EnablePowerUps = true;
    
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void TogglePowerUp(bool enable)
    {
        EnablePowerUps = enable;
        Debug.Log(EnablePowerUps);
    }

    public void enableCPU()
    {
        CPUMode = true;
        Debug.Log("CPU mode enabled");
    }

    public void disableCPU()
    {
        CPUMode = false;
        Debug.Log("CPU mode disabled");
    }
}
