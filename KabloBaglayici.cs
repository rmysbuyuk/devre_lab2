using UnityEngine;
using UnityEngine.InputSystem;

public class KabloBaglayici : MonoBehaviour
{
    public GameObject kabloPrefab;
    private LineRenderer mevcutKablo;
    private GameObject baslangicNoktasi;

    void Update()
    {
        // 1. FAREYE İLK BASILDIĞINDA (Kabloyu başlat)
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero);
            
            if (hit.collider != null && hit.collider.CompareTag("Baglanti"))
            {
                baslangicNoktasi = hit.collider.gameObject;
                GameObject yeniKabloObj = Instantiate(kabloPrefab);
                mevcutKablo = yeniKabloObj.GetComponent<LineRenderer>();
                
                // Kabloya hemen baslangic noktasını tanıtalım (KabloTakip.cs sayesinde)
                KabloTakip takip = yeniKabloObj.AddComponent<KabloTakip>();
                takip.baslangicObje = baslangicNoktasi.transform;
            }
        }

        // 2. FARE BASILI TUTULURKEN (Kabloyu uzat)
        if (Mouse.current.leftButton.isPressed && mevcutKablo != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePos.z = 0;
            mevcutKablo.SetPosition(1, mousePos);
        }

        // 3. FARE BIRAKILDIĞINDA (Kabloyu bağla veya yok et)
        if (Mouse.current.leftButton.wasReleasedThisFrame && mevcutKablo != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Baglanti") && hit.collider.gameObject != baslangicNoktasi)
            {
                // Hedefe başarıyla bağlandık
                KabloTakip takip = mevcutKablo.GetComponent<KabloTakip>();
                takip.bitisObje = hit.collider.transform;
            }
            else
            {
                // Boşluğa bırakıldıysa kabloyu sil
                Destroy(mevcutKablo.gameObject);
            }

            // Temizlik
            mevcutKablo = null;
            baslangicNoktasi = null;
        }
    }
}