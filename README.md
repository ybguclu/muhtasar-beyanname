# Muhtasar Beyanname Düzenleyici (MBD) 📑

C# / WPF ile geliştirilen bu masaüstü uygulaması, muhtasar beyanname hazırlama sürecini hızlandırmak için örnek bir başlangıç altyapısı sunar.

## Özellikler
- Mükellef bilgisi (VKN/TCKN, ünvan, dönem) girişi
- Ödeme satırı ekleme (brüt tutar + stopaj oranı)
- Otomatik hesaplamalar
  - Stopaj tutarı
  - Damga vergisi (örnek oran: %0,759)
  - Toplam matrah / stopaj / damga vergisi
- XML dışa aktarma (GİB/BDP uyumluya yakın örnek şema)

## Proje Yapısı
- `src/MuhtasarBeyannameApp`: WPF uygulaması
  - `Models`: Beyanname veri modelleri
  - `Services`: Hesaplama ve XML dışa aktarma servisleri
  - `ViewModels`: MVVM görünüm modeli ve komut altyapısı

## Çalıştırma
> Not: Bu ortamda .NET SDK kurulu olmadığı için komutlar doğrulanamadı.

1. Windows üzerinde .NET 9 SDK ve Visual Studio 2022+ kurun.
2. `MuhtasarBeyanname.sln` dosyasını açın.
3. Projeyi derleyip çalıştırın.

## Yol Haritası
- GİB’in resmi XSD şemalarına tam uyarlama
- SQLite ile kayıt/geçmiş yönetimi
- Excel’den toplu içe aktarma
- Gelişmiş doğrulama ve hata raporlama

## Lisans
MIT
