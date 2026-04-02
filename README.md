# Maschinendiagramm

## 📊 Projektbeschreibung

Dieses Projekt ist eine WPF-Anwendung in C#, mit der Produktionsdaten von Maschinen visualisiert werden können.

Der Benutzer kann:

* eine Maschine auswählen
* ein Jahr auswählen
* die Produktionsdaten anzeigen lassen
* das produktivste Jahr bzw. den produktivsten Monat ermitteln

Die Daten werden aus einer MySQL-Datenbank geladen und anschließend grafisch dargestellt.

---

## ⚙️ Technologien

* C# (.NET, WPF)
* MySQL
* MySql.Data (NuGet Package)
* Visual Studio

---

## 🗄️ Datenbank

Die Anwendung benötigt eine MySQL-Datenbank mit dem Namen:

```
produktiondb
```

### 1. Datenbank erstellen

```sql
CREATE DATABASE produktiondb;
```

### 2. Tabellen importieren

Im Projekt befinden sich folgende SQL-Dateien:

* `produktionsdb_maschinen.sql`
* `produktionsdb_produktionsjahr.sql`

Diese müssen in MySQL Workbench importiert werden:

👉 Rechtsklick auf Datenbank → **"Data Import"**
👉 SQL-Dateien auswählen und ausführen

---

## 🧱 Datenbankstruktur

### Tabelle: `maschinen`

| Feld        | Beschreibung    |
| ----------- | --------------- |
| idMaschinen | Primärschlüssel |
| Maschinen   | Maschinenname   |

---

### Tabelle: `produktionsjahr`

| Feld              | Beschreibung                |
| ----------------- | --------------------------- |
| Jahr              | Jahr der Produktion         |
| MaschinenID       | Fremdschlüssel zur Maschine |
| Januar – Dezember | Produktionswerte pro Monat  |

👉 Primärschlüssel: `(Jahr, MaschinenID)`
👉 Fremdschlüssel: `MaschinenID → maschinen.idMaschinen`

---

## 🔌 Verbindung zur Datenbank

Die Verbindung wird im Code hergestellt:

```csharp
string connectionString = "Server=localhost;Database=produktiondb;Uid=root;Pwd=DEIN_PASSWORT;";
```

⚠️ Wichtig:

* Passwort muss angepasst werden
* MySQL Server muss laufen

---

## ▶️ Anwendung starten

1. Projekt in Visual Studio öffnen
2. NuGet-Paket installieren:

   ```
   MySql.Data
   ```
3. Datenbank einrichten (siehe oben)
4. Projekt starten (F5)

---

##  Funktionen

* Auswahl von Maschine und Jahr
* Laden der Produktionsdaten
* Anzeige als Diagramm
* Hervorhebung des höchsten Monatswertes
* Anzeige des produktivsten Monats


##  Verbesserungsmöglichkeiten

* Trennung von Datenzugriff und UI (z. B. Repository Pattern)
* Verwendung von MVVM
* Fehlerbehandlung erweitern
* Diagramm mit Library (z. B. LiveCharts)

---

##  Autor

Erstellt im Rahmen der Ausbildung zum Fachinformatiker (Anwendungsentwicklung)
