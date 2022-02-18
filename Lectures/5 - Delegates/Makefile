all:Out.txt
	cat $<
Out.txt: main.exe
	mono main.exe > Out.txt
main.exe: main.cs
	mcs -target:exe -out:$@ $<
clean:
	$(RM) *.dll *.exe [Oo]ut* [Ll]og*