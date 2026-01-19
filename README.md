🏥 VeraClinic - Akıllı Triyaj ve Klinik Yönetim Sistemi
VeraClinic; acil servisler, klinikler ve poliklinikler için hastaların hayati bulgularına göre sınıflandırılmasını sağlayan, hız ve güvenliğin ön planda olduğu bir Akıllı Triyaj Sistemi'dir. Sistem, sağlık personeline hastaların aciliyet durumlarını anlık olarak takip etme ve doğru müdahale önceliği belirleme imkanı sunar.

🚨 Triyaj Sınıflandırma Sistemi
VeraClinic, uluslararası standartlara uygun olarak hastaları üç ana kategoride sınıflandırır:

🔴 Kırmızı Kod (Acil): Hayati tehlikesi bulunan, saniyeler içinde müdahale edilmesi gereken kritik hastalar. Sistemde en yüksek öncelikle en üst sırada listelenir.

🟡 Sarı Kod (Gözlem): Hayati tehlikesi anlık olmayan ancak durumunun kötüleşme riski bulunan, kısa süre içinde müdahale edilmesi gereken hastalar.

🟢 Yeşil Kod (Ayaktan): Genel sağlık durumu stabil olan, poliklinik hizmeti alabilecek veya bekleme süresi hayati risk oluşturmayan hastalar.

🚀 Teknolojik Altyapı ve Mimari
Proje, kurumsal seviyede performans ve sürdürülebilirlik için en güncel yazılım yığınını (stack) kullanır:

⚙️ Backend (Sunucu Tarafı)
.NET 10 (Preview): Microsoft'un en güncel framework'ü ile maksimum performans ve modern C# özellikleri.

OpenIddict: OAuth2 ve OpenID Connect protokolleri ile yüksek güvenlikli kimlik doğrulama.

Entity Framework Core: Veritabanı yönetimi ve ORM işlemleri için güçlü altyapı.

ABP Framework (Opsiyonel/Katmanlı Mimari): Modüler ve genişletilebilir Domain-Driven Design (DDD) prensipleri.

🎨 Frontend (İstemci Tarafı)
Angular: Dinamik, hızlı ve reaktif kullanıcı arayüzü yönetimi.

RxJS: Triyaj listelerindeki anlık veri değişimlerini yönetmek için asenkron akışlar.

Bootstrap & SCSS: Mobil uyumlu ve şık bir sağlık personeli paneli.

📦 DevOps ve Otomasyon
Docker: API, Angular ve Veritabanı bileşenlerinin konteynerize edilmesi.

GitHub Actions: Tam otomatik CI/CD süreci. Kod her gönderildiğinde; derleme, imaj oluşturma ve Docker Hub'a dağıtım işlemleri saniyeler içinde gerçekleşir.

Multi-Stage Build: Üretim ortamı için optimize edilmiş, düşük boyutlu ve güvenli Docker imajları.

🏗️ Proje Katmanları (N-Layered)
Domain Layer: İş kuralları ve triyaj algoritmalarının kalbi.

Application Layer: DTO'lar, servisler ve iş mantığının API ile buluştuğu nokta.

Infrastructure Layer: EF Core, veritabanı sağlayıcıları ve harici entegrasyonlar.

API Host Layer: Uygulamanın dünyaya açılan kapısı.

🛠️ Kurulum Rehberi
Docker ile Hızlı Başlat
İmajları doğrudan Docker Hub'dan çekerek sistemi ayağa kaldırabilirsiniz:

Bash
docker pull berkayyurttas/veraclinic-api:latest
docker pull berkayyurttas/veraclinic-angular:latest
Yerel Geliştirme Ortamı
Depoyu klonlayın: git clone https://github.com/berkayyurttas/VeraClinic.git

SQL Server bağlantınızı yapılandırın.

Migrationları uygulayın: dotnet ef database update

Projeyi çalıştırın: dotnet run
