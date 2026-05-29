using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneGecis : MonoBehaviour
{
    public void IstediginSahneyeGit(string sahneAdi)
    {
        SceneManager.LoadScene(sahneAdi);
    }
}