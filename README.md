# A03_Injection_CSRF – Demonstracja podatności CSRF (Cross-Site Request Forgery)

Ten projekt demonstruje podatność typu CSRF w aplikacji ASP.NET Core na przykładzie dwóch wariantów:
- **wersja podatna** (bez ochrony anty-CSRF),
- **wersja bezpieczna** (z użyciem `[ValidateAntiForgeryToken]` i `@Html.AntiForgeryToken()`).

W projekcie znajduje się także złośliwa strona `evil_csrf_attack.html`, symulująca atak z zewnętrznego źródła.

---

## Wymagania

Aby uruchomić ten projekt, musisz mieć zainstalowane:
- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- System operacyjny obsługujący Dockera (np. Windows, macOS, Linux)

---

## Uruchamianie projektu

1. Upewnij się, że Docker Desktop jest uruchomiony.
2. Sklonuj repozytorium `OWASP_TOP_10_ASPNETCORE` z GitHuba:
```bash
git clone https://github.com/JustynaTF/OWASP_TOP_10_ASPNETCORE.git
cd OWASP_TOP_10_ASPNETCORE/A03_Injection_CSRF
```

3. Uruchom aplikację za pomocą Dockera:
```bash
docker-compose up --build
```

4. Po uruchomieniu aplikacja będzie dostępna pod adresem: [http://localhost:5000]

---

## Testowanie podatności

### Krok 1: Zmodyfikuj plik `evil_csrf_attack.html`

W pliku `evil_csrf_attack.html` znajduje się formularz automatycznie wysyłany do aplikacji ASP.NET Core. 
Aby przetestować odpowiednią wersję aplikacji:

![Złośliwa_witryna](https://github.com/user-attachments/assets/4a86f5ec-482b-4cae-b1bd-af007cd6ba26)


- **Dla wersji podatnej** zmień `action` na:
  ```
  http://localhost:5000/Home/SubmitVulnerable
  ```
- **Dla wersji bezpiecznej** zmień `action` na:
  ```
  http://localhost:5000/Home/Submit
  ```

### Krok 2: Otwórz złośliwą stronę

1. Kliknij dwukrotnie plik `evil_csrf_attack.html` lub otwórz go w przeglądarce.
2. Formularz zostanie automatycznie przesłany po załadowaniu strony.

### Oczekiwane wyniki:

- ✅ **Wersja podatna** – formularz zostanie przesłany, wiadomość pojawi się na stronie.
- ❌ **Wersja bezpieczna** – aplikacja odrzuci żądanie jako nieautoryzowane (ponieważ nie ma tokenu anty-CSRF).

---

## 📸 Zrzuty ekranu

Prawidłowe działanie aplikacji można poznać po następujących widokach:

### Ekran startowy:
![Ekran_startowy](https://github.com/user-attachments/assets/faae2de6-b8fb-4bd8-bf8c-8beee362908a)


### Wersja podatna:
![Vulnerable](https://github.com/user-attachments/assets/7b036991-3822-4752-90cc-227a1055de42)


### Wersja bezpieczna:
![Secure](https://github.com/user-attachments/assets/afc1e47e-5153-4e06-90ed-e34760d67142)


---

## 📂 Inne podatności

To repozytorium zawiera również inne przykłady podatności z listy OWASP Top 10 dla ASP.NET Core – każda w osobnym katalogu i osobnym branchu.

---

## 👨‍🔬 Autor

Przykład opracowany w ramach pracy magisterskiej jako część poradnika dla początkujących programistów ASP.NET Core.
