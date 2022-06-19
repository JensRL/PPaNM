all: Out.txt
	cat $<
	make BerrutInterpClassic.pdf
	make BerrutInterpPoly.pdf
	make BerrutInterpGaussian.pdf
	make BerrutInterpDampedOsc.pdf
	make BerrutCompClassic.pdf
	make BerrutCompDampedOsc.pdf

BerrutInterpClassic.pdf: fig1.interp.gpi PlottingData.txt
	gnuplot $<

BerrutInterpPoly.pdf: fig2.interp.gpi PlottingData.txt
	gnuplot $<

BerrutInterpGaussian.pdf: fig3.interp.gpi PlottingData.txt
	gnuplot $<

BerrutInterpDampedOsc.pdf: fig4.interp.gpi PlottingData.txt
	gnuplot $<

BerrutCompClassic.pdf: fig5.interp.gpi BerrutCompData.txt
	gnuplot $<

BerrutCompDampedOsc.pdf: fig6.interp.gpi BerrutCompData.txt
	gnuplot $<

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs cspline.dll berrut.dll qspline.dll
	mcs $< -reference:cspline.dll,berrut.dll,qspline.dll

berrut.dll: berrut.cs
	mcs -target:library -out:./$@ $^

qspline.dll: qspline.cs
	mcs -target:library -out:./$@ $^

cspline.dll: cspline.cs
	mcs -target:library -out:./$@ $^

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll, $^)) $(filter %.cs, $^)

%.dll: %.cs
	mcs -t:library -out:./%.dll $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	rm [Oo]ut.* *.exe *.pdf *.log *.aux *.png *.txt *.dll
