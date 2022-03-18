all: Fig.interp.png

Fig.interp.png: fig.interp.gpi Out.txt
	gnuplot $<

Out.txt: main.exe
	mono $< 1> $@

main.exe: main.cs matlib.dll

matlib.dll: cspline.cs
	mcs -target:library -out:./$@ $^

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll, $^)) $(filter %.cs, $^)

%.dll: %.cs
	mcs -t:library -out:./%.dll $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	rm [Oo]ut.* *.exe *.pdf *.log *.aux *.png
