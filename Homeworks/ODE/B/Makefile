all: Out.txt DampedOsc_fig.pdf
	cat $<

DampedOsc_fig.pdf: DampedOsc_fig.gpi 
	gnuplot $<

Out.txt: main.exe 
	mono $< 1> Out.txt 2> solution.txt

main.exe: main.cs ODE.dll vector.dll genlist.dll
	mcs $< -reference:ODE.dll,vector.dll,genlist.dll

ODE.dll: ODE.cs vector.dll genlist.dll
	mcs $< -target:library -reference:vector.dll,genlist.dll

genlist.dll: genlist.cs
	mcs -target:library -out:./$@ $^

vector.dll: vector.cs 
	mcs -target:library -out:./$@ $^

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll, $^)) $(filter %.cs, $^)

%.dll: %.cs
	mcs -t:library -out:./%.dll $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	rm [Oo]ut.* *.exe *.pdf *.log *.aux *.png *.txt
