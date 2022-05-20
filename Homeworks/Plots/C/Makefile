CompLnGamma.gnuplot.png: CompOutputLnGamma.txt Makefile
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'Re(z)' \n\
	set ylabel 'Im(z)' \n\
 	set title 'Complex Gamma Function in 3D' \n\
 	set key left top \n\
 	set hidden3d \n\
 	set xyplane at -1 \n\
 	splot [-5:5] [-5:5] [0:30] '$<' index 0 using 2:1:3 with points title 'abs(Gamma(z))', \n\
	"| tee log.gpi | gnuplot

CompOutputLnGamma.txt: CompLnGamma.exe
	mono $< > $@

CompLnGamma.exe: CompLnGamma.cs cmath.dll
	mcs $< -target:exe -reference:cmath.dll

CMATHDIR = /Users/jensrlarsen/Desktop/AU-Masters/PPaNM/Homeworks/Plots/C
cmath.dll : $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^ # note "./" in front of cmath.dll

clean:
	rm -r *.png log* *.txt *.exe


