#Algorytm

W algorytmie rzędy są numerowane 1-11, a w programie 0-10.
W algorytmie miejsca są numerowane 1-18, a w programie 0-17.

Do tego algorytmu będzie potrzebny wskaźnik na poprzednie oraz aktualne miejsce. W każdym rzędzie będą dwa wskaźniki.
Ponieważ sala ma parzystą ilość "miejsc" (18 miejsc jeśli cała sala byłaby zapełniona pojedynczymi krzesłami) oraz 11 rzędów jako najlepsze miejsca
uznajemy miejsca 9 i 10 w 6 rzędzie (idealny środek sali).

Algorytm zaczynamy od sprawdzenia tych miejsc (patrz walidacja_miejsc). Jeśli są dobre to kończymy algorytm.
Jeśli nie to w następnych krokach będziemy szukali miejsca przesuwając się o 1 w lewo/prawo/górę/dół aż do skończenia się miejsc w danym rzędzie lub
kolumnie. Ponieważ każde z miejsc w danej iteracji ma taką samą "wartość" możemy skończyć algorytm po znalezieniu pierwszej dobrej pary.

Zaczynamy pętlę while i wprowadzamy dwie zmienne: minRow = 0 i maxRow = 1. Pętla kończy się jeśli maxRow > minRow lub znajdziemy rozwiązanie.

Pętla for dla wartości i
  Sprawdzamy czy możemy przesunąć lewy wskaźnik w rzędzie (6-i). Jeśli nie to zwiększamy minRow o 1.

  W rzędzie (6+i) przesuwamy lewy wskaźnik o 1 w lewo. Sprawdzamy.
  W rzędzie (6+i) przesuwamy prawy wskaźnik o 1 w prawo. Sprawdzamy.

  Jeśli i != 0
    W rzędzie (6-i) przesuwamy lewy wskaźnik o 1 w lewo. Sprawdzamy.
    W rzędzie (6-i) przesuwamy prawy wskaźnik o 1 w prawo. Sprawdzamy.

Koniec for

Jeśli maxRow <= 6
  Sprawdzamy miejsca 9 i 10 w rzędzie 6 + maxRow.
  Sprawdzamy miejsca 9 i 10 w rzędzie 6 - maxRow.

Kończymy pętle while
Ponieważ nie znaleźliśmy miejsca piszemy smutny komunikat.

#walidacja_miejsc
Aby sprawdzić, czy 2 miejsca obok siebie są wolne oraz czy są "dobre" sprawdzamy:
-czy dwa miejsca obok siebie są pojedyncze i wolne,
-czy dwa miejsca obok siebie są podwójne, wolne, i są na tej samej kanapie dla par.
