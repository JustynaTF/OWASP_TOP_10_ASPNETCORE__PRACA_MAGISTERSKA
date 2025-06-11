# A05:2021 – Security Misconfiguration – Token / Cookie No Expire

Ten projekt demonstruje podatność A05 z listy OWASP Top 10:2021 – **Security Misconfiguration** – na przykładzie ciasteczka uwierzytelniającego bez daty wygaśnięcia (Token/Cookie No Expire) w ASP.NET Core.

## 🔧 Technologia

- ASP.NET Core 8.0 (Minimal API)
- Docker + Docker Compose
- Przeglądarka z narzędziem DevTools → Application → Cookies

---

## 🧪 Testowanie

### 1. Uruchomienie aplikacji

```bash
docker-compose up --build
```

Aplikacja uruchomi się na porcie **5000**.

---

### 2. Dostępne endpointy

| Endpoint               | Opis                                                 |
|------------------------|------------------------------------------------------|
| `/`                    | Ekran startowy z instrukcjami                        |
| `/login`               | Podatna wersja – bez daty wygaśnięcia ciasteczka     |
| `/secure-login`        | Wersja bezpieczna – z czasem wygaśnięcia ciasteczka  |

---

### 3. Sprawdzenie w przeglądarce

#### 🔓 Podatna wersja

1. Otwórz przeglądarkę i przejdź do:

   ```
   http://localhost:5000/login
   ```

2. Zobaczysz komunikat: `Zalogowano! (wersja podatna).`

3. Otwórz DevTools → zakładka **Application** → **Cookies** → `http://localhost:5000`

4. Sprawdź wartość kolumny **Expires / Max-Age** – będzie ustawiona jako `Session`.

---

#### 🔐 Bezpieczna wersja

1. Przejdź do:

   ```
   http://localhost:5000/secure-login
   ```

2. Zobaczysz komunikat: `Zalogowano! (wersja bezpieczna).`

3. Sprawdź ponownie **Application → Cookies** – ciasteczko `AuthCookie` powinno teraz zawierać konkretną datę wygaśnięcia (`Expires` / `Max-Age`).

---

## 🛡️ Różnice w kodzie

### 🔓 Podatna wersja

Brak ustawienia czasu życia ciasteczka:

```csharp
.AddCookie(options =>
{
    options.Cookie.Name = "AuthCookie";
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    // Brak ustawienia Expires / Max-Age
});
```

---

### 🔐 Bezpieczna wersja

Ustawienie czasu wygaśnięcia i trwałości:

```csharp
var props = new AuthenticationProperties
{
    IsPersistent = true,
    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20)
};

await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
```

---

## 📌 Wnioski

- Ciasteczka bez daty wygaśnięcia (sesyjne) mogą pozostać aktywne do czasu zamknięcia przeglądarki – co bywa niewystarczające.
- Ustawienie `Expires`/`Max-Age` pozwala ograniczyć czas życia tokenu.
- Dobrą praktyką jest również włączenie `SlidingExpiration`, aby aktywność użytkownika odświeżała czas trwania sesji.

---

## 🗑️ Zatrzymanie kontenera

```bash
docker-compose down
```

---

## 📸 Zrzuty ekranu

Prawidłowe działanie aplikacji można poznać po następujących widokach:

### Ekran startowy:
![Ekran_startowy](https://github.com/user-attachments/assets/884ade94-e9f6-4c72-8fdd-10af4729420d)


### Wersja podatna:
![Vulnerable](https://github.com/user-attachments/assets/1627b200-b735-4ab9-af34-db66f462145b)


### Wersja bezpieczna:
![Secure](https://github.com/user-attachments/assets/c3de12cb-1215-489c-9246-4581f7b3180e)

---

## 📂 Inne podatności

To repozytorium zawiera również inne przykłady podatności z listy OWASP Top 10 dla ASP.NET Core – każda w osobnym katalogu i osobnym branchu.

---

## 👨‍🔬 Autor

Przykład opracowany w ramach pracy magisterskiej jako część poradnika dla początkujących programistów ASP.NET Core.
