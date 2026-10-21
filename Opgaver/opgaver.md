# 🛠️ Blazor WebAssembly Komponent-Opgaver

Formålet med disse opgaver er at opbygge genanvendelige komponenter i Blazor WebAssembly og opnå en dybere forståelse for, hvordan komponenter opbygges, sammensættes og udveksler data og hændelser med hinanden.

---

## 📋 Opgave 1: Genanvendelig Dialogboks (Modal)

### 🎯 Formål
At udvikle en genanvendelig dialogboks, der kan åbnes oven på siden og vise vilkårligt indhold defineret af den side, som anvender komponenten.

### 📂 Udgangspunkt
I projektet `ComponentsExercises` er der forberedt to filer, som I skal tage udgangspunkt i:
* [Modal.razor](file:///C:/dotNet/25Y/CSharpDotNetLektion10/Opgaver/ComponentsExercises/Components/Modal.razor) – Indeholder den grundlæggende HTML-skal til en Bootstrap modal.
* [Home.razor](file:///C:/dotNet/25Y/CSharpDotNetLektion10/Opgaver/ComponentsExercises/Pages/Home.razor) – En forældreside med en knap og et tomt kald til komponenten.

### 📝 Ønsket Funktionalitet
1. **Styring af synlighed:**
   * Forældresiden skal udefra kunne styre, hvornår dialogboksen skal vises, og hvornår den skal være skjult.
2. **Dynamisk overskrift:**
   * Siden, der benytter dialogboksen, skal kunne give den en valgfri overskrift/titel, som vises i toppen af boksen.
3. **Fleksibelt indhold:**
   * Dialogboksen må ikke være låst til én bestemt type indhold. Forældresiden skal frit kunne indsætte vilkårligt markup (f.eks. forklarende tekst, advarsler, billeder eller formularfelter) direkte i dialogboksens krop, uden at modal-komponenten kender til indholdet på forhånd.
4. **Lukning og underretning:**
   * Når brugeren klikker på krydset i øverste højre hjørne, skal komponenten give besked tilbage til forældresiden, så siden kan opdatere sin tilstand og lukke dialogen.
5. **Demonstration i brugergrænsefladen:**
   * På forsiden skal det demonstreres, at dialogboksen kan åbnes via knappen, viser den ønskede titel og indhold pænt, og at den lukker igen som forventet.

#### 💡 Ekstra udfordring (Valgfri)
* Gør det muligt for brugeren at lukke dialogboksen ved at klikke på den mørke baggrund uden for selve boksen.
* Giv mulighed for, at forældresiden også kan levere egne handlingsknapper til bunden af dialogen (f.eks. "Gem" og "Annuller").

---

## ⭐ Opgave 2: Interaktivt Rating-system (Stjerner)

### 🎯 Formål
At udvikle en visuel og interaktiv stjerne-komponent, som lader brugeren afgive en bedømmelse og automatisk holder forældresiden opdateret om ændringen.

### 📂 Udgangspunkt & Starter-kode
I projektet `ComponentsExercises` er der forberedt følgende filer som udgangspunkt:
* [Stars.razor](file:///C:/dotNet/25Y/CSharpDotNetLektion10/Opgaver/ComponentsExercises/Components/Stars.razor) – Indeholder en grundlæggende struktur med 5 stjerner.
* [Stars.razor.css](file:///C:/dotNet/25Y/CSharpDotNetLektion10/Opgaver/ComponentsExercises/Components/Stars.razor.css) – Scoped CSS med styling til containeren, inaktive stjerner, udfyldte stjerner (`.filled`) og hover-effekt.
* [RatingPage.razor](file:///C:/dotNet/25Y/CSharpDotNetLektion10/Opgaver/ComponentsExercises/Pages/RatingPage.razor) – En side, der præsenterer en film og kalder `<Stars />`.

### 📝 Ønsket Funktionalitet
1. **Færdiggør `Stars.razor`:**
   * Komponenten viser i udgangspunktet 5 statiske stjerner. Gør komponenten dynamisk, så den kan modtage en bedømmelse fra forældresiden og afspejle den i antallet af udfyldte stjerner (`.filled`).
   * Gør stjernerne klikbare, så brugeren kan klikke på en stjerne og vælge en ny bedømmelse (1-5).
   * Når der klikkes, skal komponenten straks underrette forældresiden om den nye værdi.
2. **Forbind og test i `RatingPage.razor`:**
   * Kobl stjernekomponenten sammen med filmens rating, så siden viser filmens nuværende bedømmelse i stjerner.
   * Sørg for, at filmens rating på siden opdateres med det samme, når brugeren klikker på en ny stjerne.

#### 💡 Ekstra udfordring (Valgfri)
* **Forhåndsvisning (Hover):** Få stjernerne til midlertidigt at lyse op i en forhåndsvisning, når musen føres hen over dem, inden der reelt klikkes.
* **Læse-tilstand:** Tilføj mulighed for at låse komponenten, så den blot viser en eksisterende bedømmelse uden mulighed for brugerinteraktion.

---

## 📄 Opgave 3: Genanvendelig Paginering (Pagination)

### 🎯 Formål
At udvikle en genanvendelig paginerings-komponent, der kan opdele store datamængder i overskuelige sider, beregne det samlede antal sider dynamisk og underrette forældresiden om sideskift.

### 📂 Udgangspunkt & Starter-kode
I projektet `ComponentsExercises` er der forberedt følgende filer som udgangspunkt:
* [Pagination.razor](file:///C:/dotNet/25Y/CSharpDotNetLektion10/Opgaver/ComponentsExercises/Components/Pagination.razor) – Indeholder en grundlæggende Bootstrap-pagineringsstruktur med statiske knapper.
* [PaginationPage.razor](file:///C:/dotNet/25Y/CSharpDotNetLektion10/Opgaver/ComponentsExercises/Pages/PaginationPage.razor) – En forældreside, der præsenterer en produktliste med testdata og kalder `<Pagination />`.

### 📝 Ønsket Funktionalitet
1. **Gør `Pagination.razor` dynamisk:**
   * Komponenten skal modtage oplysninger udefra om det samlede antal elementer, sidestørrelsen (antal elementer pr. side) og den aktuelt valgte side.
   * Komponenten skal selv udregne, hvor mange sider der i alt er.
   * Generer sidetallene dynamisk, så den aktuelle side markeres som aktiv (`.active`).
   * "Forrige"-knappen skal være deaktiveret (`.disabled`), når man befinder sig på første side.
   * "Næste"-knappen skal være deaktiveret (`.disabled`), når man befinder sig på den sidste side.
2. **Hændelser og kommunikation til forældresiden:**
   * Når brugeren klikker på et sidetal, "Forrige" eller "Næste", skal komponenten underrette forældresiden om den nye side.
   * Sørg for, at klik på en deaktiveret knap eller på den allerede aktive side ikke udløser unødige hændelser.
3. **Forbind og test i `PaginationPage.razor`:**
   * Forbind `Pagination`-komponenten med sidens tilstand, så tabellen kun viser de produkter, der hører til den valgte side.
   * Kontroller, at både produktvisningen og oversigten i toppen opdateres med det samme, når der navigeres mellem siderne.

#### 💡 Ekstra udfordring (Valgfri)
* **Valgfri sidestørrelse:** Giv forældresiden eller brugeren mulighed for at vælge antal elementer pr. side (f.eks. 5, 10 eller 20) og se sidetallene tilpasse sig automatisk.
* **Maksimalt synlige sidetal:** Hvis der er mange sider, skal komponenten kun vise et udvalgt udsnit af sidetal omkring den aktuelle side frem for alle sidetal på én gang.

