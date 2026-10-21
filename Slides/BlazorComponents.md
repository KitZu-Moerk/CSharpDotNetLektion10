---
marp: true
theme: default
paginate: true
html: true
header: 'C# & .NET 10 — Blazor WebAssembly Components i Dybden'
footer: 'Blazor WASM (.NET 10) | Parent & Child Komponent-Arkitektur'
style: |
  section {
    font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
    padding: 30px 45px 35px 45px;
    background-color: #f8f9fa;
    color: #212529;
  }
  h1 { color: #512BD4; font-size: 2.0em; margin-top: 0; }
  h2 {
    color: #170C3A;
    border-bottom: 3px solid #512BD4;
    padding-bottom: 5px;
    font-size: 1.35em;
    margin-top: 0;
    margin-bottom: 12px;
  }
  h3 { color: #512BD4; font-size: 1.05em; margin-top: 6px; margin-bottom: 4px; }
  p, ul, ol { margin-bottom: 8px; font-size: 0.88em; }
  li { margin-bottom: 3px; }
  blockquote {
    background: #eef2ff;
    border-left: 6px solid #512BD4;
    margin: 8px 0;
    padding: 7px 12px;
    border-radius: 0 8px 8px 0;
    font-size: 0.84em;
  }
  code {
    background-color: #282a36;
    color: #f8f8f2;
    border-radius: 4px;
    padding: 2px 6px;
    font-size: 0.85em;
  }
  pre {
    background-color: #1e1e2e !important;
    border-radius: 8px;
    box-shadow: 0 4px 12px rgba(0,0,0,0.15);
    font-size: 0.70em;
    line-height: 1.32;
    padding: 8px 12px;
    margin: 5px 0;
    color: #f8f8f2 !important;
  }
  pre code { font-size: 1em; padding: 0; background-color: transparent; color: #f8f8f2 !important; }

  /* High-Contrast Code Syntax Highlighting (Dracula Theme) */
  .hljs-keyword, .hljs-selector-tag, .hljs-subst { color: #ff79c6 !important; font-weight: bold; }
  .hljs-title, .hljs-title.class_, .hljs-title.function_ { color: #50fa7b !important; }
  .hljs-built_in, .hljs-type { color: #8be9fd !important; }
  .hljs-string, .hljs-meta .hljs-string { color: #f1fa8c !important; }
  .hljs-number, .hljs-literal { color: #bd93f9 !important; }
  .hljs-comment, .hljs-doctag { color: #7f88a8 !important; font-style: italic; }
  .hljs-meta, .hljs-meta .hljs-keyword, .hljs-attr { color: #ffb86c !important; }
  .hljs-variable, .hljs-template-variable { color: #f8f8f2 !important; }
  .hljs-name, .hljs-tag, .hljs-selector-id, .hljs-selector-class { color: #ff79c6 !important; }
  .hljs-attribute { color: #50fa7b !important; }

  table { width: 100%; border-collapse: collapse; margin: 8px 0; font-size: 0.8em; }
  th { background-color: #512BD4; color: white; padding: 7px 10px; text-align: left; }
  td { border-bottom: 1px solid #dee2e6; padding: 6px 10px; }
  tr:nth-child(even) { background-color: #eef2ff; }
  .grid-2 { display: grid; grid-template-columns: 1fr 1fr; gap: 14px; margin-top: 6px; }
  .grid-3 { display: grid; grid-template-columns: 1fr 1fr 1fr; gap: 12px; margin-top: 6px; }
  .card {
    background: white;
    padding: 11px 13px;
    border-radius: 8px;
    border-top: 4px solid #512BD4;
    box-shadow: 0 2px 8px rgba(0,0,0,0.08);
  }
  .card h3 { margin-top: 0; margin-bottom: 5px; font-size: 1.02em; }
  .card p, .card ul, .card ol { font-size: 0.83em; margin-bottom: 4px; }
  .card ul, .card ol { padding-left: 16px; }
  pre.ascii-diagram { font-size: 0.63em; line-height: 1.2; padding: 8px 12px; color: #50fa7b !important; }
---

# 🚀 Blazor WebAssembly Components (.NET 10)
### Client-side Arkitektur, Parent/Child Kommunikation & RenderFragment

**Formål**: En dybdegående guide til opbygning af Blazor WebAssembly (WASM) komponenter i .NET 10 med fokus på samspillet mellem Pages og Child Components.

---

## 🧩 1. Blazor WebAssembly (.NET 10) Arkitektur

Blazor WebAssembly afvikler C# kode direkte i browseren via WebAssembly (WASM) runtime uden behov for en konstant WebSocket-forbindelse.

<div class="grid-2">
<div class="card">

### ⚙️ WASM Eksekvering i .NET 10
* **Client-side**: C#-kode og .NET 10 assemblies hentes til browseren og afvikles i browserens sandkasse.
* **AOT & JIT**: Understøtter Ahead-Of-Time (AOT) kompilering for maksimal ydelse i tung logik.
* **Ingen Server Dependency**: UI opdateres lokalt i browseren — lynhurtige brugerinteraktioner!

</div>
<div class="card">

### 💻 SPA (Single Page Application)
* **DOM Manipulation**: Blazor WASM opdaterer browserens DOM direkte via en effektiv WebAssembly-bro.
* **REST / Web APIs**: Henter data fra backend mikroservices via `HttpClient` (JSON / gRPC Web).
* **Offline Capability**: Kan køre offline som Progressive Web App (PWA).

</div>
</div>

---

## 🏗️ 2. Komponent-Hierarkiet: Pages vs. Child Components

En Blazor WASM applikation opbygges som et træ af genanvendelige `.razor` komponenter.

<pre class="ascii-diagram"><code>       [ App.razor ] (Router & App Root)
             │
      [ MainLayout.razor ] (Layout Container)
             │
     ┌───────┴──────────────────────────┐
     ▼                                  ▼
[ ProductsPage.razor ] (@page)      [ ShoppingCartPage.razor ] (@page)
     │                                  │
     ├──> [ ProductCard.razor ] (Child)  └──> [ CartItemRow.razor ] (Child)
     │         └──> [ RatingStars.razor ]             └──> [ AmountInput.razor ]
     └──> [ Pagination.razor ] (Child)</code></pre>

* **Page (`@page "/url"`)**: Top-level komponent med routing. Styrer overordnet sidetilstand og henter data via APIs.
* **Child Component**: Genanvendelig UI-byggeklods. Modtager data fra sin parent og sender events tilbage.

---

## 🔄 3. Blazor WASM Komponentens Livscyklus

Når en komponent oprettes og vises i browseren, gennemløber den en veldefineret livscyklus:

<pre class="ascii-diagram"><code>[ SetParametersAsync ]  ──> Initialiserer parametre fra Parent Page
         │
         ▼
[ OnInitialized / Async ]  ──> Udføres ÉN gang i WASM ved komponent-oprettelse
         │
         ▼
[ OnParametersSet / Async ]  ──> Udføres ved opstart OG når Parent ændrer parametre
         │
         ▼
   [ RenderTreeDiff ]  ──> Bygger UI træ og beregner DOM-ændringer
         │
         ▼
[ OnAfterRender / Async ]  ──> Udføres EFTER HTML er opdateret i DOM'en
         │
         ▼
     [ Dispose ]  ──> Oprydning i WASM hukommelse når komponenten fjernes</code></pre>

---

## ⏳ 4. WASM Livscyklus i Praksis (Datahentning & JS)

I ren Blazor WASM kører `OnInitializedAsync` **kun én gang** direkte i browseren — ideelt til API-kald via `HttpClient`.

<div class="grid-2">
<div class="card">

### 📡 Datahentning i WASM
```csharp
@inject HttpClient Http

protected override async Task OnInitializedAsync()
{
    // Kalder backend REST API fra browseren
    products = await Http
        .GetFromJsonAsync<List<Product>>("api/products");
}
```

</div>
<div class="card">

### 🌐 JS Interop & Browser DOM
```csharp
@inject IJSRuntime JS

protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (firstRender)
    {
        // Sikker browser-adgang efter DOM er klar
        await JS.InvokeVoidAsync("initTooltip");
    }
}
```

</div>
</div>

> 💡 **WASM Tip**: I ren client-side WASM undgås dobbelte API-kald under opstart, da der ikke er server pre-rendering.

---

## 📥 5. Parent ➔ Child: Parameteroverførsel (`[Parameter]`)

Data flyder **nedad** i hierarkiet fra forældrekomponenten (Page) til børnekomponenten (Child) via parametre.

<div class="grid-2">
<div class="card">

### 👶 Child (`ProductCard.razor`)
```razor
<div class="product-card">
    <h4>@Title</h4>
    <p>Pris: @Price.ToString("C")</p>
</div>

@code {
    [Parameter, EditorRequired] 
    public string Title { get; set; } = "";

    [Parameter] 
    public decimal Price { get; set; }
}
```

</div>
<div class="card">

### 👨‍👦 Parent Page (`ProductsPage.razor`)
```razor
@page "/products"

@foreach (var item in productList)
{
    <ProductCard Title="@item.Name" 
                 Price="@item.Price" />
}

@code {
    private List<Product> productList = [];
}
```

</div>
</div>

---

## 📤 6. Child ➔ Parent: Kommunikation via `EventCallback`

Børnekomponenter informerer deres Parent om brugerhandlinger ved at udløse en `EventCallback<T>`.

<div class="grid-2">
<div class="card">

### 👶 Child (`ProductCard.razor`)
```razor
<button @onclick="HandleClick">Køb</button>

@code {
    [Parameter] public Product Item { get; set; } = default!;
    [Parameter] public EventCallback<Product> OnAddToCart { get; set; }

    private async Task HandleClick() 
        => await OnAddToCart.InvokeAsync(Item);
}
```

</div>
<div class="card">

### 👨‍👦 Parent Page (`ProductsPage.razor`)
```razor
<ProductCard Item="@currentProduct" 
             OnAddToCart="AddToBasket" />

<p>Antal i kurv: @basket.Count</p>

@code {
    private List<Product> basket = [];

    private void AddToBasket(Product prod) 
        => basket.Add(prod); // Trigger re-render!
}
```

</div>
</div>

> ⚡ **Hvorfor `EventCallback`?**: Udløser automatisk `StateHasChanged()` på Parent og håndterer `async Task` sikkert i runtime.

---

## 🧩 7. Composition: `RenderFragment` & `ChildContent`

Send **HTML/Razor markering** direkte fra Parent ind i en Child komponent via `RenderFragment`.

<div class="grid-2">
<div class="card">

### 📦 Child Komponent (`Card.razor`)
```razor
<div class="card-container">
    <div class="card-header">@HeaderTitle</div>
    <div class="card-body">@ChildContent</div>
</div>

@code {
    [Parameter] public string HeaderTitle { get; set; } = "";
    [Parameter] public RenderFragment? ChildContent { get; set; }
}
```

</div>
<div class="card">

### 🏠 Parent Page (`Dashboard.razor`)
```razor
<Card HeaderTitle="Bruger Profil">
    <!-- Alt indhold her sendes til ChildContent -->
    <p>Navn: Anders And</p>
    <button class="btn">Rediger</button>
</Card>
```

</div>
</div>

> 💡 **Konvention**: Parameter navngivet præcis `ChildContent` af typen `RenderFragment` opfanger automatisk markup imellem tags'ene!

---

## 🎨 8. Skabelon-parametre: `RenderFragment<TItem>`

Med skabelon-parametre kan en Child-komponent sende data-kontekst tilbage til Parent's UI-skabelon.

<div class="grid-2">
<div class="card">

### 📋 Generic Child (`DataList.razor`)
```razor
@typeparam TItem

<ul>
    @foreach (var item in Items)
    {
        <li>@ItemTemplate(item)</li>
    }
</ul>

@code {
    [Parameter] 
    public IReadOnlyList<TItem> Items { get; set; } = [];
    
    [Parameter] 
    public RenderFragment<TItem> ItemTemplate { get; set; } = null!;
}
```

</div>
<div class="card">

### 🏠 Parent Page (`UsersPage.razor`)
```razor
<DataList Items="@userList">
    <ItemTemplate Context="user">
        <strong>@user.Name</strong>
        <span>(@user.Email)</span>
    </ItemTemplate>
</DataList>

@code {
    private List<User> userList = [];
}
```

</div>
</div>

---

## 🌊 9. Dybe Hierarkier: Cascading Values & Parameters

Undgå "prop-drilling" over mange komponent-niveauer ved at lade data flyde kaskaderende ned igennem træet.

<div class="grid-2">
<div class="card">

### 🌊 Parent / Layout Container
```razor
<CascadingValue Value="@currentTheme" Name="Theme">
    <CascadingValue Value="@currentUser">
        <MainLayout>
            @Body
        </MainLayout>
    </CascadingValue>
</CascadingValue>
```

</div>
<div class="card">

### 👶 Dyb Child Komponent
```razor
@code {
    [CascadingParameter(Name = "Theme")] 
    public string Theme { get; set; } = "light";

    [CascadingParameter] 
    public UserState? User { get; set; }
}
```

</div>
</div>

> 🔐 **.NET 10 WASM Integration**: Blazors `AuthenticationStateProvider` benytter internt `CascadingParameter` til brugerens log ind-status.

---

## 🔄 10. Two-Way Data Binding (`@bind` & .NET 10)

Blazor understøtter to-vejs databinding mellem Parent og Child via `Value` og `ValueChanged` konventionen.

<div class="grid-2">
<div class="card">

### 🎛️ Child (`CustomCounter.razor`)
```razor
<button @onclick="Increment">+</button>
<span>@Count</span>

@code {
    [Parameter] public int Count { get; set; }
    [Parameter] public EventCallback<int> CountChanged { get; set; }

    private async Task Increment() 
        => await CountChanged.InvokeAsync(Count + 1);
}
```

</div>
<div class="card">

### 🏠 Parent Page (.NET 10 Syntaks)
```razor
<!-- To-vejs bind mod Child -->
<CustomCounter @bind-Count="currentCount" />

<!-- .NET 10 Binding med Modifier & After -->
<input @bind:get="searchQuery"
       @bind:set="(val) => searchQuery = val"
       @bind:after="PerformSearchAsync" />
```

</div>
</div>

> ⚡ **Konvention & .NET 10**: `@bind-Count` mapper til `Count` + `CountChanged`. `@bind:after` eksekverer en async søgemetode direkte efter opdatering.

---

## 🎯 11. Parent Kontrol: `@ref` & `<DynamicComponent>`

Nogle gange har Parent-komponenten brug for direkte adgang til Child-objektet eller skal indlæse komponenter dynamisk.

<div class="grid-2">
<div class="card">

### 🎯 Komponent Referencer (`@ref`)
```razor
<ModalDialog @ref="modalRef" />
<button @onclick="OpenModal">Åbn</button>

@code {
    private ModalDialog? modalRef;
    
    private void OpenModal() 
        => modalRef?.Show(); // Kalder metode direkte på Child
}
```

</div>
<div class="card">

### 🔀 `<DynamicComponent>`
```razor
<DynamicComponent Type="@selectedType" 
                  Parameters="@componentParams" />

@code {
    private Type selectedType = typeof(UserProfileTab);
    private Dictionary<string, object?> componentParams = new() {
        { "UserId", 42 }
    };
}
```

</div>
</div>

---

## ⚡ 12. WASM Rendering & Diffing Pipeline

Blazor WASM opdaterer browserens DOM via en in-memory **RenderTree Diffing Engine**.

<pre class="ascii-diagram"><code>[ C# Tilstandsændring i WASM ]
               │
               ▼
    [ Nyt RenderTree Bygges ]
               │
               ▼
    [ Diff mod Forrige RenderTree ]  ──> Genererer minimalt sæt DOM-opdateringer
               │
               ▼
[ WASM ➔ JS DOM Opdatering i Browser ]</code></pre>

* **C# Execution i Browser**: Ændringer i komponentens tilstand udløser genberegning i WASM runtime.
* **Effektiv DOM-synkronisering**: Kun de elementer og attributter, der reelt er ændret, skrives til browserens DOM.

---

## 🚀 13. WASM Performance Optimering i Praksis

I WebAssembly-miljøet er minimering af unødige render-kald nøglen til en flydende brugeroplevelse.

<div class="grid-3">
<div class="card">

### 🔑 Brug `@key` i Lister
Hjælper WASM med at spore elementer ved sortering eller filtrering, så DOM-knuder genbruges:
```razor
<ItemRow @key="item.Id" 
         Item="item" />
```

</div>
<div class="card">

### 🛑 `ShouldRender()`
Forhindrer gen-rendering af tunge børnekomponenter, hvis data ikke har ændret sig:
```csharp
protected override bool 
    ShouldRender() => isDirty;
```

</div>
<div class="card">

### 📦 Immutability
Brug uforanderlige records (`record class`) som parametre for lynhurtig reference-sammenligning i stedet for dybe scanninger.

</div>
</div>

---

## 🏆 14. Best Practices for WASM Parent/Child Arkitektur

<div class="grid-2">
<div class="card">

### 🎯 Arkitektur & Dataflow
1. **Unidirectional Dataflow**: Data sendes *ned* via `[Parameter]`, events sendes *op* via `EventCallback`.
2. **Single Responsibility**: Hold børnekomponenter rene og præsentationsorienterede (UI-only).
3. **Brug `RenderFragment`**: Byg fleksible, sammensættelige layouts med `ChildContent`.

</div>
<div class="card">

### 🛡️ Performance & Oprydning i WASM
1. **Hukommelsesoprydning**: Implementer `IDisposable` til at afmelde C# events eller timere.
2. **Lette `OnParametersSet`**: Undgå tunge beregninger ved hver parameteropdatering.
3. **Brug `EventCallback`**: Undgå manuelle `StateHasChanged()`-kald og trådlækager.

</div>
</div>

---

## ❓ 15. Spørgsmål & Refleksion

* Hvad er den primære forskel på `RenderFragment` (som f.eks. `ChildContent`) og en standard `[Parameter]` property?
* Hvorfor anbefales `EventCallback<T>` frem for standard C# `Action<T>` til forældre-kommunikation i Blazor WASM?
* Hvordan hjælper RenderTree diffing i .NET 10 WebAssembly med at opnå høj performance i store komponent-træer?

---

# 🎓 Tak for opmærksomheden!
### Spørgsmål eller bemærkninger til Blazor WASM i .NET 10?
