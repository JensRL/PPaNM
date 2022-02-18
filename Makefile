all: Out.txt
	cat Out.txt

Out-stdin.txt: stdin.exe
	mono $< > $@

stdin.exe: stdin.cs 
	mcs -target:exe -out:$@ $<

.PHONEY: clean
clean: 
		$(RM) [Oo]ut* *.exe