# Muhtasar Beyanname Düzenleyici (C# WPF)

Bu repo, ekran görünümü klasik GİB beyanname düzenleme stiline benzeyecek şekilde hazırlanmış bir **WPF masaüstü uygulaması** içerir.

## Neler Var?

- Sekmeli üst menü yapısı (Genel Bilgiler, Vergiye Tabi İşlemler, Ödemeler, vb.)
- İdari bilgiler, şube no, vergi sorumlusu ve dosya işlemleri bölümleri
- Görsel olarak örnek ekrandaki yerleşime benzer mavi/klasik form düzeni
- Hızlı stopaj kalemleri tablosu (otomatik stopaj/net hesaplama)
- XML dosyası oluşturma

## Proje Yapısı

- `src/MuhtasarBeyannameWpf/MainWindow.xaml`: Formun arayüzü
- `src/MuhtasarBeyannameWpf/MainWindow.xaml.cs`: Olaylar ve iş kuralları
- `src/MuhtasarBeyannameWpf/Models/StopajKalemi.cs`: Stopaj hesap modeli
- `src/MuhtasarBeyannameWpf/Services/XmlBeyannameYazici.cs`: XML yazdırma servisi

## Çalıştırma

```bash
cd src/MuhtasarBeyannameWpf
dotnet run
```

> Not: Gerçek üretim kullanımında GİB şema doğrulaması ve mevzuat kontrolleri ayrıca eklenmelidir.
