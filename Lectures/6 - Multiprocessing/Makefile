CSC = mcs
RUN = mono

all:Out.txt
	cat $<

Out.txt: t2.exe t1.exe Makefile
	cat /dev/null > $@
	/usr/bin/time -p -o $@ -a $(RUN) t1.exe >> $@
	/usr/bin/time -p -o $@ -a $(RUN) t2.exe >> $@

t2.exe: t2.cs
	$(CSC) -target:exe -out:$@ $<

t1.exe: t1.cs
	$(CSC) -target:exe -out:$@ $<

clean:
	$(RM) *.dll *.exe [Oo]ut* [Ll]og*
