.PHONEY: default clean 
default: Gamma.gnuplot.png LnGamma.gnuplot.png

#Creating the figures
Gamma.gnuplot.png: GammaTab.txt OutputGamma.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
 	set title 'Gamma Function' \n\
 	set key right bottom \n\
  	plot [-6:6] [-5:5]'OutputGamma.txt' index 0 using 1:2 with lines title 'Gamma Function',\
 	'GammaTab.txt' with points pointtype 2 title 'Tab Values' \n\
	" | tee log.gpi | gnuplot

LnGamma.gnuplot.png: LnGammaTab.txt OutputLnGamma.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
 	set title 'Log Gamma Function' \n\
 	set key left top \n\
  	plot [0:75] [0:230]'OutputLnGamma.txt' index 0 using 1:2 with lines title 'Log(Gamma Function)',\
 	'LnGammaTab.txt' with points pointtype 2 title 'Tab Values' \n\
	" | tee log.gpi | gnuplot

OutputGamma.txt: Gamma.exe
	mono $< > $@

Gamma.exe: Gamma.cs
	mcs $< -target:exe

OutputLnGamma.txt: LnGamma.exe
	mono $< > $@

LnGamma.exe: LnGamma.cs
	mcs $< -target:exe

clean:
	rm -r *.png log* [Oo]ut* *.exe
