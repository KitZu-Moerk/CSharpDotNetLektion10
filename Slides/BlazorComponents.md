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
    padding: 35px 45px;
    background-color: #f8f9fa;
    color: #212529;
  }
  h1 { color: #512BD4; font-size: 2.0em; margin-top: 0; }
  h2 {
    color: #170C3A;
    border-bottom: 3px solid #512BD4;
    padding-bottom: 6px;
    font-size: 1.4em;
    margin-top: 0;
    margin-bottom: 14px;
  }
  h3 { color: #512BD4; font-size: 1.1em; margin-top: 8px; margin-bottom: 5px; }
  p, ul, ol { margin-bottom: 8px; font-size: 0.88em; }
  li { margin-bottom: 3px; }
  blockquote {
    background: #eef2ff;
    border-left: 6px solid #512BD4;
    margin: 8px 0;
    padding: 8px 12px;
    border-radius: 0 8px 8px 0;
    font-size: 0.85em;
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
    font-size: 0.72em;
    line-height: 1.35;
    padding: 10px 14px;
    margin: 6px 0;
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
    padding: 12px 14px;
    border-radius: 8px;
    border-top: 4px solid #512BD4;
    box-shadow: 0 2px 8px rgba(0,0,0,0.08);
  }
  .card h3 { margin-top: 0; margin-bottom: 6px; font-size: 1.05em; }
  .card p, .card ul, .card ol { font-size: 0.83em; margin-bottom: 4px; }
  .card ul, .card ol { padding-left: 16px; }
  pre.ascii-diagram { font-size: 0.64em; line-height: 1.2; padding: 8px 12px; color: #50fa7b !important; }
---

# 🚀 Blazor WebAssembly Components (.NET 10)
### Client-side Arkitektur, Parent/Child Kommunikaiton & RenderFragment

**Formål**: En dybdegående guide til opbygning af Blazor WebAssembly (WASM) komponenter i .NET 10 med fokus på samspillet mellem Pages og Child Components.

---

## 🧩 1. Blazor WebAssembly (.NET 10) Arkitektur

Blazor WebAssembly afvikler C# kode direkte i browseren via WebAssembly (WASM) runtime uden behov for en konstant WebSocket-forbindelse.

<div class="grid-2">
<div class="card">

### ⚙️ WASM Eksekvering i .NET 10
* **Client-side**: C#-kode og .NET 10 assemblies hentes til browseren og køres i browserens WebAssembly sandkasse.
* **AOT & JIT**: Understøtter Ahead-Of-Time (AOT) kompilering for maksimal ydelse i tung logik.
* **Ingen Server Dependency**: UI opdateres lokalt i browseren — lynhurtige brugerinteraktioner!

</div>
<div class="card">

### 💻 SPA (Single Page Application)
* **DOM Manipulation**: Blazor WASM opdaterer browserens DOM direkte via en effektiv WebAssembly-to-JS bro.
* **REST / Web APIs**: Henter data fra backend mikroservices via `HttpClient` (JSON / gRPC Web).
* **Offline Capability**: Kan køre offline som Progressive Web App (PWA).

</div>
</div>

---

## 🏗️ 2. Komponent-Hierarkiet: Pages vs. Child Components

En Blazor WASM applikation opbygges som et træ af genanvendelige `.razor` komponenter.

```
       [ App.razor ] (Router & App Root)
             │
      [ MainLayout.razor ] (Layout Container)
             │
     ┌───────┴──────────────────────────┐
     ▼                                  ▼
[ ProductsPage.razor ] (@page)      [ ShoppingCartPage.razor ] (@page)
     │                                  │
     ├──> [ ProductCard.razor ] (Child)  └──> [ CartItemRow.razor ] (Child)
     │         └──> [ RatingStars.razor ]             └──> [ AmountInput.razor ]
     └──> [ Pagination.razor ] (Child)
```

* **Page (`@page "/url"`)**: Top-level komponent med routing. Styrer overordnet sidetilstand og hender data via APIs.
* **Child Component**: Genanvendelig UI-byggeklods. Modtager data fra sin parent og sender events tilbage.

---

## 🔄 3. Blazor WASM Komponentens Livscyklus

Når en komponent oprettes og vises i browseren, gennemløber den en veldefineret livscyklus:

```
[ SetParametersAsync ]  ──> Initialiserer parametre fra Parent Page
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
     [ Dispose ]  ──> Oprydning i WASM hukommelse når komponenten fjernes
```

---

## ⏳ 4. WASM Livscyklus i Praksis (Datahentning & JS)

I ren Blazor WASM kører `OnInitializedAsync` **kun én gang** direkte i browseren, hvilket gør den ideel til API-kald via `HttpClient`.

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
        // Sikker placering til browser-API'er i WASM
        await JS.InvokeVoidAsync("initTooltip");
    }
}
```

</div>
</div>

> 💡 **WASM Tip**: Da der ikke er server pre-rendering i ren WASM, undgår man dobbelte API-kald under opstart!

---

## 📥 5. Parent ➔ Child: Parameteroverførsel (`[Parameter]`)

Data flyder **nedad** i hierarkiet fra forældrekomponenten (Page) til børnekomponenten (Child) via parametre.

### 🔹 Child Komponent (`ProductCard.razor`)
```razor
<div class="product-card">
    <h4>@Title</h4>
    <p>Pris: @Price.ToString("C")</p>
</div>

@code {
    [Parameter, EditorRequired] public string Title { get; set; } = string.Empty;
    [Parameter] public decimal Price { get; set; }
}
```

### 🔹 Parent Page (`ProductsPage.razor`)
```razor
@page "/products"

@foreach (var item in productList)
{
    <ProductCard Title="@item.Name" Price="@item.Price" />
}
```

---

## 📤 6. Child ➔ Parent: Kommunikaiton via `EventCallback`

Børnekomponenter informerer deres Parent om brugerhandlinger ved at udløse en `EventCallback` eller `EventCallback<T>`.

<div class="grid-2">
<div class="card">

### 👶 Child (`ProductCard.razor`)
```razor
<button @onclick="HandleClick">Køb</button>

@code {
    [Parameter] public Product Item { get; set; } = default!;
    [Parameter] public EventCallback<Product> OnAddToCart { get; set; }

    private async Task HandleClick()
    {
        // Sender event op til Parent Page
        await OnAddToCart.InvokeAsync(Item);
    }
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
    private List<Product> basket = new();

    private void AddToBasket(Product prod)
    {
        basket.Add(prod); // Parent gen-rendres automatisk!
    }
}
```

</div>
</div>

> ⚡ **Hvorfor `EventCallback`?**: `EventCallback` udløser **automatisk `StateHasChanged()`** på Parent-komponenten og håndterer `async Task` sikkert i WASM runtime.

---

## 🧩 7. Parent & Child Composition: `RenderFragment` & `ChildContent`

Hvad hvis en Parent ønsker at sende **HTML/Razor markering** direkte ind i en Child komponent? Her bruges `RenderFragment` og konventionen `ChildContent`!

<div class="grid-2">
<div class="card">

### 📦 Child Komponent (`Card.razor`)
```razor
<div class="card-container">
    <div class="card-header">@HeaderTitle</div>
    <div class="card-body">
        @ChildContent <!-- Rendrer indhold fra Parent -->
    </div>
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

> 💡 **Hvad er `ChildContent`?**: Når et parameter i en child komponent hedder præcis `ChildContent` af typen `RenderFragment`, opfanger Blazor automatisk alt markup skrevet imellem child-tags'ene!

---

## 🎨 8. Avancerede Skabeloner: `RenderFragment<TItem>`

Med skabelon-parametre (`RenderFragment<TItem>`) kan en Child-komponent sende **data-kontekst** tilbage til Parent's UI-skabelon (f.eks. til genanvendelige tabeller og lister).

### 📋 Generic List Child (`DataList.razor`)
```razor
@typeparam TItem

<ul>
    @foreach (var item in Items)
    {
        <li>@ItemTemplate(item)</li> <!-- Sender 'item' som kontekst til Parent -->
    }
</ul>

@code {
    [Parameter] public IReadOnlyList<TItem> Items { get; set; } = Array.Empty<TItem>();
    [Parameter] public RenderFragment<TItem> ItemTemplate { get; set; } = null!;
}
```

### 🏠 Parent Page (`UsersPage.razor`)
```razor
<DataList Items="@userList">
    <ItemTemplate Context="user">
        <strong>@user.Name</strong> — <span>@user.Email</span>
    </ItemTemplate>
</DataList>
```

---

## 🌊 9. Dybe Hierarkier: `[CascadingParameter]` & `<CascadingValue>`

Når data skal overføres igennem mange komponent-niveauer (f.eks. Auth State, Tema eller Global Session), undgås "prop-drilling" med Cascading Values.

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

> 🔐 **.NET 10 WASM Integration**: Blazors `AuthenticationStateProvider` benytter internt `CascadingParameter` til at levere brugerens log ind-status til alle underkomponenter.

---

## 🔄 10. Two-Way Data Binding (`@bind` & .NET 10)

Blazor understøtter to-vejs databinding mellem Parent og Child ved hjælp af `Value` og `ValueChanged` navnekonventionen.

<div class="grid-2">
<div class="card">

### 🎛️ Child Component (`CustomCounter.razor`)
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

<!-- Advanced .NET 10 Binding med Modifier -->
<input @bind:get="searchQuery"
       @bind:set="(val) => searchQuery = val"
       @bind:after="PerformSearchAsync" />
```

</div>
</div>

* `@bind-Count="currentCount"` binder automatisk `Count` og lytter på `CountChanged`.
* `@bind:after` gør det let at køre async søge-kald efter binding-opdatering uden manuel setter.

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

## ⚡ 12. WASM Rendering, Diffing & Performance i .NET 10

Blazor WASM opdaterer browserens DOM via en in-memory **RenderTree Diffing Engine**.

```
[ C# Tilstandsændring i WASM ]
               │
               ▼
    [ Nyt RenderTree Bygges ]
               │
               ▼
    [ Diff mod Forrige RenderTree ]  ──> Genererer minimal sæt DOM-opdateringer
               │
               ▼
[ WASM ➔ JS DOM Opdatering i Browser ]
```

### 🚀 Optimeringstips for Child Komponenter:
1. **Brug `@key` i lister**: Hjælper WASM med at spore elementer ved sortering (`<ItemRow @key="item.Id" />`).
2. **Overvej `ShouldRender()`**: Forhindrer gen-rendering af tung børne-UI hvis data ikke har ændret sig.
3. **Immutability**: Send uforanderlige objekter som parametre for hurtig sammenligning.

---

## 🏆 13. Best Practices for WASM Parent/Child Arkitektur

<div class="grid-2">
<div class="card">

### 🎯 Arkitektur & Dataflow
1. **Unidirectional Dataflow**: Data sendes *ned* via `[Parameter]`, events sendes *op* via `EventCallback`.
2. **Single Responsibility**: Hold børnekomponenter rene og præsentationsorienterede (UI-only). Lad Pages/Services styre forretningslogik.
3. **Brug `RenderFragment`**: Byg fleksible, genanvendelige layouts med `ChildContent`.

</div>
<div class="card">

### 🛡️ Performance & Oprydning i WASM
1. **Hukommelsesoprydning**: Implementer `IDisposable` / `IAsyncDisposable` i børnekomponenter til at afmelde C# events eller timere.
2. **Undgå tunge beregninger i `OnParametersSet`**: Brug cacheniveau eller børne-events.
3. **Brug `EventCallback` frem for `Action`**: Undgår trådlækager og manuelle `StateHasChanged()`-kald.

</div>
</div>

---

## ❓ 14. Spørgsmål & Refleksion

* Hvad er den primære forskel på `RenderFragment` (som f.eks. `ChildContent`) og en standard `[Parameter]` property?
* Hvorfor anbefales `EventCallback<T>` frem for standard C# `Action<T>` til forældre-kommunikation i Blazor WASM?
* Hvordan hjælper `.NET 10` WebAssembly runtime med at optimere rendering i store komponent-træer?

---

# 🎓 Tak for opmærksomheden!
### Spørgsmål eller bemærkninger til Blazor WASM i .NET 10?
