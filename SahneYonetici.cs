using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yönetimi için bu şart!

public class SahneYonetici : MonoBehaviour
{
    public void SahneyiSifirla()
    {
        // Şu an hangi sahnedeysek onu bul ve tekrar yükle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
public void IstediginSahneyeGit(string sahneAdi)
{
    SceneManager.LoadScene(sahneAdi);
}
}