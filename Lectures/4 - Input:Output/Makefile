all: Out-stdin.txt outfile.txt out.cmdline.txt
	cat out.cmdline.txt

out.cmdline.txt:cmdline.exe Makefile
	mono cmdline.exe 1.23e-4    45  	3e5 >$@  
	mono cmdline.exe $$(echo 1.23e-4     45 			3e5) >$@
	mono cmdline.exe $$(cat input.txt) >$@

cmdline.exe:cmdline.cs
	mcs -target:exe -out:$@ $<

outfile.txt: fileio.exe
	mono $< < input.txt 1> $@

fileio.exe:fileio.cs
	mcs -target:exe -out:$@ $<

Out-stdin.txt: stdin.exe input.txt
	mono $< < input.txt 1> $@ 2>log.txt

input.txt: Makefile
	echo -1.234e-5 99.9e+5 > $@

stdin.exe: stdin.cs
	mcs -target:exe -out:$@ $<

.PHONEY:clean
clean:
	$(RM) [Oo]ut* *.exe [Ll]og*

test:
	echo $(RM)