## ESEMPIO DI LAYOUT PAGINE

```c#


@model AppUser
@{
  ViewData["Title"] = "Fornitore";

  var stato = Model.Stato ? "Attivo" : "Disattivo"; 
  var colore = Model.Stato ? "green" : "red"; 
  var icona = Model.Stato ? "fa-check" : "fa-check"; 

  ViewData["Icona"] = ;
  ViewData["Colore"] = ;
  ViewData["Stato"] = ;
}

<h1>@Model.Nome</h1>
<div class="row">
  <div class="col-md-6">
    <div class="card">
      <div class="card-header">
        <h3 class="card-title">Dettagli</h3>
      </div>
      <div class="card-body ">
        <div class="form-group">
          <label>Nome</label>
          <p>@Model.Nome</p>
        </div>
        <div class="form-group">
          <label>Stato</label>
          <p style="color:@ViewData["Colore"]"><i class="fa @ViewData["Icona"]"></i> @ViewData["Stato"]</p>
        </div>
      </div>
    </div>
  </div>
  @if (Usewr.IsInRole("Admin"))
    {
      <form method="post">
      <button type="submit" asp-action="ToggleActive" asp-route-id="@Model.Id">Toggle Active</button>
      </form>
    }
</div>

```

## PACCHETTI DA SCARICARE PER L'APP

```bash

    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
    dotnet add package Microsoft.AspNetCore.Identity.UI
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

```

## SCRIPT DA LANCIARE PER VISUALIZZARE FILE NASCOSTI DELLA LOGIN E REGISTER

```bash

dotnet aspnet-codegenerator identity -dc IProva.Data.ApplicationDbContext

```