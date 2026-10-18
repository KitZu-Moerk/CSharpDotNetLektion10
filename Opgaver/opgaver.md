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

### 📂 Udgangspunkt
Opret en ny komponent (f.eks. `RatingStars.razor`) i projektets komponent-mappe.

### 📝 Ønsket Funktionalitet
1. **Visning af stjerner:**
   * Komponenten skal visuelt præsentere en række stjerner (f.eks. med et konfigurerbart maksimum, standard 5).
   * Stjernerne skal afspejle den aktuelle bedømmelse, så fx en vurdering på 3 ud af 5 viser tre markerede stjerner og to umarkerede stjerner.
2. **Brugerinteraktion:**
   * Brugeren skal kunne klikke på en hvilken som helst stjerne for at vælge en ny bedømmelse.
3. **Underretning af forældresiden:**
   * Hver gang brugeren vælger en ny bedømmelse, skal komponenten straks underrette den overordnede side om den nye værdi.
4. **Demonstration i brugergrænsefladen:**
   * Opret eller udbyg en side (f.eks. en produktside, filmanmeldelse eller bogside), som benytter stjerne-komponenten.
   * Siden skal tydeligt vise, at brugerens klik slår igennem og opdaterer sidens tilstand med det samme (f.eks. ved at vise den valgte score i en tekst ved siden af).

#### 💡 Ekstra udfordring (Valgfri)
* **Forhåndsvisning (Hover):** Få stjernerne til midlertidigt at lyse op i en forhåndsvisning, når musen føres hen over dem, inden der reelt klikkes.
* **Læse-tilstand:** Tilføj mulighed for at låse komponenten, så den blot viser en eksisterende bedømmelse uden mulighed for brugerinteraktion.
