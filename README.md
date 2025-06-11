# OWASP TOP 10 – ASP.NET Core (2021)

Projekt ten powstał jako część pracy magisterskiej poświęconej analizie błędów programistycznych prowadzących do podatności według klasyfikacji **OWASP Top 10:2021** Zawiera on wybrane przykłady podatności zaimplementowane w technologii **ASP.NET Core** – zarówno w wersjach podatnych, jak i zabezpieczonych – w celu ich demonstracji, analizy oraz edukacji.

Każda podatność została przygotowana jako oddzielny, działający projekt typu **Docker-ready** z dwoma wariantami:
- 🔓 **Wersja podatna (vulnerable)** – pokazuje błędne podejście
- 🔐 **Wersja bezpieczna (secure)** – pokazuje właściwe zabezpieczenie

---

## 📁 Struktura repozytorium

- Każda podatność ma swój osobny katalog
- Wewnątrz katalogu znajduje się:
  - gotowy projekt ASP.NET Core
  - plik `docker-compose.yml`
  - zrzuty ekranu (`/screeny`)
  - plik `README_*.md` z instrukcją uruchomienia i testowania

---

## 🚀 Uruchamianie lokalne

W każdej podatności uruchom:

```bash
docker-compose up --build
```

A następnie wejdź w przeglądarkę pod adres `http://localhost:5000`.

---

## 🧪 Testowanie

---

## 📌 OWASP Top 10:2021 – Pokrycie w tym repozytorium

| Kategoria                         | Status | Folder i Branch                          |
|----------------------------------|--------|------------------------------------------|
| A01 – Broken Access Control      | ✅     | `A01_BrokenAccessControl_IDOR`           |
| A02 – Cryptographic Failures     | ✅     | `A02_CryptographicFailures_*`            |
| A03 – Injection                  | ✅     | `A03_Injection_*`                        |
| A04 – Insecure Design            | ✅     | `A10_OpenRedirect`                       |
| A05 – Security Misconfiguration  | ✅     | `A05_SecurityMisconfiguration_*`         |
| A06 – Vulnerable Components      | ✅     | `A06_*`                                  |
| A07 – Identification Failures    | ✅     | `A07_*`                                  |
| A08 – Software & Data Integrity  | ✅     | `A08_*`                                  |
| A09 – Logging & Monitoring       | ✅     | `A09_SecurityLoggingandMonitoring*`      |
| A10 – Server-Side Request Forg.  | ✅     | `A10-2021/SSRF`                          |

---

## 👩‍🎓 Projekt akademicki

Projekt został przygotowany jako część **pracy magisterskiej** na kierunku **Informatyka** i stanowi poradnik dla początkujących programistów ASP.NET Core w zakresie bezpieczeństwa aplikacji webowych.

---

## 🔗 Autor

Justyna Toczek  

[github.com/JustynaTF](https://github.com/JustynaTF)
