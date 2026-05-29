using UnityEngine;
using UnityEngine.SceneManagement; // Sahneler arası geçiş için bu şart!

public class SahneKontrol : MonoBehaviour
{
    public void ParlaklikSahnesineGit()
    {
        SceneManager.LoadScene("ParlaklikDeneyi");
    }

    public void IletkenlikSahnesineGit()
    {
        SceneManager.LoadScene("IletkenlikTesti");
    }

    // Şablonlarımızı buraya tanıtacağız
    public GameObject pilPrefab;
    public GameObject ampulPrefab;
    public GameObject anahtarPrefab;

    // Masaya Pil koyan fonksiyon
    public void PilOlustur()
    {
        // Masanın ortasına (0,0,0) bir pil fırlatır
        Instantiate(pilPrefab, Vector3.zero, Quaternion.identity);
    }

    public void AmpulOlustur()
    {
        Instantiate(ampulPrefab, Vector3.zero, Quaternion.identity);
    }

    public void AnahtarOlustur()
    {
        Instantiate(anahtarPrefab, Vector3.zero, Quaternion.identity);
    }

    // Önceki yazdığın sahne geçiş kodları burada kalmaya devam etsin...
    public void AnaMenuyeGit() { SceneManager.LoadScene("GirisEkrani"); }
}
