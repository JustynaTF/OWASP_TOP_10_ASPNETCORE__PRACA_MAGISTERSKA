# A04 Insecure Design – Open Redirect (ASP.NET Core)

## 📌 Opis podatności

Open Redirect to podatność, która polega na niewłaściwym przekierowaniu użytkownika na adres URL przekazany przez użytkownika (np. w parametrze `redirectUrl`). Brak odpowiedniej walidacji może prowadzić do przekierowań na niezaufane domeny, co może zostać wykorzystane w atakach phishingowych i socjotechnicznych.

W tym przykładzie przygotowano dwie wersje aplikacji:
- **Vulnerable** – podatna na atak Open Redirect (brak walidacji adresu URL),
- **Secure** – zabezpieczona przed przekierowaniem na zewnętrzne domeny (użycie `Url.IsLocalUrl(...)`).

---

## ✅ Wymagania

Aby uruchomić projekt lokalnie, potrzebujesz:

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (uruchomiony w tle)
- [Git](https://git-scm.com/) (do pobrania repozytorium)

---

## 🚀 Uruchomienie

1. **Sklonuj repozytorium**

   ```bash
   git clone https://github.com/JustynaTF/OWASP_TOP_10_ASPNETCORE.git
   cd OWASP_TOP_10_ASPNETCORE/A04_OpenRedirect
   ```

2. **Uruchom kontener Docker**

   Upewnij się, że Docker Desktop działa, a następnie uruchom aplikację:

   ```bash
   docker-compose up --build
   ```

   Aplikacja uruchomi się na porcie `5000`.

3. **Otwórz aplikację w przeglądarce**

   Przejdź do:

   ```
   http://localhost:5000
   ```

   Zobaczysz dwa linki prowadzące do:
   - `/redirect/vulnerable?redirectUrl=https://example.com`
   - `/redirect/secure?redirectUrl=https://example.com`

---

## 🧪 Testowanie

### 🔴 Wersja podatna

Kliknij w link **Vulnerable** lub wklej w pasek przeglądarki poniższy adres url:

```
http://localhost:5000/redirect/vulnerable?redirectUrl=https://example.com
```

✅ Użytkownik zostanie przekierowany na **example.com** – aplikacja nie weryfikuje adresu URL.

### 🟢 Wersja bezpieczna

Kliknij w link **Secure** lub wklej w pasek przeglądarki poniższy adres url:

```
http://localhost:5000/redirect/secure?redirectUrl=https://example.com
```

❌ Aplikacja wykryje, że URL nie jest lokalny i **zablokuje przekierowanie**, wyświetlając komunikat:

```
Invalid redirect URL.
```

---

## 📸 Zrzuty ekranu

Prawidłowe działanie aplikacji można poznać po następujących widokach:

### Ekran startowy:
![Widok początkowy](A04_OpenRedirect\A04_screeny\Ekran_startowy.png)

### Wersja podatna:

![Widok wersji podatnej](A04_OpenRedirect\A04_screeny\Vulnerable.png)

### Wersja bezpieczna:

![Widok wersji bezpiecznej](A04_OpenRedirect\A04_screeny\Secure.png)

---

## 📂 Inne podatności

To repozytorium zawiera również inne przykłady podatności z listy OWASP Top 10 dla ASP.NET Core – każda w osobnym katalogu i osobnym branchu.

---

## 👨‍🔬 Autor

Przykład opracowany w ramach pracy magisterskiej jako część poradnika dla początkujących programistów ASP.NET Core.
