using UnityEngine;
using UnityEngine.InputSystem; // Yeni Giriş Sistemi için

public class KabloTakip : MonoBehaviour
{
    public Transform baslangicObje;
    public Transform bitisObje;
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Temel Kontrol: Başlangıç objesi (kırmızı nokta) yoksa çizme
        if (baslangicObje == null) return;

        Vector3 s = baslangicObje.position;
        Vector3 e; // Bitiş noktası

        // DURUM 1: Eğer kablo bir yere BAĞLANDIYSA (bitisObje varsa)
        if (bitisObje != null)
        {
            e = bitisObje.position;
            s.z = 0; e.z = 0;

            line.positionCount = 3; // 3 noktalı dirsekli kablo
            line.SetPosition(0, s);

            // Dinamik Dirsek Hesaplaması (Daha önce yazdığımız akıllı mantık)
            if (Mathf.Abs(s.x - e.x) > Mathf.Abs(s.y - e.y))
            {
                line.SetPosition(1, new Vector3(e.x, s.y, 0)); // Yatay ağırlıklı
            }
            else
            {
                line.SetPosition(1, new Vector3(s.x, e.y, 0)); // Dikey ağırlıklı
            }

            line.SetPosition(2, e);
        }
        // DURUM 2: Eğer hala SÜRÜKLENİYORSA (bitisObje henüz yok)
        else
        {
            // Yeni Giriş Sistemi ile farenin dünyadaki pozisyonunu al
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
            e = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            s.z = 0; e.z = 0;

            // Sürükleme anında kabloyu DÜZ ÇİZ (2 noktalı)
            // Böylece o "boşlukta uçuşan dirsek" görüntüsü oluşmaz.
            line.positionCount = 2; 
            line.SetPosition(0, s);
            line.SetPosition(1, e); // Fareyi takip eden uç
        }
    }
}