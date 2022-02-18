all: Out.txt
		cat $< # cat Out.txt
Out.txt: main.exe
		mono $< > $@

main.exe: main.cs cmath.dll
		mcs -target:exe -reference:cmath.dll -out:$@ $<

CMATHDIR = /Users/jensrlarsen/Desktop/AU-Masters/PPaNM/Exercises/Complex
cmath.dll : $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^ # note "./" in front of cmath.dll