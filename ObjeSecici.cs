using UnityEngine;

public class ObjeSecici : MonoBehaviour
{
    private static GameObject seciliObje; // Hangi objenin seçildiðini hafýzada tutar
    private SpriteRenderer sr;
    private Color orijinalRenk;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            orijinalRenk = sr.color;
        }
    }

    void OnMouseDown()
    {
        // Eski seçili olanýn rengini düzelt
        if (seciliObje != null && seciliObje.GetComponent<SpriteRenderer>() != null)
        {
            ObjeSecici eskiSecici = seciliObje.GetComponent<ObjeSecici>();
            if (eskiSecici != null)
            {
                eskiSecici.RengiSifirla();
            }
        }

        // Bu objeyi seçili yap ve rengini hafif sarýmsý/mavi yap
        seciliObje = this.gameObject;
        if (sr != null)
        {
            sr.color = new Color(0.8f, 0.8f, 1f, 1f); // Hafif mavi tonu
        }
    }

    void Update()
    {
        // Eðer bu obje seçiliyse ve Delete/Backspace tuþuna basýlýrsa sil
        if (seciliObje == this.gameObject && (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace)))
        {
            // Önce bu objeye baðlý kablolarý temizle
            KabloTemizle();

            // Objeyi yok et
            Destroy(gameObject);
            seciliObje = null;
        }

        // --- YENÝ EKLENEN KISIM ---
        // Eðer herhangi bir obje seçiliyse ve ESC tuþuna basýlýrsa seçimi iptal et
        if (seciliObje == this.gameObject && Input.GetKeyDown(KeyCode.Escape))
        {
            SecimiTemizle();
        }
    }

    public void RengiSifirla()
    {
        if (sr != null)
        {
            sr.color = orijinalRenk;
        }
    }

    void KabloTemizle()
    {
        KabloTakip[] tumKablolar = Object.FindObjectsByType<KabloTakip>(FindObjectsInactive.Include);
        foreach (KabloTakip kablo in tumKablolar)
        {
            if (kablo != null)
            {
                if (kablo.baslangicObje != null && kablo.baslangicObje.IsChildOf(transform)) Destroy(kablo.gameObject);
                if (kablo.bitisObje != null && kablo.bitisObje.IsChildOf(transform)) Destroy(kablo.gameObject);
            }
        }
    }

    // Tahtaya basýnca veya ESC'ye basýnca çalýþacak sýfýrlama fonksiyonu
    public static void SecimiTemizle()
    {
        if (seciliObje != null)
        {
            ObjeSecici secici = seciliObje.GetComponent<ObjeSecici>();
            if (secici != null)
            {
                secici.RengiSifirla();
            }
            seciliObje = null;
        }
    }
}