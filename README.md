# Muhtasar Beyanname Düzenleyici (WPF)

Bu proje, **C# + WPF** ile hazırlanmış örnek bir "Muhtasar Beyanname" masaüstü uygulamasıdır.
Kullanıcıdan mükellef bilgilerini ve stopaj kalemlerini alır, toplamları otomatik hesaplar ve veriyi XML çıktısı olarak kaydeder.

## Özellikler

- Mükellef ünvanı ve vergi numarası girişi
- Dinamik stopaj kalemi tablosu (Açıklama / Brüt / Oran)
- Otomatik hesaplanan alanlar:
  - Stopaj tutarı
  - Net ödenecek tutar
- Toplam brüt / stopaj / net özet alanı
- XML dosyası dışa aktarma

## Proje Yapısı

- `src/MuhtasarBeyannameWpf/MuhtasarBeyannameWpf.csproj`: WPF proje dosyası
- `src/MuhtasarBeyannameWpf/MainWindow.xaml`: Ana ekran tasarımı
- `src/MuhtasarBeyannameWpf/MainWindow.xaml.cs`: Uygulama iş mantığı
- `src/MuhtasarBeyannameWpf/Models/StopajKalemi.cs`: Stopaj kalemi modeli
- `src/MuhtasarBeyannameWpf/Services/XmlBeyannameYazici.cs`: XML dışa aktarma servisi

## Çalıştırma

1. .NET SDK (Windows üzerinde) kurulu olmalıdır.
2. Proje klasörüne gidin:

```bash
cd src/MuhtasarBeyannameWpf
```

3. Uygulamayı başlatın:

```bash
dotnet run
```

## Not

Bu uygulama bir başlangıç örneğidir; gerçek GİB/BDP şema uyumluluğu için resmi XML şema doğrulaması, mevzuat oranları ve detaylı alan eşlemeleri eklenmelidir.
