using UnityEngine;
using UnityEngine.UI; // Buton resmini değiştirmek için bu şart!

public class SesYonetici : MonoBehaviour
{
    public Sprite sesAcikSprite;   // Ses açıkken görünecek resim
    public Sprite sesKapaliSprite; // Ses kapalıyken görünecek resim

    private Image butonImage;      // Butonun kendi resim bileşeni
    private bool sesAçikMi = true; // Sesin durumunu tutan hafıza

    void Start()
    {
        // Butonun üzerindeki Image bileşenini otomatik bulur
        butonImage = GetComponent<Image>();

        // Oyun ilk açıldığında ses durumunu kontrol et
        AudioListener.pause = false;
    }

    // Butona tıklandığında çalışacak fonksiyon
    public void SesiAcKapat()
    {
        sesAçikMi = !sesAçikMi; // Durumu tersine çevir (Açıksa kapat, kapalıysa aç)

        if (sesAçikMi)
        {
            AudioListener.pause = false;      // Unity'nin tüm seslerini aç
            butonImage.sprite = sesAcikSprite; // Buton resmini 'Ses Açık' yap
            Debug.Log("Ses Açıldı");
        }
        else
        {
            AudioListener.pause = true;         // Unity'nin tüm seslerini tamamen kıs (Mute)
            butonImage.sprite = sesKapaliSprite; // Buton resmini 'Ses Kapalı' yap
            Debug.Log("Ses Kısıldı");
        }
    }
}