Muhtasar Beyanname Düzenleyici (MBD) 📑
Türkiye vergi mevzuatına uygun, Gelir İdaresi Başkanlığı (GİB) e-Beyanname sistemleri ile tam uyumlu XML çıktısı üreten, kullanıcı dostu bir masaüstü uygulamasıdır.

🚀 Projenin Amacı
Bu uygulama; işletmelerin, mali müşavirlerin veya vergi sorumlularının, tevkifata (stopaj) tabi ödemelerini (personel maaşı, kira, serbest meslek makbuzu vb.) dijital ortamda düzenleyip GİB sistemine yüklemeye hazır hale getirmesini sağlamak amacıyla geliştirilmektedir.

✨ Temel Özellikler
GİB / BDP Uyumluluğu: Oluşturulan XML dosyaları Beyanname Düzenleme Programı ile %100 uyumludur.

Akıllı Hesaplama Motoru: Güncel gelir vergisi dilimleri ve damga vergisi oranlarını kullanarak otomatik stopaj hesaplama.

SQLite Veri Yönetimi: Tüm beyanname ve mükellef geçmişini yerel bir veritabanında güvenle saklama.

Excel Entegrasyonu: Personel listesi veya kira ödemelerini Excel üzerinden toplu olarak içe aktarma.

Modern Arayüz: Hızlı veri girişi için optimize edilmiş kullanıcı deneyimi.

🛠️ Kullanılan Teknolojiler
Dil: C# / .NET 9.0

Arayüz: WPF (Windows Presentation Foundation)

Veritabanı: SQLite

XML İşleme: System.Xml.Serialization

📂 Proje Yapısı
Plaintext
/src                # Kaynak kodlar
/docs               # GİB XML şemaları ve mevzuat dökümanları
/assets             # Uygulama ikonları ve görseller
/tests              # Hesaplama motoru için birim testler
⚙️ Kurulum ve Çalıştırma
Bu repository'yi bilgisayarınıza clone'layın:

Bash
git clone [https://github.com/ybguclu/muhtasar-beyanname.git
Visual Studio 2022 veya güncel bir .NET IDE'si ile .sln dosyasını açın.

Gerekli NuGet paketlerini (SQLite-net, MaterialDesignThemes vb.) geri yükleyin.

Projeyi derleyin ve çalıştırın.

📜 Lisans
Bu proje MIT Lisansı altında lisanslanmıştır. Daha fazla bilgi için LICENSE dosyasına göz atabilirsiniz.
