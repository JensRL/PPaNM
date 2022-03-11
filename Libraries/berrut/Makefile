FMT = svg
OPT = font "Arial,20" size 800,600
PLOT = Berrut
PLOTFILE=$(PLOT).$(FMT)
DATA = out.txt
ECHO=/bin/echo

$(PLOTFILE): Makefile $(DATA)
	echo '\
set term $(FMT) $(OPT);\
set out "$(PLOTFILE)";\
set xlabel "x";\
set ylabel "y";\
set title "Rational (Berrut) vs polynomial interpolation";\
plot \
 "$(DATA)" index 0 with points pointtype 5 pointsize 1 title "data"\
,"$(DATA)" index 1 using 1:2 with lines title "polynomial"\
,"$(DATA)" index 1 using 1:3 with lines title "rational"\
	'| tee log | gnuplot

$(DATA): main.exe
	mono $< >$@

main.exe: main.cs matlib.dll
	mcs $< -reference:$(lastword $^)

matlib.dll: berrut.cs
	mcs $< -target:library -out:$@

$(PLOT).gpi: Makefile

clean:
	rm -f *.exe *.dll $(PLOTFILE) $(DATA) *.gpi *.svg out*
