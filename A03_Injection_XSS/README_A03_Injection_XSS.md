# A03_Injection_XSS – Demonstracja podatności XSS (Cross-Site Scripting)

Ten projekt demonstruje podatność typu **XSS (Cross-Site Scripting)** zgodnie z klasyfikacją OWASP Top 10 – A03:2021 Injection. Aplikacja ASP.NET Core renderuje dane z parametru `input` w sposób niebezpieczny (podatny) oraz poprawny (bezpieczny).

---

## 📦 Uruchamianie projektu w Dockerze

1. Przejdź do folderu projektu:

   ```bash
   cd A03_Injection_XSS
   ```

2. Uruchom kontener z aplikacją:

   ```bash
   docker-compose up --build
   ```

3. Otwórz przeglądarkę i przejdź pod adres:

   ```
   http://localhost:5000
   ```

---

## 🧪 Testowanie podatności XSS

### 🔴 Wersja podatna

1. Otwórz przeglądarkę i przejdź do:

   ```
   http://localhost:5000/XssDemo?input=hello
   ```

   ✅ Wyświetli się wiadomość `hello`.

### Wersja podatna:

![Widok wersji podatnej](A03_Injection_XSS\A03_screeny\Vulnerable_1.png)

2. Teraz podstaw złośliwy kod:

   ```
   http://localhost:5000/XssDemo?input=<script>alert('XSS')</script>
   ```

   🧨 Pojawi się **alert JavaScript**:
   > `alert('XSS')`

   To oznacza, że przeglądarka wykonała złośliwy kod z parametru `input`.

### Wersja podatna:

![Widok wersji podatnej](A03_Injection_XSS\A03_screeny\Vulnerable_2.png)
---

### 🟢 Wersja bezpieczna

1. Przejdź do bezpiecznego widoku:

   ```
   http://localhost:5000/XssDemo/Secure?input=<script>alert('XSS')</script>
   ```

2. Tym razem zobaczysz tekst:
   ```html
   <script>alert('XSS')</script>
   ```

   🔐 Zostanie on wyświetlony **jako tekst**, a **nie zostanie wykonany** – dzięki temu, że aplikacja używa domyślnego `@ViewData["Message"]`, które automatycznie koduje HTML.

### Wersja podatna:

![Widok wersji bezpiecznej](A03_Injection_XSS\A03_screeny\Secure_1.png)
---

---

## 🔍 Co to demonstruje?

- **Niebezpieczny kod**:
  ```cshtml
  <p>@Html.Raw(ViewData["Message"])</p>  <!-- podatny na XSS -->
  ```

- **Bezpieczny kod**:
  ```cshtml
  <p>@ViewData["Message"]</p>  <!-- bezpieczny, koduje HTML -->
  ```

---

## 📚 Podsumowanie

✅ ASP.NET Core automatycznie koduje dane w Razor, jeśli nie używasz `@Html.Raw(...)`.  
❌ `@Html.Raw(...)` pozwala na wykonanie złośliwego kodu – używaj tylko wtedy, gdy masz 100% pewności, że dane są bezpieczne!

---

## 📸 Zrzuty ekranu

Prawidłowe działanie aplikacji można poznać po następujących widokach:

### Ekran startowy:
![Widok początkowy](A03_Injection_CSRF\A03_screeny\Ekran_startowy.png)

### Wersja podatna:

![Widok wersji podatnej](A03_Injection_CSRF\A03_screeny\Vulnerable.png)

### Wersja bezpieczna:

![Widok wersji bezpiecznej](A03_Injection_CSRF\A03_screeny\Secure.png)

---

## 📂 Inne podatności

To repozytorium zawiera również inne przykłady podatności z listy OWASP Top 10 dla ASP.NET Core – każda w osobnym katalogu i osobnym branchu.

---

## 👨‍🔬 Autor

Przykład opracowany w ramach pracy magisterskiej jako część poradnika dla początkujących programistów ASP.NET Core.