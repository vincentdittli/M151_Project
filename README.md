# M151_Project

Projektbeschrieb Spital

##Um was geht es im Projekt?

In dem Projekt geht es um ein Spital, welches Patienten enthaltet. Jeder Patient hat ein Doktor und ein Gesundheitsstatus.
Jeder Doktor kann den Gesundheitsstatus von seinen Patienten in der Datenbank verändern. 

|Personengruppe|    Personenbeschreibung|
|--------------|:-----------------:|
|Administrator|    Kann Patienten hinzufügen, bearbeiten und entfernen|
|Patient| Kann seinen Health Status und sein Doktor anschauen|
|Doktor| Kann seine Patienten bearbeiten und neue hinzufügen|

##Nutzen der Applikation

Jeder Doktor sollte all seine Patienten sehen und Bearbeiten. Jeder Patient kann seinen Gesundheitsstatus (vielleicht Corona Positiv) nachschauen, und schauen ob er einen Doktorwechsel hat. Der Administrator kann alles manipulieren. 

|Nr.|    User Stories|
|----|:------------:|
|01|    Als Administrator möchte ich alle User sehen, damit ich sie bei beliebig manipulieren kann.|
|02|    Als Kunde möchte ich meinen Gesundheitsstatus sehen.|
|03|    Als Doktor möchte ich all meine Patienten sehen, damit ich eine übersicht habe. |
|04|    Als Doktor und Administrator möchte ich den Gesundheitsstatus von meinen Patienten ändern können.|
|05|    Als Doktor und Administration möchte ich einen neuen Patient hinzufügen.|
|06|    Als Kunde möchte ich eine Anfrage erstellen, um meinen Doktor zu wechseln|
|07|    Als Doktor möchte ich alle Anfragen sehen, um sie zu akzeptieren|

##Technologien
Zum Programmieren verwende ich Visual Studio und Resharper.
Ich brauche Docker, auf welcher eine MsSql Datenbank läuft. 
Um die Daten in C# Code umzuwandeln brauche ich das Entity Framework.
Das Frontend brauche ich ASP.Net Core.
