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
   http://localhost:5000![Ekran_startowy](https://github.com/user-attachments/assets/a04a25fb-87ab-42a9-b58d-f731a475d364)

   ```
  ### Ekran początkowy:
![Ekran__startowy](https://github.com/user-attachments/assets/78ba7f8c-0327-45f5-be2b-21934e033806)



---

## 🧪 Testowanie podatności XSS

### 🔴 Wersja podatna

1. Otwórz przeglądarkę i przejdź do:

   ```
   http://localhost:5000/XssDemo?input=hello
   ```

   ✅ Wyświetli się wiadomość `hello`.

### Wersja podatna:

![Vulnerable_1](https://github.com/user-attachments/assets/bb132781-0f36-4003-9ebe-887853d6b26e)


2. Teraz podstaw złośliwy kod:

   ```
   http://localhost:5000/XssDemo?input=<script>alert('XSS')</script>
   ```

   🧨 Pojawi się **alert JavaScript**:
   > `alert('XSS')`

   To oznacza, że przeglądarka wykonała złośliwy kod z parametru `input`.

### Wersja podatna:
![Vulnerable_2](https://github.com/user-attachments/assets/1fd1ddb5-0d14-4d34-ae63-c9f44485c7ae)

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

### Wersja bezpieczna:
![Secure_1](https://github.com/user-attachments/assets/c16bef16-5061-4661-bbd7-1ef1607cc8e5)


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

## 📂 Inne podatności

To repozytorium zawiera również inne przykłady podatności z listy OWASP Top 10 dla ASP.NET Core – każda w osobnym katalogu i osobnym branchu.

---

## 👨‍🔬 Autor

Przykład opracowany w ramach pracy magisterskiej jako część poradnika dla początkujących programistów ASP.NET Core.
