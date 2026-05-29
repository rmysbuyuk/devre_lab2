using UnityEngine;

public class IletkenlikYonetici : MonoBehaviour
{
    public GameObject acikDevreGorseli; // Yanan devre resmi
    public GameObject dogruPopup;       // Tebrikler popup'ı
    public GameObject yanlisPopup;      // Yanlış popup'ı

    private void OnTriggerStay2D(Collider2D other)
    {
        // Eğer öğrenci maddeyi bıraktıysa (Fare basılı değilse)
        if (!Input.GetMouseButton(0))
        {
            MaddeOzelligi madde = other.GetComponent<MaddeOzelligi>();

            if (madde != null)
            {
                if (madde.iletkenMi)
                {
                    // Objeler sahnede varsa (silinmediyse) aktif et
                    if (acikDevreGorseli != null) acikDevreGorseli.SetActive(true);
                    if (dogruPopup != null) dogruPopup.SetActive(true);
                }
                else
                {
                    // Obje sahnede varsa aktif et
                    if (yanlisPopup != null) yanlisPopup.SetActive(true);
                }
            
            }
        }
    }
}