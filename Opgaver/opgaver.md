# 🛠️ Blazor WebAssembly Komponent-Opgaver

Formålet med disse opgaver er at opbygge genanvendelige komponenter i Blazor WebAssembly og opnå en dybere forståelse for, hvordan komponenter opbygges, sammensættes og udveksler data og hændelser med hinanden.

---

## 📋 Opgave 1: Genanvendelig Dialogboks (Modal)

### 🎯 Formål
At udvikle en genanvendelig dialogboks, der kan åbnes oven på siden og vise vilkårligt indhold defineret af den side, som anvender komponenten.

### 📂 Udgangspunkt
I projektet `ComponentsExercises` er der forberedt to filer, som I skal tage udgangspunkt i:
* [Modal.razor](file:///e:/DotNet/4Semester/CSharpDotNetLektion10/Opgaver/ComponentsExercises/Components/Modal.razor) – Indeholder den grundlæggende HTML-skal til en Bootstrap modal.
* [Home.razor](file:///e:/DotNet/4Semester/CSharpDotNetLektion10/Opgaver/ComponentsExercises/Pages/Home.razor) – En forældreside med en knap og et tomt kald til komponenten.

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
* [Stars.razor](file:///e:/DotNet/4Semester/CSharpDotNetLektion10/Opgaver/ComponentsExercises/Components/Stars.razor) – Indeholder en grundlæggende struktur med 5 stjerner.
* [Stars.razor.css](file:///e:/DotNet/4Semester/CSharpDotNetLektion10/Opgaver/ComponentsExercises/Components/Stars.razor.css) – Scoped CSS med styling til containeren, inaktive stjerner, udfyldte stjerner (`.filled`) og hover-effekt.
* [RatingPage.razor](file:///e:/DotNet/4Semester/CSharpDotNetLektion10/Opgaver/ComponentsExercises/Pages/RatingPage.razor) – En side, der præsenterer en film og kalder `<Stars />`.

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
