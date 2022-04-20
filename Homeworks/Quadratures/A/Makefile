all: Out.txt fig.erf.pdf
	cat Out.txt
	
fig.erf.pdf: fig.erf.gpi
	gnuplot $<

Out.txt erf.data.txt: main.exe
	mono $< 1> Out.txt 2>erf.data.txt

main.exe: main.cs quad.dll
	mcs $< -reference:quad.dll

quad.dll: quad.cs 
	mcs $< -target:library

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll, $^)) $(filter %.cs, $^)

%.dll: %.cs
	mcs -t:library -out:./%.dll $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	rm [Oo]ut.* *.exe *.pdf *.log *.aux *.png *.txt
