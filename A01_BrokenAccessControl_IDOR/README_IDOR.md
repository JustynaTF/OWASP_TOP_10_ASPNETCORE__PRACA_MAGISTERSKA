# A01:2021 – Broken Access Control (IDOR) – ASP.NET Core Demo

Ten projekt demonstruje podatność **IDOR (Insecure Direct Object Reference)** – przykład z kategorii A01:2021 OWASP Top 10, przygotowany w ASP.NET Core.

## 📝 Opis

W aplikacji znajdują się dwa endpointy:
- `orders/vulnerable` – **wersja podatna**, która nie sprawdza właściciela zasobu.
- `orders/secure` – **wersja bezpieczna**, która weryfikuje, czy użytkownik ma dostęp do danego zasobu.

## ▶️ Wymagania

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)

## 🚀 Uruchomienie

1. Upewnij się, że Docker jest uruchomiony.
2. Sklonuj repozytorium:
   ```bash
   git clone https://github.com/JustynaTF/OWASP_TOP_10_ASPNETCORE.git
   cd OWASP_TOP_10_ASPNETCORE/A01_BrokenAccessControl_IDOR
   ```

3. Zbuduj i uruchom projekt w Dockerze:
   ```bash
   docker-compose up --build
   ```

4. Otwórz przeglądarkę i przejdź do:
   ```
   http://localhost:5000
   ```

## 🧪 Testowanie

### 🔓 Wersja podatna:
Symulowany aktualny użytkownik: `UserId = 1`

- Przeglądaj dane zamówienia o ID 1 (należącego do użytkownika 1):
  ```
  http://localhost:5000/orders/vulnerable?orderId=1
  ```

- Teraz spróbuj podejrzeć zamówienie o ID 2 (należy do innego użytkownika!):
  ```
  http://localhost:5000/orders/vulnerable?orderId=2
  ```
  🔥 **Dane zostaną ujawnione mimo braku uprawnień** – to jest przykład podatności IDOR.

---

### 🔒 Wersja bezpieczna:
- Przeglądaj poprawnie swoje zamówienie:
  ```
  http://localhost:5000/orders/secure?orderId=1
  ```

- Spróbuj uzyskać dostęp do innego zamówienia:
  ```
  http://localhost:5000/orders/secure?orderId=2
  ```

  ❌ Aplikacja odrzuci żądanie z komunikatem:
  ```
  Brak dostępu do tego zamówienia.
  ```

---

## 📸 Zrzuty ekranu

Prawidłowe działanie aplikacji można poznać po następujących widokach:

### Ekran startowy:

![Widok początkowy](A01_BrokenAccessControl_IDOR\A01_screeny\Ekran_startowy.png)

### Wersja podatna:

![Widok wersji podatnej](A01_BrokenAccessControl_IDOR\A01_screeny\Vulnerable_1.png)

![Widok wersji podatnej](A01_BrokenAccessControl_IDOR\A01_screeny\Vulnerable_2.png)

### Wersja bezpieczna:

![Widok wersji bezpiecznej](A01_BrokenAccessControl_IDOR\A01_screeny\Secure_1.png)

![Widok wersji bezpiecznej](A01_BrokenAccessControl_IDOR\A01_screeny\Secure_2.png)
---

## 📂 Inne podatności

To repozytorium zawiera również inne przykłady podatności z listy OWASP Top 10 dla ASP.NET Core – każda w osobnym katalogu i osobnym branchu.

---

## 👨‍🔬 Autor

Przykład opracowany w ramach pracy magisterskiej jako część poradnika dla początkujących programistów ASP.NET Core.
