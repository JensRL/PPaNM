all: Out.txt
	cat $<
	make lsfit_fig.pdf

lsfit_fig.pdf: lsfit_fig.gpi Out_Data.txt Out_Fit.txt
	gnuplot $<
	
Out.txt: main.exe
	mono $< > $@

main.exe: main.cs lsfit.dll matrix.dll lineareq.dll vector.dll
	mcs $< -reference:lineareq.dll,matrix.dll,vector.dll,lsfit.dll

lsfit.dll: lsfit.cs lineareq.dll matrix.dll vector.dll
	mcs $< -target:library -reference:lineareq.dll,matrix.dll,vector.dll

lineareq.dll: lineareq.cs matrix.dll vector.dll
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
	rm [Oo]ut.* *.exe *.pdf *.log *.aux *.png *.txt
