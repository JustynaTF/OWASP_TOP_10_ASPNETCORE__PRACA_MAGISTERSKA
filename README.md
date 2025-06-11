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

![Ekran_startowy](https://github.com/user-attachments/assets/80940bfb-4beb-4ca0-a084-fa3bbb96a3a6)


### Wersja podatna:

![Vulnerable_1](https://github.com/user-attachments/assets/653ca897-8ab8-49af-8249-5e5a517d7fea)

![Vulnerable_2](https://github.com/user-attachments/assets/170583cc-6028-4208-bf8e-7bf7b739e9be)


### Wersja bezpieczna:

![Secure_1](https://github.com/user-attachments/assets/4f69fe5e-2538-4ce3-bbd4-c34a22f2b0b7)

![Secure_2](https://github.com/user-attachments/assets/e714a5b6-eba3-41bc-a4f3-0ed71cad22a3)


---

## 📂 Inne podatności

To repozytorium zawiera również inne przykłady podatności z listy OWASP Top 10 dla ASP.NET Core – każda w osobnym katalogu i osobnym branchu.

---

## 👨‍🔬 Autor

Przykład opracowany w ramach pracy magisterskiej jako część poradnika dla początkujących programistów ASP.NET Core.
