# Maschinendiagramm

##  Projektbeschreibung

Dieses Projekt ist eine WPF-Anwendung in C#, mit der Produktionsdaten von Maschinen visualisiert werden können.

Der Benutzer kann:

* eine Maschine auswählen
* ein Jahr auswählen
* die Produktionsdaten anzeigen lassen
* den produktivsten Monat ermitteln

Die Daten werden aus einer MySQL-Datenbank geladen und anschließend grafisch dargestellt.

---

## ⚙️ Technologien

* C# (.NET, WPF)
* MySQL
* MySql.Data (NuGet Package)
* Visual Studio

---

##  Datenbank


Im Projekt befinden sich folgende SQL-Dateien:

* `produktionsdb_maschinen.sql`
* `produktionsdb_produktionsjahr.sql`

Diese müssen in MySQL Workbench importiert werden:

 Rechtsklick auf Datenbank → **"Data Import"**
SQL-Dateien auswählen und ausführen

---

## 🔌 Verbindung zur Datenbank

Die Verbindung wird im Code hergestellt:

```csharp
string connectionString = "Server=localhost;Database=produktiondb;Uid=root;Pwd=DEIN_PASSWORT;";
```

 Wichtig:

* Passwort muss angepasst werden
* MySQL Server muss laufen

---

##  Anwendung starten

1. Projekt in Visual Studio öffnen
2. NuGet-Paket installieren:

   ```
   MySql.Data
   ```
3. Datenbank einrichten (siehe oben)
4. Projekt starten (F5)



