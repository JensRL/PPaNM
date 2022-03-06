all: Out.txt fig.erf.png

fig.erf.png: fig.erf.gpi
	gnuplot $<

Out.txt erf.data.txt: main.exe
	mono $< 1> Out.txt 2>erf.data.txt
	python3 test.py >> Out.txt

main.exe: main.cs matlib.dll

LIBDIR = /Users/jensrlarsen/Desktop/AU-Masters/PPaNM/Libraries
matlib.dll: \
	$(LIBDIR)/integrate/integrate.cs \
	$(LIBDIR)/odeint/ode.cs \
	$(LIBDIR)/matrix/vector.cs
	mcs -target:library -out:./$@ $^

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll, $^)) $(filter %.cs, $^)

%.dll: %.cs
	mcs -t:library -out:./%.dll $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	rm [Oo]ut.* *.exe *.pdf *.log *.aux *.png