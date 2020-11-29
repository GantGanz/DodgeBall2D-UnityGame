using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void MulaiPermainan()
    {
        SceneManager.LoadScene("Main");
    }
    public void MulaiPermainan2()
    {
        SceneManager.LoadScene("Main2");
    }

    public void KembaliKeMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void MasukCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void MasukPetunjuk()
    {
        SceneManager.LoadScene("Petunjuk");
    }
    public void MasukSettings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void MulaiPermainanE()
    {
        SceneManager.LoadScene("MainE");
    }
    public void MulaiPermainan2E()
    {
        SceneManager.LoadScene("Main2E");
    }

    public void KembaliKeMenuE()
    {
        SceneManager.LoadScene("MenuE");
    }

    public void MasukCreditsE()
    {
        SceneManager.LoadScene("CreditsE");
    }
    public void MasukPetunjukE()
    {
        SceneManager.LoadScene("PetunjukE");
    }
    public void MasukSettingsE()
    {
        SceneManager.LoadScene("SettingsE");
    }
}