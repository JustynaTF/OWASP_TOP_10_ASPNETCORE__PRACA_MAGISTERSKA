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
![Ekran startowy](A09_SecurityLoggingandMonitoringFailures_PasswordinLog\A09_screeny\Ekran_Startowy.png)

### Wersja bezpieczna:

![Widok wersji bezpiecznej](A09_SecurityLoggingandMonitoringFailures_PasswordinLog\A09_screeny\Secure.png)

### Wersja bezpieczna – zamaskowane dane w logach:
![Widok logów – secure](A09_SecurityLoggingandMonitoringFailures_PasswordinLog\A09_screeny\Secure_log.png)

### Wersja podatna:

![Widok wersji podatnej](A09_SecurityLoggingandMonitoringFailures_PasswordinLog\A09_screeny\Vulnerable.png)

### Wersja podatna – jawne dane w logach:

![Widok logów – vulnerable](A09_SecurityLoggingandMonitoringFailures_PasswordinLog\A09_screeny\Vulnerable_log.png)

---

## 📂 Inne podatności

To repozytorium zawiera również inne przykłady podatności z listy OWASP Top 10 dla ASP.NET Core – każda w osobnym katalogu i osobnym branchu.

---

## 👨‍🔬 Autor

Przykład opracowany w ramach pracy magisterskiej jako część poradnika dla początkujących programistów ASP.NET Core.