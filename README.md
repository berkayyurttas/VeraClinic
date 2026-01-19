                                             🏥 VeraClinic - Akıllı Triyaj ve Klinik Yönetim Sistemi


VeraClinic; acil servisler, klinikler ve poliklinikler için hastaların hayati bulgularına göre sınıflandırılmasını sağlayan, hız ve güvenliğin ön planda olduğu bir Akıllı Triyaj Sistemi'dir. Sistem, sağlık personeline hastaların aciliyet durumlarını anlık olarak takip etme ve doğru müdahale önceliği belirleme imkanı sunar.

🚨 Triyaj Sınıflandırma Sistemi
VeraClinic, uluslararası standartlara uygun olarak hastaları üç ana kategoride sınıflandırır:

🔴 Kırmızı Kod (Acil): Hayati tehlikesi bulunan, saniyeler içinde müdahale edilmesi gereken kritik hastalar.

🟡 Sarı Kod (Gözlem): Durumu kötüleşme riski bulunan, kısa süre içinde müdahale edilmesi gereken hastalar.

🟢 Yeşil Kod (Ayaktan): Genel sağlık durumu stabil olan, poliklinik hizmeti alabilecek hastalar.

🚀 Teknolojik Altyapı ve Mimari
Proje, kurumsal seviyede performans ve sürdürülebilirlik için en güncel yazılım yığınını kullanır:

⚙️ Backend (Sunucu Tarafı)
.NET 10 (Preview): Microsoft'un en güncel framework'ü ile maksimum performans.

PostgreSQL: Güçlü, açık kaynaklı ilişkisel veritabanı yönetimi.

Redis: Yüksek performanslı veri önbellekleme (Caching) ve oturum yönetimi.

OpenIddict: Yüksek güvenlikli kimlik doğrulama (OAuth2/OpenID Connect).

ABP Framework: Modüler ve Domain-Driven Design (DDD) odaklı katmanlı mimari.

🎨 Frontend (İstemci Tarafı)
Angular: Dinamik ve modüler kullanıcı arayüzü yönetimi.

RxJS (Observables): Backend'den gelen hasta ve triyaj verilerinin asenkron akış yönetimi.

Bootstrap & SCSS: Sağlık personeli için optimize edilmiş, mobil uyumlu panel tasarımı.

📦 DevOps ve Otomasyon
Docker: API, Angular, PostgreSQL ve Redis bileşenlerinin konteynerize edilmesi.

GitHub Actions: Tam otomatik CI/CD süreci (Build, Test, Push to Docker Hub).

Multi-Stage Build: Üretim ortamı için optimize edilmiş hafif Docker imajları.

🏗️ Proje Katmanları (N-Layered)
Domain Layer: İş kuralları ve triyaj algoritmalarının kalbi.

Application Layer: DTO'lar ve iş mantığının API ile buluştuğu nokta.

Infrastructure Layer: PostgreSQL bağlantıları, Redis entegrasyonu ve EF Core konfigürasyonları.

API Host Layer: Uygulamanın dünyaya açılan kapısı.

🛠️ Kurulum Rehberi
Docker ile Hızlı Başlat
Sistemi en güncel imajlarla ayağa kaldırmak için:

Bash
docker pull berkayyurttas/veraclinic-api:latest
docker pull berkayyurttas/veraclinic-angular:latest
Yerel Geliştirme Ortamı
Depoyu klonlayın: git clone https://github.com/berkayyurttas/VeraClinic.git

docker-compose.yml dosyasını kullanarak PostgreSQL ve Redis servislerini başlatın.

Migrationları uygulayın: dotnet ef database update

Projeyi çalıştırın: dotnet run
