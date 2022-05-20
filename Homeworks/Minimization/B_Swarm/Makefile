all: Out.txt
	cat $<
	make higgsfit_fig.pdf
	
Out.txt: main.exe inputdata.txt
	mono $< > $@

higgsfit_fig.pdf: higgsfit.gpi inputdata.txt higgsfit.txt
	gnuplot $<

main.exe: main.cs minimize.dll matrix.dll vector.dll 
	mcs $< -reference:minimize.dll,matrix.dll,vector.dll

minimize.dll: minimize.cs swarm.cs matrix.dll vector.dll
	mcs $< -target:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs 
	mcs -target:library -out:./$@ $^

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll, $^)) $(filter %.cs, $^)

%.dll: %.cs
	mcs -t:library -out:./%.dll $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	rm [Oo]ut.* *.exe *.pdf *.log *.aux *.png
