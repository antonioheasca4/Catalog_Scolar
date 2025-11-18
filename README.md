# Catalog Scolar Online

Aplicatie WPF (.NET Framework 4.7.2) pentru gestionarea unui catalog scolar online. Proiectul include ferestre pentru autentificare, inregistrare si un panou pentru elev/profesor care va afisa notele prin componente WPF moderne (LiveCharts, MahApps IconPacks si controale personalizate).

## Functionalitati principale
- **Autentificare** si **inregistrare** utilizatori cu adrese de email si parola. Utilizatorii pot avea roluri de profesor, elev sau parinte, iar autentificarea verifica existenta combinatiilor email/parola in baza de date (`Login.xaml.cs`).
- **Creare conturi noi**: formularul de inregistrare valideaza campurile obligatorii si permite completarea informatiilor specifice rolului ales; utilizatorii sunt inserati in tabelele LINQ to SQL definite in `Online_School_Catalog.dbml` (`Register.xaml.cs`).
- **Ferestre dedicate rolurilor**: dupa autentificare se deschide `StudentWindow`, care foloseste navigarea WPF pentru a incarca pagini precum `Note.xaml`.
- **Acces la baza de date SQL Server** prin conexiune configurata in `App.config` si gestionata de singletonul `DB` (`DB.cs`).

## Cerinte
- Windows cu **.NET Framework 4.7.2** sau mai nou instalat.
- **SQL Server** local (sau accesibil in retea) pentru baza `Online_School_Catalog`.
- **Visual Studio 2019/2022** cu suport WPF si LINQ to SQL.
- Dependintele sunt gestionate prin `packages.config` (FontAwesome.WPF, LiveCharts 0.9.7, MahApps.Metro.IconPacks 5.1.0 etc.).

## Configurare baza de date
1. Creeaza baza de date `Online_School_Catalog` in SQL Server. Poti porni de la structura din `query_catalog.sql` si adapta locatiile fisierelor MDF/LDF dupa necesitati.
2. Verifica string-ul de conexiune din `App.config`:
   ```xml
   <add name="Online_School_Catalog"
        connectionString="Server=localhost;Database=Online_School_Catalog;Trusted_Connection=true" />
   ```
   Daca baza de date ruleaza pe alt server sau foloseste autentificare SQL, actualizeaza valoarea `connectionString` in consecinta.
3. Deschide `Online_School_Catalog.dbml` in Visual Studio pentru a regenera/deschide entitatile LINQ to SQL daca schema a fost modificata.

## Rulare in dezvoltare
1. Deschide solutia `Catalog_Scolar_Online.sln` in Visual Studio.
2. Restaureaza pachetele NuGet la prima compilare (implicit in Visual Studio).
3. Ruleaza proiectul `Catalog_Scolar_Online` setat ca Startup Project.
4. La rulare, fereastra `Login` se deschide implicit; butonul de inregistrare deschide fereastra `Register`, iar autentificarea reusita deschide `StudentWindow`.

## Note pentru contribuiri
- Codul WPF foloseste data binding si pagini navigate in `StudentWindow`. Evita blocarea UI-ului atunci cand adaugi acces la baza de date si foloseste pattern-uri asincrone cand este posibil.
- Daca adaugi noi resurse sau controale personalizate, actualizeaza spatiile de nume in `App.xaml` si `UserControls/`.

