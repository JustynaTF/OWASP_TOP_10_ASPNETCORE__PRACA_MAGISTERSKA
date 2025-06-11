# A02_CryptographicFailures_WeakEncodingforPassword

Ten projekt demonstruje podatność A02:2021 – Cryptographic Failures, konkretnie: **Weak Encoding for Password** (słabe kodowanie haseł). Pokazuje różnicę pomiędzy niepoprawnym (kodowanie do Base64) i poprawnym (hashowanie PBKDF2) sposobem przetwarzania haseł w ASP.NET Core.

---

## 🚀 Uruchomienie aplikacji w Dockerze

1. Przejdź do katalogu projektu:
```bash
cd A02_CryptographicFailures/A02_WeakEncodingforPassword
```

2. Uruchom kontener:
```bash
docker-compose up --build
```

3. Aplikacja będzie dostępna pod adresem: [http://localhost:5000](http://localhost:5000)

---

## ✅ Ekran startowy

Po uruchomieniu aplikacji otwórz przeglądarkę i przejdź do:

```
http://localhost:5000
```

Zobaczysz ekran powitalny z instrukcjami testowania.

---

## 🧪 Testowanie działania – krok po kroku

### 🔴 Wersja podatna (`/register/vulnerable`)

1. Otwórz **Postmana**
2. Ustaw:
    - **Method**: `POST`
    - **URL**: `http://localhost:5000/register/vulnerable`
    - **Body** → wybierz `x-www-form-urlencoded`
    - Dodaj 2 pola:
      - `username`: `Janek`
      - `password`: `Haslotestowe123!`
3. Kliknij **Send**
4. Otrzymasz odpowiedź:
    ```plaintext
    Zapisano użytkownika: Janek, hasło: SGFzbG90ZXN0b3dIMTIzIQ==
    ```
5. Skopiuj hash i wklej na [https://www.base64decode.org/](https://www.base64decode.org/) aby odzyskać oryginalne hasło.

📛 To pokazuje, że Base64 nie zabezpiecza hasła – można je łatwo odkodować.

---

### 🟢 Wersja bezpieczna (`/register/secure`)

1. Zmień URL w Postmanie:
    - `http://localhost:5000/register/secure`
2. Użyj tych samych pól: `username`, `password`
3. Kliknij **Send**
4. Otrzymasz odpowiedź podobną do:
    ```plaintext
    Zarejestrowano Janek z hasłem (hash): AQAAAAEAACcQAAAA...
    ```

🔐 Tego hasha nie da się odczytać – to bezpieczne, nieodwracalne haszowanie.

---

## 📌 Podsumowanie

| Wersja       | Opis                                       |
|--------------|--------------------------------------------|
| `vulnerable` | hasło kodowane do Base64 – łatwe do złamania |
| `secure`     | hasło haszowane przy użyciu PBKDF2          |

---

## 📸 Zrzuty ekranu

Prawidłowe działanie aplikacji można poznać po następujących widokach:

### Ekran startowy:
![Ekran_startowy](https://github.com/user-attachments/assets/2bf1e94a-988c-4717-bb2a-fdf79e7134ab)


### Wersja podatna:
![Vulnerable](https://github.com/user-attachments/assets/103f56fe-d152-4d24-855b-11128d036c09)

### Wersja bezpieczna:
![Secure](https://github.com/user-attachments/assets/ed53811f-0280-4726-93bc-43ed6e8f9c0f)


---

## 📂 Inne podatności

To repozytorium zawiera również inne przykłady podatności z listy OWASP Top 10 dla ASP.NET Core – każda w osobnym katalogu i osobnym branchu.

---

## 👨‍🔬 Autor

Przykład opracowany w ramach pracy magisterskiej jako część poradnika dla początkujących programistów ASP.NET Core.
