#Creating the figure
erf.gnuplot.png: erf.data.txt erf.tab.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
 	set title 'Error Function' \n\
 	set key left top \n\
  	plot [-1.2:1.2] [-1.2:1.2] '$<' index 0 using 1:2 with lines title 'Error Function',\
 	'erf.tab.txt' with points pointtype 2 title 'Tab Values' \n\
	" | tee log.gpi | gnuplot

erf.data.txt: main.exe
	mono $< > $@

%.exe: %.cs #A general way to create any .exe from any .cs file in the directory
	mcs $<
