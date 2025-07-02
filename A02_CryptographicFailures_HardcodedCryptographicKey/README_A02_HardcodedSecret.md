# A02:2021 – Cryptographic Failures – Hard-coded Cryptographic Key

Ten projekt demonstruje podatność z kategorii A02:2021 OWASP Top 10 – „Cryptographic Failures”, a konkretnie przypadek użycia zakodowanego na stałe klucza kryptograficznego (hard-coded secret). Przykład zawiera zarówno podatną, jak i bezpieczną wersję kontrolera API w ASP.NET Core.


## ⚙️ Wymagania wstępne

- Zainstalowany [Docker Desktop](https://www.docker.com/products/docker-desktop/) i uruchomiony.
- Zainstalowany .NET SDK 8.0 (używane tylko lokalnie podczas developmentu).
- System wspierający Docker (np. Windows, macOS lub Linux).

## ▶️ Uruchamianie projektu

1. Pobierz repozytorium lub sklonuj je lokalnie:

   ```bash
   git clone https://github.com/JustynaTF/OWASP_TOP_10_ASPNETCORE.git
   cd OWASP_TOP_10_ASPNETCORE/A02_CryptographicFailures/A02_Use_of_Hard-coded_Cryptographic_Key
   ```

2. Upewnij się, że Docker jest uruchomiony.

3. Uruchom kontener:

   ```bash
   docker-compose up --build
   ```

UWAGA: Ustawienie zmiennej środowiskowej `APP_SECRET`

Bezpieczna wersja aplikacji (`GET /crypto/secure`) korzysta ze zmiennej środowiskowej `APP_SECRET`, która przechowuje klucz poza kodem źródłowym.

W tym projekcie zmienna ta została zdefiniowana w pliku `docker-compose.yml`, który jest automatycznie odczytywany podczas uruchamiania Dockera:

```yaml
# docker-compose.yml
    environment:
      - APP_SECRET=VERY-SECRET-ENV-KEY
```

4. Aplikacja będzie dostępna pod adresem: [http://localhost:5000](http://localhost:5000)

## 🧪 Testowanie

Po uruchomieniu aplikacji otwórz przeglądarkę i przejdź pod wskazane adresy:

- **Ekran startowy (index):** [http://localhost:5000](http://localhost:5000)  
![Ekran_startowy](https://github.com/user-attachments/assets/5cf7bb1b-4b07-49c3-a5e0-fe27a6473417)


- **Wersja podatna:** [http://localhost:5000/crypto/vulnerable](http://localhost:5000/crypto/vulnerable)  
![Vulnerable](https://github.com/user-attachments/assets/46ab1215-4577-4d36-aa48-baf8c226e14e)


- **Wersja bezpieczna:** [http://localhost:5000/crypto/secure](http://localhost:5000/crypto/secure)  
![Secure](https://github.com/user-attachments/assets/f8e4db2a-cc77-41d4-8554-df270011cdd5)


## 🛡️ Opis działania

- `GET /crypto/vulnerable` – zwraca tajny klucz zakodowany na stałe w kodzie źródłowym (`HARDOCDED-SECRET-12345`). Jest to przykład podatności.
- `GET /crypto/secure` – zwraca wartość pobraną z zmiennej środowiskowej `APP_SECRET`. To bezpieczne podejście do zarządzania sekretami.

---

## 📂 Inne podatności

To repozytorium zawiera również inne przykłady podatności z listy OWASP Top 10 dla ASP.NET Core – każda w osobnym katalogu i osobnym branchu.

---

## 👨‍🔬 Autor

Przykład opracowany w ramach pracy magisterskiej jako część poradnika dla początkujących programistów ASP.NET Core.
