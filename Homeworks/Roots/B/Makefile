all: Out.txt
	cat $<
	make HydrogenE0Sol_fig.pdf
	make rconv_fig.pdf
	make acc_eps_conv_fig.pdf

Out.txt: main.exe
	mono $< > $@

acc_eps_conv_fig.pdf: acc_eps_conv.gpi acc_eps_conv.txt
	gnuplot $<

rconv_fig.pdf: rconv.gpi rconv.txt
	gnuplot $<

HydrogenE0Sol_fig.pdf: HydrogenE0Sol.gpi E0Solution.txt
	gnuplot $<

main.exe: main.cs roots.dll matrix.dll lineareq.dll vector.dll ODE.dll genlist.dll
	mcs $< -reference:lineareq.dll,matrix.dll,vector.dll,roots.dll,ODE.dll,genlist.dll

roots.dll: roots.cs lineareq.dll matrix.dll vector.dll
	mcs $< -target:library -reference:lineareq.dll,matrix.dll,vector.dll

ODE.dll: ODE.cs vector.dll genlist.dll
	mcs $< -target:library -reference:vector.dll,genlist.dll

genlist.dll: genlist.cs
	mcs -target:library -out:./$@ $^
		
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
	rm [Oo]ut.* *.exe *.pdf *.log *.aux *.png
