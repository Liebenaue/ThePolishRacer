![Build status](https://github.com/Liebenaue/ThePolishRacer/actions/workflows/build-wpf.yml/badge.svg)

# The Polish Racer

## 🎮 Wprowadzenie

W grze **The Polish Racer** wcielasz się w młodego, początkującego kierowcę, który dopiero rozpoczyna swoją przygodę z motoryzacją  
i zarabianiem pieniędzy za kierownicą.

Na starcie otrzymujesz pierwsze, skromne, lecz funkcjonalne auto (obecnie **KIA Ceed**), a także **50 zł** oraz niemal pełny bak paliwa.  
To twój kapitał początkowy – punkt wyjścia do budowania kariery, zdobywania coraz lepszych samochodów i rozwijania umiejętności.

---

## 💸 Tryb Snake – Zbieranie pieniędzy

Główny tryb gry w obecnej wersji to **zbieranie pieniędzy** – w formie prostej gry typu **snake**.  
Sterujesz klasycznym wężem, ale już wkrótce zastąpi go animowany samochód – taki, jakim faktycznie jeździsz w grze.

W przyszłości różne modele aut (w najbliższej przyszłości Nissan Note i VW Passat) będą różnić się masą, prędkością i spalaniem, wpływając na sterowanie i strategię.

Zebrane środki wykorzystasz do:
- ulepszania pojazdu,
- rozwoju postaci,
- szybszego zdobywania zasobów.

---

## 🧠 Rozwój postaci i mechaniki

Gra umożliwia:
- 🚗 **Tuning auta** – poprawiający osiągi w trybach gry,
- 🏋️ **Szkolenia kierowcy** – np. trening fizyczny i rozwój umiejętności biznesowych,
- ⚙️ **Efektywność** – ulepszenia wpływają na tempo zarabiania i energię postaci.

---

## 🔋 Energia i koniec dnia

W planach znajduje się **system energii**, zużywanej podczas:
- zbierania pieniędzy,
- treningów,
- wyścigów (w przyszłości).

Obecnie dostępna jest funkcja **zakończenia dnia**, która zmienia datę –  
docelowo ma również:
- odnawiać energię,
- generować losowe wydarzenia,
- przyspieszać rozwój kariery.

---

## ⛽ Gospodarka paliwem

Wejście do trybu Snake = **-1 litr paliwa**.  
Zmusza to gracza do:
- myślenia strategicznego,
- monitorowania zasobów,
- regularnego tankowania auta.

Gra łączy więc zarabianie pieniędzy z zarządzaniem logistyką i pojazdem –  
to **symulator kariery kierowcy**!

---

## 🛠 Planowane funkcjonalności

- 🏁 Nowe tryby gry: wyścigi, naprawy, zlecenia
- 📈 Dynamiczny system ekonomiczny
- 🎲 System wydarzeń losowych
- 💾 Zapis i ładowanie postępu
- 💽 Integracja z bazą danych

---

## 💻 Uruchomienie lokalne1

1. Pobierz repozytorium z githuba, powinno się zapisać pod nazwą: ThePolishRacer-PolishRacer.zip
2. Rozpakuj zipa na komputerze
3. W folderze ThePolishRacer-PolishRacer Otwórz plik `WpfApp1.sln` w Visual Studio  
4. Zbuduj projekt i uruchom (`Start`)  
5. Upewnij się, że projekt domyślny to `WpfApp1`  

---

## 🧪 Testy jednostkowe

Projekt zawiera moduł `WpfApp1.Tests`, w którym znajdują się testy napisane w **xUnit**.  
Testy uruchamiane są:
- automatycznie po każdym pushu do gałęzi `PolishRacer`,
- lokalnie komendą:

```bash
dotnet test WpfApp1.Tests/WpfApp1.Tests.csproj


