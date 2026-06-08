# Záhada zmizelé černé díry

> Point-and-click adventura inspirovaná českou hrou Polda.

---

## Příběh

Jsi **kapitán Venda**, nejlepší (a jediný) detektiv v galaxii. Z oficiálních vesmírných map záhadně zmizela černá díra č.42. Mezigalaktická rada tě pošle to vyšetřit — protože někdo musí.

Tvým úkolem je projít všechny lokace, sbírat stopy a odhalit co se skutečně stalo s černou dírou č.42.

---

## Ovládání

Klasická point-and-click adventura. Klikej na objekty a postavy, sbírej předměty do inventáře a řeš hádanky.

**Klávesy:**
- `Levé tlačítko myši` — interakce s objekty
- `I` — otevřít/zavřít inventář
- `Esc` — pauza

---

## Lokace

| Lokace | Popis |
|---|---|
| Vesmírná stanice | Hlavní lokace. Chaotický velitelský prostor. |
| Velín | Řídící středisko stanice se šifrovanou zprávou. |
| Šachta | Temná vertikální chodba spojující více oblastí. |
| Kajuty | Obytné prostory posádky s rozbitým dekodérem. |
| Strojovna | Hlučná místnost s unavením mechanikem. |
| Kryogenická komora | Mrazivá místnost s kapsulemi — jedna je prázdná. |
| Storage | Temný sklad plný beden, včetně bedny č.42. |
| Výskumná stanice | Laboratoř Dr. Vesmíráka. |
| Asteroid Bar | Podivný bar na asteroidu. |
| Vesmír | Otevřený vesmírný prostor mimo stanici. |
| Vesmírná pláň | Nekonečný temný vesmír. Finální konfrontace. |
| Černá díra | Finální lokace. |

---

## Řetězec akcí

1. **Vesmírná stanice** → mince z automatu → stánkář chce Galaktický čaj
2. **Asteroid Bar** → koupíš čaj za minci (vyhraješ vtipem u barmana) + najdeš druhou část kombinace pro bednu č.42
3. **Vesmírná stanice** → vrátíš se ke stánkáři s čajem → dostaneš kartu → otevřeš fialové dveře
4. **Storage** → bedna č.42 je zamčená → potřebuješ kombinaci ze Šachty a z Baru
5. **Šachta** → najdeš kombinaci na stěně → vrátíš se do Storage → otevřeš bednu → holografický záznam
6. **Velín** → šifrovaná zpráva → potřebuješ dekodér
7. **Kajuty** → najdeš dekodér → je rozbitý → potřebuješ náhradní díl ze Strojovny
8. **Strojovna** → mechanik chce mazivo z Kryogenické komory
9. **Kryogenická komora** → najdeš mazivo + kartu do Výskumné stanice
10. **Strojovna** → dáš mechanikovi mazivo → dostaneš náhradní díl
11. **Kajuty** → opravíš dekodér → vrátíš se do Velínu
12. **Velín** → přečteš zprávu → dozvíš se o Dr. Vesmírákovi
13. **Výskumná stanice** → odemkneš kartou → najdeš finální kód
14. **Vesmír** → Vesmírná pláň odemčena finálním kódem
15. **Vesmírná pláň** → potkáš Dr. Vesmíráka → dostaneš vstup do černé díry
16. **Černá díra** → konec hry

---

## Předměty v inventáři

| Předmět | Kde ho najdeš |
|---|---|
| Mince | Automat na Vesmírné stanici |
| Galaktický čaj | Asteroid Bar |
| Karta | Stánkář na Vesmírné stanici |
| Kombinace (není to item)| Šachta, Asteroid Bar|
| Mazivo | Kryogenická komora |
| Náhradní díl | Strojovna |
| Karta do Výskumné stanice | Kryogenická komora |
| Holografický záznam | Storage |
| Finální kód | Výskumná stanice |

---

## Technologie

- **Engine:** Godot 4.x s C# (Mono)
- **Renderer:** Compatibility
- **Rozlišení:** 1920×1080 (Full HD)
- **Jazyk:** C#

---

## Struktura projektu

```
adventure-game/
├── scenes/         # Všechny .tscn soubory
├── scripts/        # Všechny .cs skripty
│   ├── VesmirnaStanice/    # Skripty Vesmírné stanice
│   ├── Vesmir/             # Skripty Vesmíru
│   └── ...
├── assets/         # Obrázky pozadí (.png)
└── audio/          # Hudba a zvuky
```

---

## Klíčové systémy

### Inventář (`Inventar.cs`)
Statická třída pro správu předmětů hráče. Automaticky aktualizuje UI při změně.


### Dialog systém (`DialogManager.cs`)
CanvasLayer dialog panel s efektem psaní a podporou sekvencí dialogů.

### Systém ukládání (`SaveManager.cs`)
Ukládá a načítá inventář, počty kliknutí na objekty a aktuální scénu do `user://save.json`.

### Herní stav (`GameState.cs`)
Sleduje kolikrát byl každý objekt kliknut.

---

## Jak spustit

1. Nainstaluj [Godot 4.x s Mono](https://godotengine.org/download)
2. Naklonuj tento repozitář
3. Otevři projekt v Godotu
4. Nastav `MainMenu.tscn` jako hlavní scénu: `Projekt → Nastavení projektu → Application → Run → Main Scene`
5. Stiskni `F5` nebo klikni na ▶️

---

## Grafika

Všechna pozadí byla vygenerována pomocí **GeminiGen.AI** v konzistentním sci-fi cartoon stylu.

---

## Licence

Projekt vytvořen pro vzdělávací účely.
