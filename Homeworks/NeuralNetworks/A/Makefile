all: Out.txt
	cat $<
	make ANNinterp_fig.pdf

Out.txt: main.exe
	mono $< > $@

ANNinterp_fig.pdf: ANNinterp.gpi PlottingData.txt
	gnuplot $<

main.exe: main.cs minimize.dll matrix.dll vector.dll neuralnet.dll
	mcs $< -reference:minimize.dll,matrix.dll,vector.dll,neuralnet.dll

neuralnet.dll: neuralnet.cs minimize.dll matrix.dll vector.dll
	mcs $< -target:library -reference:minimize.dll,matrix.dll,vector.dll

minimize.dll: minimize.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll,vector.dll

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
