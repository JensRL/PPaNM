all: Out.txt
	cat $<
	make MCErrs_fig.pdf

MCErrs_fig.pdf: MCErrs_fig.gpi McOut.txt
	gnuplot $<

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs mc.dll vector.dll
	mcs $< -reference:mc.dll,vector.dll

mc.dll: mc.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs 
	mcs -target:library -out:./$@ $^

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll, $^)) $(filter %.cs, $^)

%.dll: %.cs
	mcs -t:library -out:./%.dll $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	rm [Oo]ut.* *.exe *.pdf *.log *.aux *.png
