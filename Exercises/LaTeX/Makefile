all: ms.pdf

ms.pdf: ms.tex exp_gnuplot.tex
	pdflatex $<
	pdflatex $<
#	bibtex would normally be included for references
#	pdflatex again to compile

exp_gnuplot.tex: fig.gnuplot.gpi out.exp.txt Makefile
	gnuplot $<
	cat $@ | sed 's/\\definecolor/%\\definecolor/' > tmpfile
	mv tmpfile $@

out.exp.txt: main.exe
	mono $< > $@

main.exe: main.cs sfuncs.dll

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll, $^)) $(filter %.cs, $^)

%.dll: %.cs
	mcs -t:library $(addprefix -r:,$(filter %.dll, $^)) $(filter %.cs, $^)

clean:
	rm [Oo]ut.* *.exe *.pdf *.log *.aux