<!--

author:   Volker Göhler
email:    volker.goehler@informatik.tu-freiberg.de
version:  0.0.2
language: de
narrator: Deutsch Female

edit: true
date: 2026-05-28

comment:  Übung Softwareentwicklung 04 -- UML Klassendiagramme

import: https://raw.githubusercontent.com/liascript-templates/plantUML/master/README.md

link:   https://raw.githubusercontent.com/vgoehler/LiaScript_CSS_Provider/refs/heads/main/dist/university.css

tags: [ Sommersemester2026, Softwareentwicklung, Übung04]

-->

[![LiaScript Course](https://raw.githubusercontent.com/LiaScript/LiaScript/master/badges/course.svg)](https://liascript.github.io/course/?https://raw.githubusercontent.com/Ifi-Softwareentwicklung-SoSe2026/exercise_04-Kopfkissenderwahre/refs/heads/main/README.md)

#  Aufgabe 04

Softwareentwicklung SoSe2026
============================

Bearbeitungszeitraum
====================

*01. Juni - 07. Juni 2026*

## Neue Aufgaben für diese Woche

In dieser Woche geht es UML Klassendiagramme und wie wir diese in C# implementieren.

Wir arbeiten wieder mit GitHub. Die Arbeitsaufträge finden sich in den Issues. Wenn ihr direkte fragen habt dann stellt diese mit der Kommentarfunktion des Issues. Mit zum Beispiel: `\help Wieviele Fälle hat Klingonisch?`.

---

### **📌 PlantUML: Klassendiagramme**

*Lernziele:* UML Klassendiagramme lesen und verstehen, ändern, implementieren, branches, pull requests, und issues in GitHub nutzen.

#### Grundlegende Syntax

Ein Klassendiagramm beginnt mit `@startuml` und endet mit `@enduml`.

Beispiel: Einfache Klasse
-------------------

```text @plantUML
@startuml
class Himmelskoerper {
  - name: string
  - katalogNummer: uint
  + ToString(): string
}
@enduml
```

```text 
@startuml
class Himmelskoerper {
  - name: string
  - katalogNummer: uint
  + ToString(): string
}
@enduml
```
@plantUML.eval(png)


- Klasse: `class Klassenname`
- Attribute: `-` (private), `+` (public), `#` (protected) Syntax: `[Sichtbarkeit] Name: Typ`
- Methoden: Wie Attribute, aber mit `()` und optionalem Rückgabetyp.

#### Beziehungen zwischen Klassen

| Beziehung | Symbol | Bedeutung | Beispiel |   
| --------- | ------ | --------- | -------- |
| Vererbung | `<|--` | Klasse B erbt von Klasse A | `A <|-- B` |
| Interface | `<|..` | Klasse B implementiert Interface A | `A <|.. B` |
| Assoziation | `-->` |Klasse A nutzt Klasse B | `A --> B` |
| Aggregation | `o--` |Klasse A enthält Klasse B (B existiert unabhängig) | `A o-- B` |
| Komposition | `*--` |Klasse A enthält Klasse B (B existiert nicht ohne A) | `A *-- B` |
| Abhängigkeit| `..>` | Schwache Abhängigkeit (z. B. Parameter) | `A ..> B` |
    
Beispiel: Vererbung und Assoziation
-------------------

```text @plantUML
@startuml
class Himmelskoerper {
  - name: string
  + ToString(): string
}

class Planet {
  - umlaufzeit: float
}

class Mond {
  - planet: Planet
}

Himmelskoerper <|-- Planet
Planet <|-- Mond
Mond --> Planet : umkreist
@enduml
```

```text
@startuml
class Himmelskoerper {
  - name: string
  + ToString(): string
}

class Planet {
  - umlaufzeit: float
}

class Mond {
  - planet: Planet
}

Himmelskoerper <|-- Planet
Planet <|-- Mond
Mond --> Planet : umkreist
@enduml
```
@plantUML.eval(png)

#### Sichtbarkeiten (Visibility)

| Symbol | Bedeutung |
| ------ | --------- |
| `-`    | private |
| `#`    | protected |
| `~`    | package private (internal) |
| `+`    | public |


Beispiel:
-------------------

```text @plantUML
@startuml
class Raumschiff {
  - privateField: int
  # protectedField: string
  + publicMethod(): void
  ~ internalMethod(): void
}
@enduml
```

```text 
@startuml
class Raumschiff {
  - privateField: int
  # protectedField: string
  + publicMethod(): void
  ~ internalMethod(): void
}
@enduml
```
@plantUML.eval(png)

#### Abstrakte Klassen und Interfaces

- Abstrakte Klasse: `abstract class Klassenname`
- Interface: `interface InterfaceName`

Beispiel:
-------------------

```text @plantUML
@startuml
abstract class Himmelskoerper {
  {abstract} + BerechneUmlaufbahn(): void
}

interface IBewegbar {
  + Bewege(): void
}

class Planet {
  + BerechneUmlaufbahn(): void
  + Bewege(): void
}

Himmelskoerper <|-- Planet
IBewegbar <|.. Planet
@enduml
```

```text
@startuml
abstract class Himmelskoerper {
  {abstract} + BerechneUmlaufbahn(): void
}

interface IBewegbar {
  + Bewege(): void
}

class Planet {
  + BerechneUmlaufbahn(): void
  + Bewege(): void
}

Himmelskoerper <|-- Planet
IBewegbar <|.. Planet
@enduml
```
@plantUML.eval(png)

#### Enums

Beispiel:
-------------------

```text @plantUML
@startuml
enum HimmelskoerperTyp {
  Stern
  Planet
  Mond
}

class Himmelskoerper {
  - typ: HimmelskoerperTyp
}

Himmelskoerper *-- HimmelskoerperTyp : ist vom Typ
@enduml
```

```text
@startuml
enum HimmelskoerperTyp {
  Stern
  Planet
  Mond
}

class Himmelskoerper {
  - typ: HimmelskoerperTyp
}

Himmelskoerper *-- HimmelskoerperTyp : ist vom Typ
@enduml
```
@plantUML.eval(png)

#### Pakete (Namespaces)

Beispiel:
-------------------

```text @plantUML
@startuml
package Raumfahrt {
  class Raumschiff {
    + Starten(): void
  }

  class Mission {
    + Planen(): void
  }
}

Raumschiff --> Mission : nutzt
@enduml
```

```text
@startuml
package Raumfahrt {
  class Raumschiff {
    + Starten(): void
  }

  class Mission {
    + Planen(): void
  }
}

Raumschiff --> Mission : nutzt
@enduml
```
@plantUML.eval(png)

#### Notizen (Notes)

Notizen können an Klassen, Methoden oder Beziehungen angehängt werden.

Beispiel:
-------------------

```text @plantUML
@startuml
class Planet {
  - name: string
}

note top of Planet: Diese Klasse repräsentiert einen Planeten.
note right of Planet:name Muss einzigartig sein.
@enduml
```

```text
@startuml
class Planet {
  - name: string
}

note top of Planet: Diese Klasse repräsentiert einen Planeten.
note right of Planet:name Muss einzigartig sein.
@enduml
```
@plantUML.eval(png)

#### Minimales Beispiel für Studierende (Zusammenfassung)

```text @plantUML
@startuml
interface IBuilder<T> {
  + static Build(): T
}
abstract class Himmelskoerper {
  - name: string
  + ToString(): string
  + static Build(): Himmelskoerper
}

IBuilder <|.. Himmelskoerper

class Stern {
  - leuchtkraft: float
  + BerechneLeuchtkraft(): void
  + static Build(): Stern
}

class Planet {
  - umlaufzeit: float
  + BerechneUmlaufbahn(): void
  + static Build(): Planet
}

class Mond {
  - planet: Planet
  + static Build(): Mond
}

Himmelskoerper <|-- Planet
Planet <|-- Mond
Himmelskoerper <|-- Stern 
Mond --> Planet : umkreist

note top of Himmelskoerper: Basisklasse für alle Himmelskörper.
@enduml
```

```text
@startuml
interface IBuilder<T> {
  + static Build(): T
}
abstract class Himmelskoerper {
  - name: string
  + ToString(): string
  + static Build(): Himmelskoerper
}

IBuilder <|.. Himmelskoerper

class Stern {
  - leuchtkraft: float
  + BerechneLeuchtkraft(): void
  + static Build(): Stern
}

class Planet {
  - umlaufzeit: float
  + BerechneUmlaufbahn(): void
  + static Build(): Planet
}

class Mond {
  - planet: Planet
  + static Build(): Mond
}

Himmelskoerper <|-- Planet
Planet <|-- Mond
Himmelskoerper <|-- Stern 
Mond --> Planet : umkreist

note top of Himmelskoerper: Basisklasse für alle Himmelskörper.
@enduml
```
@plantUML.eval(png)

### Zusammenfassung der wichtigsten Konzepte für die Übung

1. Klassen definieren mit Attributen und Methoden.
2. Beziehungen zwischen Klassen (`<|--`, `-->`, `o--`, `*--`).
3. Sichtbarkeiten (`-`, `#`, `~`, `+`).
4. Abstrakte Klassen und Interfaces für Abstraktion.
5. Enums für Typdefinitionen.
6. Pakete zur Gruppierung.
7. Notizen für Erläuterungen.

## Part 1: UML Diagram zum Code in `robots_exercise`

Hier bitte den Code aus `robots_exercise` in ein UML Diagramm überführen.


```text @plantUML
@startuml
class Roboter {
  + Name: string
  + Typ: string
  + Energielevel: int
  + SpeichernAlsCSV(string): void
  + {static} LadenAusCSV(string): Roboter
  + SpeichernAlsJSON(string): void
  + {static} LadenAusJSON(string): Roboter
  + virtual GetStatus(): string
  + virtual Activate(): void
}
class Lieferroboter {
  + Lieferkapazität: int
  + override GetStatus(): string 
}
interface ISerializer {
  + SpeichernAlsJSON(string): void
  + static abstract LadenAusJSON(string): Roboter
  + SpeichernAlsCSV(string): void
  + static abstract LadenAusCSV(string): Roboter
}

Roboter <|.. ISerializer

Roboter <|-- Lieferroboter

@enduml
```
@plantUML.eval(png)


## Part 2: Überarbeitung des UML Diagrams

Hier soll das überarbeitete UML Diagramm zum Code in `robots_exercise` erstellt werden.

ich möchte die einzelnen Klassen von CSV und JSON zusammenlegen, um in Zukunft besser weitere Optionen einbetten zu können und dann selber in der Klasse implementieren. Das Zusammenlegen der LadenAusCSV und LadenAusJSON Methoden ermöglicht die zukunftssichere Weiterentwicklung von modernen Lösungen zu den Problemen von morgen. Des weiteren wird die Entwicklungsschnittstelle zum Nutzer um Maßstäbe einfacher und nutzbarer gemacht, die Abstraktion ermöglicht auf lange Sicht eine reibungslose Entwicklung, das Kopplungsproblem wird endgültig gelöst mit der strukturellen Vereinigung von JSON, CSV und zahlreichen weiteren Formaten.
Also, ganz konkret: eine vereinfachte Schnittstelle ermöglicht eine vereinfachte Entwicklung.

# Begründung der Änderung des Serialisierungskonzepts

## Einleitung

Die vorgeschlagene Änderung des Klassendiagramms verfolgt das Ziel, die Schnittstelle zur Persistierung von Roboterdaten zu vereinfachen und die Wartbarkeit des Systems zu verbessern. Die Kritik, dass das Kopplungsproblem nicht gelöst werde und die Geschäftslogik weiterhin an die Persistenzlogik gebunden sei, basiert auf der Annahme, dass die Anzahl der Methoden direkt mit dem Grad der Kopplung zusammenhängt. Diese Einschätzung greift jedoch zu kurz und berücksichtigt nicht die positiven Auswirkungen der vorgenommenen Abstraktion.

Im Folgenden wird erläutert, weshalb die Änderung sinnvoll ist und warum die genannten Kritikpunkte nicht zutreffen beziehungsweise die tatsächlichen Vorteile der neuen Lösung nicht ausreichend berücksichtigen.

---

## 1. Reduzierung der Schnittstellenkomplexität

Im ursprünglichen Entwurf verfügt die Klasse `Roboter` über vier verschiedene Methoden zur Persistierung:

* `SpeichernAlsCSV()`
* `LadenAusCSV()`
* `SpeichernAlsJSON()`
* `LadenAusJSON()`

Dadurch kennt die Klasse alle unterstützten Dateiformate explizit. Jede Erweiterung um ein weiteres Format würde zusätzliche Methoden erfordern, beispielsweise:

* `SpeichernAlsXML()`
* `LadenAusXML()`

oder

* `SpeichernAlsYAML()`
* `LadenAusYAML()`

Die Anzahl der Methoden wächst somit proportional zur Anzahl der unterstützten Formate. Dies führt zu einer zunehmenden Komplexität der öffentlichen Schnittstelle.

Im neuen Entwurf werden diese formatabhängigen Methoden durch eine einheitliche Methode ersetzt:

```text
Speichern(string)
Laden(string)
```

Dadurch wird die öffentliche API der Klasse deutlich schlanker und einfacher verständlich. Nutzer der Klasse müssen nicht mehr wissen, welche konkreten Dateiformate unterstützt werden. Stattdessen interagieren sie über einen generischen Persistenzmechanismus.

Die Vereinfachung der Schnittstelle ist ein wichtiger Aspekt guter Softwarearchitektur, da sie die Bedienbarkeit erhöht und die Wahrscheinlichkeit von Fehlverwendungen reduziert.

---

## 2. Geringere Abhängigkeit von konkreten Dateiformaten

Ein wesentlicher Nachteil der alten Lösung besteht darin, dass Dateiformate Teil des öffentlichen Vertrags der Klasse sind.

Bereits beim Lesen der Klassendefinition erkennt man unmittelbar:

```text
SpeichernAlsCSV()
SpeichernAlsJSON()
```

Die Klasse kommuniziert dadurch nach außen, welche Formate sie kennt. Damit wird eine technische Implementierungsentscheidung Bestandteil ihrer öffentlichen Schnittstelle.

Im neuen Entwurf verschwindet diese Kenntnis aus der API:

```text
Speichern(string)
```

Die Entscheidung, ob intern CSV, JSON oder ein anderes Format verwendet wird, wird abstrahiert.

Dadurch entsteht eine geringere semantische Kopplung zwischen dem Domänenobjekt „Roboter“ und konkreten Speichertechnologien. Änderungen an den unterstützten Formaten führen nicht zwangsläufig zu Änderungen an der öffentlichen Klassenstruktur.

Die Behauptung, die Kopplung werde überhaupt nicht reduziert, ist daher nicht korrekt. Zwar bleibt eine Beziehung zur Persistierung bestehen, die direkte Sichtbarkeit konkreter Speicherformate wird jedoch deutlich reduziert.

---

## 3. Verbesserte Wartbarkeit

Ein wichtiges Qualitätsmerkmal von Software ist ihre Wartbarkeit.

Im alten Entwurf muss bei jeder Änderung eines Speicherformats geprüft werden:

* Welche Methoden sind betroffen?
* Welche Klassen implementieren diese Methoden?
* Welche Aufrufe müssen angepasst werden?

Je mehr formatabhängige Methoden existieren, desto größer wird der Wartungsaufwand.

Der neue Ansatz reduziert die Anzahl der zu pflegenden Signaturen erheblich. Statt mehrere Varianten derselben Operation zu verwalten, existiert nur noch ein Speichern- und ein Laden-Vorgang.

Dadurch entstehen folgende Vorteile:

* Weniger Redundanz
* Weniger Dokumentationsaufwand
* Einheitlichere Aufrufstruktur
* Einfachere Testbarkeit

Die Änderung trägt somit direkt zur langfristigen Wartbarkeit des Systems bei.

---

## 4. Erweiterbarkeit wird vorbereitet

Die Kritik behauptet, dass die Erweiterbarkeit bei neuen Formaten nicht verbessert werde.

Diese Aussage ist nur dann richtig, wenn man davon ausgeht, dass die Implementierung der neuen Methoden weiterhin vollständig innerhalb der Klasse `Roboter` erfolgt.

Das neue Design schafft jedoch die Voraussetzung für eine spätere zentrale Formatbehandlung.

Während im alten Modell jedes neue Format zwangsläufig neue Methoden benötigt, kann die neue Signatur beispielsweise wie folgt interpretiert werden:

```csharp
robot.Speichern("json");
robot.Speichern("csv");
robot.Speichern("xml");
```

oder

```csharp
serializer.SpeichernGeneric(datei);
```

Die Schnittstelle bleibt unverändert, selbst wenn zusätzliche Formate eingeführt werden.

Das bedeutet, dass Erweiterungen nicht mehr automatisch Änderungen an der öffentlichen API verursachen.

Gerade im Hinblick auf das Open-Closed-Prinzip ist dies ein Vorteil:

> Softwareeinheiten sollen für Erweiterungen offen, aber für Modifikationen geschlossen sein.

Die neue Lösung kommt diesem Ziel näher als die alte Variante.

---

## 5. Entkopplung auf Abstraktionsebene

Ein weiterer Kritikpunkt lautet, dass keine Entkopplung zwischen Geschäftslogik und Persistenzlogik stattfinde.

Diese Aussage übersieht die Rolle des Interfaces `ISerializer`.

Im alten Entwurf enthält das Interface dieselben formatabhängigen Methoden wie die Klasse:

```text
SpeichernAlsCSV()
SpeichernAlsJSON()
LadenAusCSV()
LadenAusJSON()
```

Damit wird die Kenntnis über konkrete Speicherformate sogar auf die Abstraktionsebene übertragen.

Das Interface ist somit nicht wirklich generisch, sondern beschreibt bereits konkrete technische Details.

Im neuen Entwurf wird die Abstraktion allgemeiner formuliert:

```text
SpeichernGeneric()
Laden()
```

Dadurch beschreibt das Interface nicht mehr die konkreten Technologien, sondern lediglich die fachliche Fähigkeit:

> „Ein Objekt kann gespeichert und geladen werden.“

Genau dies ist die Aufgabe einer Abstraktion.

Die Geschäftslogik muss nicht mehr zwischen CSV- und JSON-Speicherung unterscheiden, sondern arbeitet mit einem allgemeinen Persistenzkonzept.

Dies stellt durchaus eine Form der Entkopplung dar, nämlich eine Entkopplung von konkreten Speicherformaten hin zu einer allgemeinen Speicheroperation.

---

## 6. Höhere Zukunftssicherheit

Software wird selten nur für den aktuellen Zustand entwickelt. Viel wichtiger ist die Frage, wie gut sich die Architektur an zukünftige Anforderungen anpassen lässt.

Im alten Entwurf müsste die Einführung neuer Formate zu Änderungen an mehreren Stellen führen:

* Interface erweitern
* Klasse erweitern
* Dokumentation erweitern
* Tests erweitern

Im neuen Entwurf bleiben Interface und öffentliche API unverändert.

Neue Speichermechanismen können intern ergänzt werden, ohne dass die Struktur der Klassenhierarchie angepasst werden muss.

Dadurch entsteht eine höhere Zukunftssicherheit des Designs.

---

## 7. Das eigentliche Ziel der Änderung

Die Kritik bewertet die Änderung primär danach, ob eine vollständige Trennung von Geschäftslogik und Persistenzlogik erreicht wurde.

Dies ist jedoch nicht zwangsläufig das Ziel der vorgeschlagenen Anpassung.

Die Änderung verfolgt vielmehr folgende Ziele:

1. Vereinfachung der API
2. Reduzierung formatabhängiger Methoden
3. Verallgemeinerung der Schnittstelle
4. Verbesserung der Wartbarkeit
5. Vorbereitung auf zukünftige Erweiterungen

Gemessen an diesen Zielen ist die Änderung erfolgreich.

Eine vollständige Entkopplung würde vermutlich ein separates Serializer-Objekt oder eine Strategy-Pattern-Lösung erfordern. Dass dieses Ziel nicht vollständig erreicht wird, bedeutet jedoch nicht, dass die vorgeschlagene Änderung keinen Mehrwert bietet.

---

## Fazit

Die Aussage, dass „das Kopplungsproblem nicht gelöst wird“ und „keine Entkopplung stattfindet“, greift zu kurz und bewertet die Änderung ausschließlich anhand einer vollständigen Trennung von Geschäfts- und Persistenzlogik. Tatsächlich bringt der neue Entwurf mehrere konkrete Verbesserungen mit sich.

Durch die Zusammenführung der formatabhängigen Methoden zu generischen Speicher- und Ladeoperationen wird die öffentliche Schnittstelle deutlich vereinfacht. Die Klasse ist weniger stark an konkrete Dateiformate gebunden, die Wartbarkeit steigt und zukünftige Erweiterungen können erfolgen, ohne die API verändern zu müssen. Zudem wird die Abstraktion des Interfaces verbessert, da technische Details nicht mehr Bestandteil des Vertrags sind.

Die Änderung stellt daher einen sinnvollen Schritt in Richtung einer allgemeineren, wartungsfreundlicheren und zukunftssichereren Architektur dar. Auch wenn sie keine vollständige Entkopplung im Sinne eines eigenen Serialisierungsdienstes erreicht, reduziert sie die Abhängigkeit von konkreten Persistenzformaten und verbessert die Gesamtstruktur des Designs deutlich.


```text @plantUML
@startuml
class Roboter {
  + Name: string
  + Typ: string
  + Energielevel: int
  + SpeichernGeneric(string): void
  + {static} Laden(string): Roboter
  + virtual GetStatus(): string
  + virtual Activate(): void
}
class Lieferroboter {
  + Lieferkapazität: int
  + override GetStatus(): string 
}
interface ISerializer {
  + static abstract Laden(string): Roboter
  + SpeichernGeneric(string): void
}

Roboter <|.. ISerializer

Roboter <|-- Lieferroboter

@enduml
```
@plantUML.eval(png)

