all: Fig.oscillator.png

Fig.oscillator.png: fig.oscillator.gpi oscillator.data.txt
	gnuplot $<

oscillator.data.txt: ode.exe
	mono $< 1> $@ 2>log

ode.exe: ode.cs matlib.dll

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