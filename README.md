# A09:2021 – Security Logging and Monitoring Failures – Password in Log

Ten projekt demonstruje podatność A09 z listy OWASP Top 10:2021 – **Security Logging and Monitoring Failures** – na przykładzie zapisywania hasła użytkownika w logach systemowych.

## 🔧 Technologia

- ASP.NET Core 8.0 (Minimal API)
- Serilog (konsolowy)
- Docker + Docker Compose

---

## 🧪 Testowanie

### 1. Uruchomienie aplikacji

```bash
docker-compose up --build
```

Aplikacja uruchomi się na porcie **5000**.

---

### 2. Dostępne endpointy

| Endpoint           | Opis                                                          |
|--------------------|---------------------------------------------------------------|
| `/`                | Ekran startowy                                                |
| `/log-vulnerable`  | 🔓 Podatna wersja – hasło logowane w jawnej postaci           |
| `/log-secure`      | 🔐 Wersja bezpieczna – dane zamaskowane przed logowaniem      |

---

### 3. Krok po kroku

#### 🔓 Wersja podatna

1. Otwórz przeglądarkę i przejdź do:

   ```
   http://localhost:5000/log-vulnerable
   ```

2. Zobaczysz komunikat: `🔓 Zalogowano! Dane użytkownika zapisane w logu – podatna wersja.`

3. Wróć do terminala/konsoli, gdzie działa `docker-compose`, i sprawdź logi:

   W logach pojawi się pełna treść danych – w tym **hasło** i **numer karty** w formie jawnej.

#### 🔐 Wersja bezpieczna

1. Otwórz przeglądarkę i przejdź do:

   ```
   http://localhost:5000/log-secure
   ```

2. Zobaczysz komunikat: `🔐 Zalogowano! Dane użytkownika zapisane w logu – bezpieczna wersja.`

3. Wróć do konsoli z logami – dane są **zamaskowane** (np. `"Password": "***"`).

---

---

## 📸 Zrzuty ekranu

### Ekran startowy:
![Ekran_Startowy](https://github.com/user-attachments/assets/bb3d6bb1-d7fc-4ef0-98d8-bb8501e15c1a)


### Wersja bezpieczna:
![Secure](https://github.com/user-attachments/assets/e508027b-4c8e-45ed-8d9c-5bd06664c45f)

### Wersja bezpieczna – zamaskowane dane w logach:
![Secure_log](https://github.com/user-attachments/assets/c0985f59-7c0d-4386-a140-452f0130e8e3)


### Wersja podatna:
![Vulnerable](https://github.com/user-attachments/assets/7a8da302-d9a6-405d-9de7-dc0b0548bf5b)


### Wersja podatna – jawne dane w logach:
![Vulnerable_log](https://github.com/user-attachments/assets/35f186e8-5b75-4880-a0e1-c8790acbf104)

---

## 📂 Inne podatności

To repozytorium zawiera również inne przykłady podatności z listy OWASP Top 10 dla ASP.NET Core – każda w osobnym katalogu i osobnym branchu.

---

## 👨‍🔬 Autor

Przykład opracowany w ramach pracy magisterskiej jako część poradnika dla początkujących programistów ASP.NET Core.
