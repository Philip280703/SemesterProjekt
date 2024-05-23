# SemesterProjekt

Dette 1. semesterprojekt er lavet ud fra en case omkring et bolig system til ejendomsmæglerkæden EDC.
Selve systemet er lavet til at ejendomsmægler sidder med det og modtager informationer fra kunderne, dermed er det et internt system.

Eftersom det er et 1. semesterprojekt er databasen lokal og ikke på en fælles server.
Derfor skal følgende steps implementeres, før du kan køre programmet:

For at køre programmet skal man først oprette en database i mssql ved navn 'EDCBolig',
derefter skal man køre en query som giver de nødvendige tables samt nogle values. 
De values skal køres et table af gangen, grundet et brug af identity metoden i mssql i ID kolonnerne.

Når dette er gjort kan man nu gå ind i koden i app.config filen under Models mappen. her tilføjer man en ny connectionstring til ens computers MSSQL server
og navngiver den f.eks. "DefaultX".
Derefter skal metoden øverst i DbHandler ved connectionstring til det navn man har kaldt ens connectionstring.

