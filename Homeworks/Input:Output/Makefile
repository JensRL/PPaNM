all: Out1.txt Out2.txt Out3.txt
	cat Out1.txt Out2.txt Out3.txt

#Call the three different output channels
Out1.txt: stdin.exe
	echo 1 2 3 4 5 | mono $< > $@

Out2.txt: cmdline.exe
	mono $< 1 2 3 4 5 > $@

Out3.txt: fileio.exe
	mono $< -input:input.txt -output:$@

#Compile the three different streams
stdin.exe: stdin.cs
	mcs -target:exe -out:$@ $<

cmdline.exe: cmdline.cs
	mcs -target:exe -out:$@ $<

fileio.exe:fileio.cs
	mcs -target:exe -out:$@ $<

.PHONEY:clean
clean:
	$(RM) [Oo]ut* *.exe [Ll]og*

